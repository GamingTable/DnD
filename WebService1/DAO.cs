using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DnDService.DataStructures;
using System.IO;
using System.Drawing;
using System.Data;

namespace DnDService
{
    public class DAO : IDAO
    {
        /// <summary>
        /// IMPORTANT DISCLAIMER IN THIS VERSION :
        /// INVENTORY AND SPELLS ARE NOT HANDLED YET!
        /// </summary>
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;

        //Constructor
        public DAO()
        {
            Initialize();
        }

        #region INITIALIZATION
        //Initialize connection
        private void Initialize()
        {
            // MODIFY VALUES ACCORDING TO YOUR CONFIGURATION
            // AFTER EVERY PULL REQUEST
            server = "localhost";
            database = "dnd";
            uid = "root";
            password = "1234";
            port = "3306";

            string connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
                                    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //try to open connection to database. Return true if succeed, false if not.
        private bool OpenConnection()
        {
            if (connection != null && (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    return false;
                }
            }
            else if (connection == null)
                return false;
            else
                return true;

        }

        //try to close connection to databse. Return true if succeed, false if not.
        private bool CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region ACCOUNT
        public uint AccountConnection(string user, string pass)
        {
            string query = "SELECT id_account FROM account WHERE username = '" + user + "' AND password = '" + pass + "';";

            uint id = 0;

            //Open connection
            if (OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    id = (uint)dataReader["id_account"];
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
            }
            //return id to be displayed
            return id;
        }

        public uint AccountCreate(string user, string pass, string mail)
        {
            string query = "INSERT INTO account (username, password, email) VALUES('" + user + "', '" + pass + "', '" + mail + "');";

            uint id = 0;

            //Open connection
            if (OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();

                //take id
                id = AccountConnection(user, pass);
            }
            //return id to be displayed
            return id;
        }

        public bool AccountDelete(int account_id)
        {
            string query = "DELETE FROM account WHERE id_account = '" + account_id + "';";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();

                //return id to be displayed
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CHARACTER
        public int CharacterCreate(character player)
        {
            /// 0:  everything is ok
            /// 1:  DAO couldn't connect
            /// 2:  no account communicated
            /// 3:  character has no name
            /// 4:  undefined sex
            /// 5:  no class
            /// 6:  no race
            uint character_id;

            #region Character Table
            string query_character = @"insert into 
                            character(name,avatar,account,race,sex,background,hair,eyes,skin,deity,personnality) 
                            values(@name,@avatar,@account,@race,@sex,@background,@hair,@eyes,@skin,@deity,@personnality);
                            SELECT SCOPE_IDENTITY();";
            using (MySqlCommand cmd = new MySqlCommand(query_character, connection))
            {

                //Test if an account is linked
                if (player.account != 0)
                    cmd.Parameters.AddWithValue("@account", player.account);
                else
                    return 2;
                //Name
                if (player.name != null)
                    cmd.Parameters.AddWithValue("@name", player.name);
                else
                    return 3;
                //Avatar
                if (player.avatar.Length > 0)
                    cmd.Parameters.AddWithValue("@avatar", MySqlDbType.Blob).Value = player.avatar;
                //Background
                if (player.background != null)
                    cmd.Parameters.AddWithValue("@background", player.background);
                //Personnality
                if (player.personnality != null)
                    cmd.Parameters.AddWithValue("@personnality", player.personnality);
                //Hair
                if (player.hair != null)
                    cmd.Parameters.AddWithValue("@hair", player.hair);
                //Eyes
                if (player.eyes != null)
                    cmd.Parameters.AddWithValue("@eyes", player.eyes);
                //Skin
                if (player.skin != null)
                    cmd.Parameters.AddWithValue("@skin", player.skin);
                //Sex
                if (player.sex != 'M' && player.sex != 'F')
                    cmd.Parameters.AddWithValue("@sex", player.sex);
                else
                    return 4;
                //Deity
                if (player.deity != null)
                    cmd.Parameters.AddWithValue("@deity", player.deity.uid);
                //Race
                if (player.race != null)
                    cmd.Parameters.AddWithValue("@race", player.race.uid);
                else
                    return 6;

                //Executing the insertion into character
                if (OpenConnection())
                    character_id = Convert.ToUInt32(cmd.ExecuteScalar().ToString());
                else
                    return 1;
            }
            #endregion
            #region Race Dependencies
            // WEIGHT
            string query_weight = @"insert into 
                            weight_category_has_character(weight_category,character,weight) 
                            values(@weight_cat,@charac,@weight);";
            using (MySqlCommand cmd = new MySqlCommand(query_weight, connection))
            {
                //character
                cmd.Parameters.AddWithValue("@charac", character_id);
                //weight category
                cmd.Parameters.AddWithValue("@weight_cat", player.weight.Item2.uid);
                //weight
                cmd.Parameters.AddWithValue("@weight", player.weight.Item1);
                //Executing the insertion into weight
                if (OpenConnection())
                    cmd.ExecuteNonQuery();
                else
                    return 1;
            }
            // HEIGHT
            string query_height = @"insert into 
                            height_category_has_character(height_category,character,height) 
                            values(@height_cat,@charac,@height);";
            using (MySqlCommand cmd = new MySqlCommand(query_height, connection))
            {
                //character
                cmd.Parameters.AddWithValue("@charac", character_id);
                //height category
                cmd.Parameters.AddWithValue("@height_cat", player.height.Item2.uid);
                //height
                cmd.Parameters.AddWithValue("@height", player.height.Item1);
                //Executing the insertion into height
                if (OpenConnection())
                    cmd.ExecuteNonQuery();
                else
                    return 1;
            }
            // AGE
            string query_age = @"insert into 
                            age_category_has_character(age_category,character,age) 
                            values(@age_cat,@charac,@age);";
            using (MySqlCommand cmd = new MySqlCommand(query_age, connection))
            {
                //character
                cmd.Parameters.AddWithValue("@charac", character_id);
                //age category
                cmd.Parameters.AddWithValue("@age_cat", player.age.Item2.uid);
                //age
                cmd.Parameters.AddWithValue("@age", player.age.Item1);
                //Executing the insertion into weight
                if (OpenConnection())
                    cmd.ExecuteNonQuery();
                else
                    return 1;
            }
            #endregion
            #region Multiclass Table
            // MULTICLASS
            if (player.classes.level_class.Count == 0)
                return 5;
            string query_multiclass = @"insert into 
                            multiclasses(character,class,level) 
                            values(@character,@class,@level);";
            using (MySqlCommand cmd = new MySqlCommand(query_multiclass, connection))
            {
                //character
                cmd.Parameters.AddWithValue("@character", character_id);
                //class
                cmd.Parameters.AddWithValue("@class", player.classes.level_class[0].Item1);
                //class level
                cmd.Parameters.AddWithValue("@level", 1);
                //Executing the insertion into weight
                if (OpenConnection())
                    cmd.ExecuteNonQuery();
                else
                    return 1;
            }
            #endregion
            #region Spells Table
            uint spellbook_id;
            if(player.classes.level_class[0].Item2.magical == true)
            {
                // Create a spellbook for this character
                var query_spellbook = "insert into spellbook;SELECT SCOPE_IDENTITY();";
                using (MySqlCommand cmd = new MySqlCommand(query_spellbook, connection))
                {
                    if (OpenConnection())
                        spellbook_id = Convert.ToUInt32((cmd.ExecuteScalar().ToString()));
                    else
                        return 1;
                }

                // Add every spell
            }
            #endregion
            #region Skills table
            // If skills are defined, loop to add everyone of them
            if (player.skills.md_skill.Count != 0)
            {
                foreach (var skill in player.skills.md_skill)
                {
                    string query_skills = @"insert into 
                            skill_has_character(skill,character,mastery_degree) 
                            values(@skill,@character,@md);";
                    using (MySqlCommand cmd = new MySqlCommand(query_skills, connection))
                    {
                        //character
                        cmd.Parameters.AddWithValue("@character", character_id);
                        //skill
                        cmd.Parameters.AddWithValue("@skill", skill.Item1);
                        //master degree
                        cmd.Parameters.AddWithValue("@md", skill.Item2.uid);
                        //Executing the insertion into weight
                        if (OpenConnection())
                            cmd.ExecuteNonQuery();
                        else
                            return 1;
                    }
                }
            }
            #endregion
            #region Inventory Table
            uint inventory_id;
            // Create an inventory for this character
            var query_inventory = "insert into inventory(character) values(" + character_id + ");SELECT SCOPE_IDENTITY();";
            using (MySqlCommand cmd = new MySqlCommand(query_inventory,connection))
            {
                if (OpenConnection())
                    inventory_id = Convert.ToUInt32((cmd.ExecuteScalar().ToString()));
                else
                    return 1;
            }
            
            // If skills are defined, loop to add everyone of them
            if (player.skills.md_skill.Count != 0)
            {
                foreach (var skill in player.skills.md_skill)
                {
                    string query_skills = @"insert into 
                            skill_has_character(skill,character,mastery_degree) 
                            values(@skill,@character,@md);";
                    using (MySqlCommand cmd = new MySqlCommand(query_skills, connection))
                    {
                        //character
                        cmd.Parameters.AddWithValue("@character", character_id);
                        //skill
                        cmd.Parameters.AddWithValue("@skill", skill.Item1);
                        //master degree
                        cmd.Parameters.AddWithValue("@md", skill.Item2.uid);
                        //Executing the insertion into weight
                        if (OpenConnection())
                            cmd.ExecuteNonQuery();
                        else
                            return 1;
                    }
                }
            }
            #endregion
            #region Stats Table
            
            #endregion
            #region Gifts Table
            #endregion
            #region Aptitudes Table
            #endregion
            #region Languages Table
            #endregion
            #region Effects Table
            #endregion
            #region Traits
            //Weight
            //Height
            //Age
            #endregion

            // Character creation went smoothly
            return 0;

            
        }

        public bool CharacterDelete(uint character_id)
        {
            string query = "DELETE FROM character WHERE id_character = " + character_id + ";";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                int i = cmd.ExecuteNonQuery();

                //close Connection
                this.CloseConnection();

                //return id to be displayed
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CharacterUpdate(character player)
        {
            #region Character Table
            #endregion
            #region Race Table
            #endregion
            #region Multiclass Table
            #endregion
            #region Skills table
            #endregion
            #region Inventory Table
            #endregion
            #region Stats Table
            #endregion
            #region Spells Table
            #endregion
            #region Gifts Table
            #endregion
            #region Aptitudes Table
            #endregion
            #region Languages Table
            #endregion
            #region Effects Table
            #endregion
            #region Traits
            //Weight
            //Height
            //Age
            #endregion

            return true;
        }

        public character GetCharacter(uint character_id)
        {
            character new_char = new character();
            uint deity = 0, race = 0;
            var query = @"select dnd.`character`.account,
                        dnd.`character`.name,
                        dnd.`character`.avatar,
                        dnd.`character`.sex,
                        dnd.`character`.background,
                        dnd.`character`.hair,
                        dnd.`character`.eyes,
                        dnd.`character`.skin,
                        dnd.`character`.personnality,
                        dnd.`character`.race,
                        dnd.`character`.deity
                        from dnd.`character`
                        where dnd.`character`.id_character =" + character_id;

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {

                    MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                    while (dataReader.Read())
                    {
                        new_char = new character()
                        {
                            uid = character_id,
                            account = dataReader.GetUInt32(0),
                            name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                            avatar = dataReader.IsDBNull(2) ? null : (byte[])dataReader[2],
                            sex = dataReader.IsDBNull(3) ? '\0' : dataReader.GetChar(3),
                            background = dataReader.IsDBNull(4) ? null : dataReader.GetString(4),
                            hair = dataReader.IsDBNull(5) ? null : dataReader.GetString(5),
                            eyes = dataReader.IsDBNull(6) ? null : dataReader.GetString(6),
                            skin = dataReader.IsDBNull(7) ? null : dataReader.GetString(7),
                            personnality = dataReader.IsDBNull(8) ? null : dataReader.GetString(8)
                    };
                        race = dataReader.GetUInt32(9);
                        deity = dataReader.GetUInt32(10);
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }

            if(deity>0)
                new_char.deity = GetDeity(deity);

            if(race>0)
                new_char.race = GetRace(race);

            if (new_char.uid > 0)
            {
                new_char.languages = GetCharacterLanguage(character_id);
                new_char.classes = GetMulticlass(character_id);
                new_char.stats = GetCharacterCharacteristics(character_id);
                new_char.age = GetCharacterAge(character_id);
                new_char.height = GetCharacterHeight(character_id);
                new_char.weight = GetCharacterWeight(character_id);
                new_char.gifts = GetCharacterGifts(character_id);
                new_char.effects = GetCharacterEffects(character_id);
                new_char.skills = GetCharacterSkills(character_id);
                new_char.aptitudes = GetCharacterAptitudes(character_id);
            }


            return new_char;
        }

        public List<short_character> GetCharacters(uint account_id)
        {
            List<short_character> playable_characters = new List<short_character>();

            //class.name ne renvoie pas la classe principale
            //problème évident: plusieurs maxima pour les levels
            //problème de règle: les races ont des classes prioritaires
            //deity ne peut être inséré comme étant null (foreign key problem)
            //il existe temporairement une entrée vide dans god pour y pallier
            var query = @"select 
                        dnd.`character`.id_character,
                        dnd.`character`.name,
                        race.name as race,
                        sum(multiclasses.level) as global_level,
                        dnd.`character`.avatar
                        from dnd.`character`
                        left join dnd.race
                        on race.id_race = dnd.`character`.race
                        left join dnd.multiclasses
                        on multiclasses.`character` = dnd.`character`.id_character
                        left join dnd.class
                        on class.id_class = multiclasses.class
                        where `character`.account =" + account_id;

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {

                    MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                    try {
                        while (dataReader.Read())
                        {
                            short_character c = new short_character()
                            {
                                uid = dataReader.GetUInt32(0),
                                account = account_id,
                                name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                                race_name = dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                                global_level = dataReader.GetUInt32(3),
                                avatar = dataReader.IsDBNull(4) ? null : (byte[])dataReader[4]
                            };
                            playable_characters.Add(c);
                        }
                    }catch(Exception k) { }
                    dataReader.Close();
                }
                this.CloseConnection();
            }

            // Retrieving a string of every classes and corresponding level the character has
            foreach (var pc in playable_characters)
            {
                multiclass mc = GetMulticlass(pc.uid);
                pc.class_name = null;
                foreach(var c in mc.level_class)
                {
                    if(pc.class_name != null)
                        pc.class_name += "/";
                    pc.class_name += c.Item2.name + " " + c.Item1;
                }
            }

            return playable_characters;
        }
        #endregion

        #region SHORT ENTITIES
        public List<short_entity> GetRaceShortList()
        {
            string query = "SELECT id_race, name, description FROM race;";

            return GetShortEntities(query);
        }

        public List<short_entity> GetClassShortList()
        {
            string query = "SELECT id_class, name, description FROM class;";
            return GetShortEntities(query);
        }

        public List<short_entity> GetCharacteristicShortList()
        {
            string query = "SELECT id_characteristic, name, description from characteristic WHERE characteristic_type=1;";
            return GetShortEntities(query);
        }

        public List<short_entity> GetLanguageList()
        {
            string query = "SELECT id_language, name, description from language;";
            return GetShortEntities(query);
        }

        public List<short_entity> GetDeities()
        {
            string query = "SELECT id_god, name, description from god;";
            return GetShortEntities(query);
        }

        public List<short_entity> GetRaceLanguage(uint id_race)
        {
            string query = @"select id_language, name, description 
                            from dnd.language 
                            where id_language in 
                            (select dnd.language_has_race.language 
                            from dnd.language_has_race 
                            where race = " + id_race + ");";
            return GetShortEntities(query);
        }

        public List<short_entity> GetCharacterLanguage(uint id_character)
        {
            string query = @"select id_language, name, description 
                                from dnd.language 
                            where id_language in 
                                (select dnd.language_has_character.language 
                                    from dnd.language_has_character
                                where language_has_character.`character` = " + id_character
                            + " );";
            return GetShortEntities(query);
        }

        private short_entity GetShortEntity(string query)
        {
            var new_short_entity = new short_entity();
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            new_short_entity = new short_entity()
                            {
                                uid = dataReader.GetUInt32(0),
                                name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                                description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2)
                            };
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }
            return new_short_entity;
        }

        private List<short_entity> GetShortEntities(string query)
        {
            List<short_entity> list_entities = new List<short_entity>();

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            short_entity e = new short_entity()
                            {
                                uid = dataReader.GetUInt32(0),
                                name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                                description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2)
                            };
                            list_entities.Add(e);
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }
            return list_entities;
        }
        #endregion

        #region CATEGORIZED VALUES

        public Tuple<uint,category> GetCharacterAge(uint id_character)
        {
            var query = "select age_category, age from dnd.age_category_has_character where age_category_has_character.`character`="+id_character+";";
            var temporary = GetCategorizedValue(query);
            return new Tuple<uint, category>(temporary.Item1, GetAgeCategory(temporary.Item2));
        }
        public Tuple<uint, category> GetCharacterWeight(uint id_character)
        {
            var query = "select weight_category, weight from dnd.weight_category_has_character where weight_category_has_character.`character`=" + id_character + ";";
            var temporary = GetCategorizedValue(query);
            return new Tuple<uint, category>(temporary.Item1, GetWeightCategory(temporary.Item2));
        }
        public Tuple<uint, category> GetCharacterHeight(uint id_character)
        {
            var query = "select height_category, height from dnd.height_category_has_character where height_category_has_character.`character`=" + id_character + ";";
            var temporary = GetCategorizedValue(query);
            return new Tuple<uint, category>(temporary.Item1, GetHeightCategory(temporary.Item2));
        }

        public category GetAgeCategory(uint id_age_category)
        {
            string query = "SELECT id_age_category, name, description, min_age, max_age FROM dnd.age_category;";
            return GetCategoryEntity(query);
        }
        public category GetWeightCategory(uint id_weight_category)
        {
            string query = "SELECT id_weight_category, name, description, min_weight, max_weight FROM dnd.weight_category;";
            return GetCategoryEntity(query);
        }
        public category GetHeightCategory(uint id_height_category)
        {
            string query = "SELECT id_height_category, name, description, min_height, max_height FROM dnd.height_category;";
            return GetCategoryEntity(query);
        }

        private category GetCategoryEntity(string query)
        {
            var category_entity = new category();
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            category_entity = new category()
                            {
                                uid = dataReader.GetUInt32(0),
                                name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                                description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                                min = dataReader.GetInt32(3),
                                max = dataReader.GetInt32(4)
                            };
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }
            return category_entity;
        }

        private Tuple<uint,uint> GetCategorizedValue(string query)
        {
            Tuple<uint, uint> categorized_value = new Tuple<uint, uint>(0, 0);
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            categorized_value = new Tuple<uint, uint>(
                                dataReader.GetUInt32(0),
                                dataReader.GetUInt32(1)
                            );
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }
            return categorized_value;
        }
        #endregion

        #region TEMPLATES
        public List<characteristic> GetTemplateCharacteristics(uint id_template, uint id_type=0)
        {
            List<characteristic> new_characteristic = new List<characteristic>();

            string query_characteristics = @"SELECT 
                characteristic.id_characteristic AS uid, 
                characteristic.name AS name, 
                characteristic.description AS description, 
                characteristic.abreviation AS abreviation, 
                SUM(template_has_characteristic.value) AS base, 
                SUM(template_has_modifier.modifier) AS modifier,
                characteristic.characteristic_type AS type
                FROM characteristic 
                LEFT JOIN template_has_characteristic 
                ON characteristic.id_characteristic = template_has_characteristic.characteristic 
                LEFT JOIN template_has_modifier 
                ON characteristic.id_characteristic = template_has_modifier.characteristic 
                WHERE template_has_characteristic.template = " + id_template;

            if (id_type > 0)
                query_characteristics += " AND characteristic.characteristic_type =" + id_type;
            query_characteristics += " GROUP BY characteristic.id_characteristic; ";

            List<uint> type = new List<uint>();

            if (OpenConnection())
            {
                //Get the characteristics values and modifiers of this template (summing all existing ones)
                using (MySqlCommand cmd_cha = new MySqlCommand(query_characteristics, connection))
                {
                    MySqlDataReader dataReader_cha = cmd_cha.ExecuteReader();
                    while (dataReader_cha.Read() && !dataReader_cha.IsDBNull(0))
                    {
                        var c = new characteristic()
                        {
                            uid = dataReader_cha.GetUInt32(0),
                            name = dataReader_cha.IsDBNull(1) ? null : dataReader_cha.GetString(1),
                            description = dataReader_cha.IsDBNull(2) ? null : dataReader_cha.GetString(2),
                            abreviation = dataReader_cha.IsDBNull(3) ? null : dataReader_cha.GetString(3),

                            value = dataReader_cha.GetInt32(4),
                            modifier = dataReader_cha.IsDBNull(5) ? 0 : dataReader_cha.GetInt32(5)
                        };
                        new_characteristic.Add(c);
                        type.Add(dataReader_cha.GetUInt32(6));
                    }
                    dataReader_cha.Close();
                }
                CloseConnection();
            }

            var j = 0;
            foreach (uint i in type)
            {
                new_characteristic[j].type = GetCharacteristicType(i);
                ++j;
            }

            return new_characteristic;
               
        }

        public short_entity GetCharacteristicType(uint id_type)
        {
            string query = @"select id_characteristic_type,
                            name,
                            description
                            from dnd.characteristic_type
                            where id_characteristic_type = "+id_type+";";
            return GetShortEntity(query);
        }

        public List<short_entity> GetCharacteristicTypes()
        {
            string query = @"select id_characteristic_type,
                            name,
                            description
                            from dnd.characteristic_type";
            return GetShortEntities(query);
        }

        public characteristic GetCharacteristic(uint id_characteristic)
        {
            characteristic new_characteristic = new characteristic();

            string query_characteristics = @"SELECT 
                characteristic.name AS name, 
                characteristic.description AS description, 
                characteristic.abreviation AS abreviation, 
                characteristic.characteristic_type AS type, 
                FROM dnd.characteristic
                WHERE characteristic.id_characteristic = " + id_characteristic + ";";

            uint characteristic_type_id = 0;

            if (OpenConnection())
            {
                //Get the characteristics values and modifiers of this template (summing all existing ones)
                using (MySqlCommand cmd_cha = new MySqlCommand(query_characteristics, connection))
                {
                    MySqlDataReader dataReader_cha = cmd_cha.ExecuteReader();

                    while (dataReader_cha.Read() && !dataReader_cha.IsDBNull(0))
                    {
                        new_characteristic = new characteristic()
                        {
                            uid = dataReader_cha.GetUInt32(0),
                            name = dataReader_cha.IsDBNull(1) ? null : dataReader_cha.GetString(1),
                            description = dataReader_cha.IsDBNull(2) ? null : dataReader_cha.GetString(2),
                            abreviation = dataReader_cha.IsDBNull(3) ? null : dataReader_cha.GetString(3)
                        };
                        characteristic_type_id = dataReader_cha.GetUInt32(4);
                    }

                    dataReader_cha.Close();
                }
                CloseConnection();

                if (characteristic_type_id > 0)
                    new_characteristic.type = GetCharacteristicType(characteristic_type_id);
            }

            return new_characteristic;

        }

        public List<characteristic> GetCharacteristics(uint id_type = 0)
        {
            List<characteristic> new_characteristics = new List<characteristic>();

            string query_characteristics = @"SELECT 
                characteristic.name AS name, 
                characteristic.description AS description, 
                characteristic.abreviation AS abreviation, 
                characteristic.characteristic_type AS type, 
                FROM dnd.characteristic";
            if (id_type > 0)
                query_characteristics += " where characteristic_type = " + id_type;
            query_characteristics += ";";

            List<uint> characteristic_type_id = new List<uint>();

            if (OpenConnection())
            {
                //Get the characteristics values and modifiers of this template (summing all existing ones)
                using (MySqlCommand cmd_cha = new MySqlCommand(query_characteristics, connection))
                {
                    MySqlDataReader dataReader_cha = cmd_cha.ExecuteReader();

                    while (dataReader_cha.Read() && !dataReader_cha.IsDBNull(0))
                    {
                        var nc = new characteristic()
                        {
                            uid = dataReader_cha.GetUInt32(0),
                            name = dataReader_cha.IsDBNull(1) ? null : dataReader_cha.GetString(1),
                            description = dataReader_cha.IsDBNull(2) ? null : dataReader_cha.GetString(2),
                            abreviation = dataReader_cha.IsDBNull(3) ? null : dataReader_cha.GetString(3)
                        };
                        new_characteristics.Add(nc);
                        characteristic_type_id.Add(dataReader_cha.GetUInt32(4));
                    }

                    dataReader_cha.Close();
                }
                CloseConnection();

                var j = 0;
                foreach(uint i in characteristic_type_id)
                {
                    new_characteristics[j].type = GetCharacteristicType(i);
                    ++j;
                }
            }

            return new_characteristics;

        }

        public template GetTemplate(uint id_template)
        {
            template new_template = new template();

            string query_template = @"SELECT
                            id_template,
                            name,
                            description
                                FROM DnD.template
                            WHERE id_template=" + id_template;

            var characteristics = GetTemplateCharacteristics(id_template);

            if (OpenConnection())
            {
                
                // Get the proper values of this template (classic structure: uid,name,description)
                MySqlCommand cmd_tpl = new MySqlCommand(query_template, connection);
                MySqlDataReader dataReader_tpl = cmd_tpl.ExecuteReader( System.Data.CommandBehavior.SingleResult);
                //List<uint> id_tmp_charac = new List<uint>(); 
                if (dataReader_tpl.HasRows)
                {
                    while (dataReader_tpl.Read())
                    {
                        new_template.uid = id_template;
                        new_template.name = dataReader_tpl.IsDBNull(1) ? null : dataReader_tpl.GetString(1);
                        new_template.description = dataReader_tpl.IsDBNull(2) ? null : dataReader_tpl.GetString(2);
                        //id_tmp_charac.Add(dataReader_tpl.GetUInt32());
                        //new_template.characteristics = characteristics;
                    }
                }
                dataReader_tpl.Close();

                new_template.characteristics = GetTemplateCharacteristics(id_template);

                CloseConnection();
            }

            // Returned the now completed template structure
            return new_template;
        }

        public List<characteristic> GetCharacterCharacteristics(uint id_character, uint id_type=0)
        {
            List<characteristic> new_characteristic = new List<characteristic>();

            string query_characteristics = @"SELECT 
                characteristic.id_characteristic AS uid, 
                characteristic.name AS name, 
                characteristic.description AS description, 
                characteristic.abreviation AS abreviation, 
                SUM(template_has_characteristic.value) AS base, 
                SUM(template_has_modifier.modifier) AS modifier, 
                characteristic.characteristic_type AS type 
                FROM characteristic 
                LEFT JOIN template_has_characteristic 
                ON characteristic.id_characteristic = template_has_characteristic.characteristic 
                LEFT JOIN template_has_modifier 
                ON characteristic.id_characteristic = template_has_modifier.characteristic 
                WHERE template_has_characteristic.template 
                IN (SELECT template from stats where stats.character =" + id_character
                +")";

            if (id_type > 0)
                query_characteristics += " AND characteristic.characteristic_type =" + id_type;
            query_characteristics += " GROUP BY characteristic.id_characteristic; ";

            if (OpenConnection())
            {
                List<uint> type = new List<uint>();
                //Get the characteristics values and modifiers of this template (summing all existing ones)
                using (var cmd_cha = new MySqlCommand(query_characteristics, connection))
                {
                    MySqlDataReader dataReader_cha = cmd_cha.ExecuteReader();

                    while (dataReader_cha.Read() && !dataReader_cha.IsDBNull(0))
                    {
                        var c = new characteristic()
                        {
                            uid = dataReader_cha.GetUInt32(0),
                            name = dataReader_cha.IsDBNull(1) ? null : dataReader_cha.GetString(1),
                            description = dataReader_cha.IsDBNull(2) ? null : dataReader_cha.GetString(2),
                            abreviation = dataReader_cha.IsDBNull(3) ? null : dataReader_cha.GetString(3),

                            value = dataReader_cha.GetInt16(4),
                            modifier = dataReader_cha.IsDBNull(5) ? 0 : dataReader_cha.GetInt16(5)
                        };
                        new_characteristic.Add(c);
                        type.Add(dataReader_cha.GetUInt16(6));
                    }
                    dataReader_cha.Close();
                }
                CloseConnection();

                var j = 0;
                foreach(var t in type)
                {
                    new_characteristic[j].type = GetCharacteristicType(t);
                    ++j;
                }
            }

            return new_characteristic;
        }

        #endregion

        #region RACES AND CLASSES
        public complete_class GetClass(uint id_class)
        {

            complete_class new_class = new complete_class();

            if (id_class <= 0)
                return new_class;

            string query = "SELECT id_class, name, description, template, img, health_progression, magical from dnd.class where id_class=" + id_class;

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                uint id_template = 0;

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        new_class.uid = dataReader.GetUInt16(0);
                        new_class.name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                        new_class.description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                        id_template = dataReader.GetUInt32(3);
                        new_class.illustration = (byte[])dataReader[4];
                        new_class.health_progression = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
                        new_class.magical = dataReader.GetBoolean(6);
                    }
                }
                // Close reader and connection
                dataReader.Close();

                // Other queries after closing the reader
                new_class.template = GetTemplate(id_template);
                new_class.effects = GetClassEffects(id_class);
                this.CloseConnection();
            }

            return new_class;

        }

        public multiclass GetMulticlass(uint id_character)
        {
            var multiclass = new multiclass();
            if (id_character <= 0)
                return multiclass;
            multiclass.id_character = id_character;

            var query = @"Select multiclasses.class,
                        multiclasses.level
                        from dnd.multiclasses
                        where dnd.multiclasses.`character` = " + id_character+";";

            var classes = new List<Tuple<uint, uint>>();
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            classes.Add(new Tuple<uint, uint>(
                                dataReader.GetUInt16("level"),
                                dataReader.GetUInt16("class")
                            ));
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }

            multiclass.level_class = new List<Tuple<uint, complete_class>>();
            foreach (var c in classes)
            {
                multiclass.level_class.Add(new Tuple<uint, complete_class>(
                    c.Item1,
                    GetClass(c.Item2)
                ));
            }
            return multiclass;
        }

        public complete_race GetRace(uint id_race)
        {
            complete_race new_race = new complete_race();

            if (id_race <= 0)
                return new_race;

            string query = "SELECT id_race, name, description, template, img from race where id_race=" + id_race + ";";
            uint id_template = 0;

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            new_race.uid = dataReader.GetUInt16(0);
                            new_race.name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1);
                            new_race.description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2);
                            id_template = dataReader.GetUInt32(3);
                            new_race.illustration = (byte[])dataReader["img"];
                        }
                    }
                    // Close reader and connection
                    dataReader.Close();
                }
                this.CloseConnection();
            }

            // Other queries after closing the reader
            new_race.template = GetTemplate(id_template);
            new_race.innates_languages = GetRaceLanguage(id_race);
            new_race.effects = GetRaceEffects(id_race);

            return new_race;
        }
        #endregion

        #region SPECIALS (SKILLS,APTITUDES&GIFTS)
        
        public skill GetSkill(uint id_skill)
        {
            var new_skill = new skill();
            uint ability_id = 0, template_id = 0;
            string query = @"select name, description, teachable, innate, key_ability, template 
                            from dnd.skill 
                            where id_skill = " + id_skill + ";";
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            new_skill = new skill()
                            {
                                uid = id_skill,
                                name = dataReader.IsDBNull(0) ? null : dataReader.GetString(0),
                                description = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),

                                teachable = dataReader.GetBoolean(2),
                                innate = dataReader.GetBoolean(3)
                            };
                            ability_id = dataReader.GetUInt32(4);
                            template_id = dataReader.GetUInt32(5);
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();

                if (ability_id > 0)
                    new_skill.key_ability = GetCharacteristic(ability_id);
                if (template_id > 0)
                    new_skill.modifiers = GetTemplate(template_id);
                if (new_skill.uid > 0)
                {
                    string query_classes = "select id_class, name, description from dnd.class where id_class in (select class from dnd.class_has_skill where skill=" + id_skill + ");";

                    new_skill.classes = GetShortEntities(query_classes);
                    new_skill.conditions = GetSkillConditions(new_skill.uid);
                    new_skill.effects = GetSkillEffects(new_skill.uid);
                }
            }
            return new_skill;
        }
        public List<short_entity> GetSkills()
        {
            string query = "select id_skill, name, description from dnd.skill group by name;";
            return GetShortEntities(query);
        }
        public multiskill GetCharacterSkills(uint id_character)
        {
            var new_multiskill = new multiskill();
            var swap_query = new List<Tuple<uint,uint>>();
            string query = @"select skill, mastery_degree
                            from dnd.skill_has_character 
                            where dnd.skill_has_character.`character` = " + id_character + ";";
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var new_element_swap = new Tuple<uint, uint>(
                                dataReader.GetUInt32(0),
                                dataReader.GetUInt32(1)
                                );
                            swap_query.Add(new_element_swap);
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();

                foreach(var se in swap_query)
                {
                    new_multiskill.md_skill.Add(new Tuple<uint, skill>(se.Item2, GetSkill(se.Item1)));
                }

                new_multiskill.id_character = id_character;
            }
            return new_multiskill;
        }

        public aptitude GetAptitude(uint id_aptitude)
        {
            var query = "select name, description, class from dnd.aptitude where id_aptitude = " + id_aptitude + ";";
            var new_aptitude = new aptitude();
            uint id_class = 0;
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            new_aptitude = new aptitude()
                            {
                                uid = id_aptitude,
                                name = dataReader.IsDBNull(0) ? null : dataReader.GetString(0),
                                description = dataReader.IsDBNull(1) ? null : dataReader.GetString(1)
                            };
                            id_class = dataReader.GetUInt32(2);
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();

                if (id_class > 0)
                    new_aptitude.classe = GetClass(id_class);
            }
            return new_aptitude;
        }
        public List<short_entity> GetAptitudes(uint id_class = 0)
        {
            var query = "select id_aptitude, name, description from dnd.aptitude";
            if (id_class > 0)
                query += " where class =" + id_class;
            return GetShortEntities(query + ";");
        }
        public List<aptitude> GetCharacterAptitudes(uint id_character)
        {
            var query = @"select id_aptitude, name, description, class
                        from dnd.aptitude
                        where id_aptitude in
                        (select aptitude
                            from dnd.character_has_aptitude
                            where character_has_aptitude.`character` = " + id_character + ");";
            List<aptitude> list_aptitudes = new List<aptitude>();

            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            aptitude a = new aptitude()
                            {
                                uid = dataReader.GetUInt32(0),
                                name = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                                description = dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                                classe = new complete_class() { uid = dataReader.GetUInt32(3)}
                            };
                            list_aptitudes.Add(a);
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
                foreach(var a in list_aptitudes)
                {
                    if(a.classe.uid > 0)
                        a.classe = GetClass(a.classe.uid);
                }
            }
            return list_aptitudes;
        }

        public List<short_entity> GetCharacterGifts(uint id_character)
        {
            string query = @"select id_gift, name, description 
                            from dnd.gift 
                            where id_gift in 
                            (select dnd.gift_has_character.gift 
                            from dnd.gift_has_character 
                            where gift_has_character.`character` = " + id_character + ");";
            return GetShortEntities(query);
        }
        public gift GetGift(uint id_gift)
        {
            gift new_gift = new gift();
            string query = @"select name, description, category, condition, avantage, special
                            from dnd.gift 
                            where id_gift = " + id_gift + ";";
            if (OpenConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            new_gift = new gift()
                            {
                                uid = id_gift,
                                name = dataReader.IsDBNull(0) ? null : dataReader.GetString(0),
                                description = dataReader.IsDBNull(1) ? null : dataReader.GetString(1),
                                category = dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                                conditions = dataReader.IsDBNull(3) ? null : dataReader.GetString(3),
                                advantages = dataReader.IsDBNull(4) ? null : dataReader.GetString(4),
                                specials = dataReader.IsDBNull(5) ? null : dataReader.GetString(5)
                            };
                        }
                    }
                    dataReader.Close();
                }
                this.CloseConnection();
            }
            return new_gift;
        }
        public List<short_entity> GetGifts()
        {
            string query = @"select id_gift, name, avantage 
                            from dnd.gift;";
            return GetShortEntities(query);
        }

        #endregion

        #region EFFECTS
        public short_entity GetEffect(uint id_effect)
        {
            string query = @"select id_effect, name, description 
                            from dnd.effect 
                            where id_effect = " + id_effect + ");";
            return GetShortEntity(query);
        }
        public List<short_entity> GetEffects()
        {
            string query = @"select id_effect, name, description 
                            from dnd.effect;";
            return GetShortEntities(query);
        }
        public List<short_entity> GetCharacterEffects(uint id_character)
        {
            string query = @"select id_effect, name, description 
                                from dnd.effect 
                            where id_effect in 
                                (select dnd.effect_has_character.effect 
                                    from dnd.effect_has_character
                                where effect_has_character.`character` = " + id_character
                            + " );";
            return GetShortEntities(query);
        }
        public List<short_entity> GetSkillEffects(uint id_skill)
        {
            string query = @"select id_effect, name, description 
                                from dnd.effect 
                            where id_effect in 
                                (select dnd.effect_has_skill.effect 
                                    from dnd.effect_has_skill
                                where effect_has_skill.skill = " + id_skill
                            + " );";
            return GetShortEntities(query);
        }
        public List<short_entity> GetSkillConditions(uint id_skill)
        {
            string query = @"select id_effect, name, description 
                                from dnd.effect 
                            where id_effect in 
                                (select dnd.skill_conditions.effect 
                                    from dnd.skill_conditions
                                where skill_conditions.skill = " + id_skill
                            + " );";
            return GetShortEntities(query);
        }
        public List<short_entity> GetClassEffects(uint id_class)
        {
            string query = @"select id_effect, name, description 
                                from dnd.effect 
                            where id_effect in 
                                (select dnd.effect_has_class.effect 
                                    from dnd.effect_has_class
                                where effect_has_class.`class` = " + id_class
                            + " );";
            return GetShortEntities(query);
        }
        public List<short_entity> GetRaceEffects(uint id_race)
        {
            string query = @"select id_effect, name, description 
                                from dnd.effect 
                            where id_effect in 
                                (select dnd.effect_has_race.effect 
                                    from dnd.effect_has_race
                                where effect_has_race.race = " + id_race
                            + " );";
            return GetShortEntities(query);
        }
        /* Inventory and Spells are not developped in this version
        public List<short_entity> GetCategoryRequiredEffects();
        public List<short_entity> GetSpellEffects();*/
        #endregion

        #region BACKGROUND AND LIFE
        public short_entity GetDeity(uint deity_id)
        {
            string query = "SELECT id_god, name, description from god where id_god="+deity_id+";";
            return GetShortEntity(query);
        }
        #endregion
    }
}