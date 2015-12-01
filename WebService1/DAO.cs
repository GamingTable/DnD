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
            return 1;
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

        public character GetCharacter(uint character_id)
        {
            if (this.OpenConnection() == true)
            {
                uint race_id = 0;
                uint class_id;
                List<uint> template_id = new List<uint>();
                string race = "";
                string classe = "";

                string query0 = "SELECT id_template, id_class, id_race from character WHERE id_character = " + character_id + ";";

                MySqlCommand cmd = new MySqlCommand(query0, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    race_id = (uint)dataReader["id_race"];
                    class_id = (uint)dataReader["id_class"];
                    template_id.Add((uint)dataReader["id_template"]);
                    string name = "";

                    string query1 = "SELECT id_template, name from race where id_race = " + race_id + ";";
                    string query2 = "SELECT id_template, name from class where id_class = " + class_id + ";";

                    MySqlCommand cmd0 = new MySqlCommand(query1, connection);
                    MySqlCommand cmd1 = new MySqlCommand(query2, connection);

                    MySqlDataReader dataReader0 = cmd.ExecuteReader();
                    MySqlDataReader dataReader1 = cmd.ExecuteReader();

                    if (dataReader0.Read())
                    {
                        race = (string)dataReader0["name"];
                        template_id.Add((uint)dataReader0["id_template"]);
                    }
                    if (dataReader1.Read())
                    {
                        classe = (string)dataReader1["name"];
                        template_id.Add((uint)dataReader1["id_template"]);
                    }

                    string request = "";
                    int count = 0;
                    foreach (uint element in template_id)
                    {
                        if (count == 0)
                            request += " id_template = " + element + " ";
                        else
                            request += "|| id_template = " + element + " ";
                        count++;
                    }
                    request = "SELECT sum(strength) as strength, sum(constitution) as constitution, sum(dexterity) as dexterity, sum(intelligence) as intelligence, sum(wisdom) as wisdom, sum(charisma) as charisma, sum(initiative) as initiative, sum(armor_class) as armor_class, sum(fortitude) as fortitude, sum(reflexe) as reflexe, sum(will) as will, sum(speed) as speed from template where " + request;

                    cmd = new MySqlCommand(query2, connection);

                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        character c = new character(character_id, 1, 1, classe, race, name, (int)dataReader["strength"], (int)dataReader["constitution"], (int)dataReader["dexterity"], (int)dataReader["intelligence"], (int)dataReader["wisdom"], (int)dataReader["charisma"], (int)dataReader["initiative"], (int)dataReader["armor_class"], (int)dataReader["fortitude"], (int)dataReader["reflexe"], (int)dataReader["will"], (int)dataReader["speed"]);
                        return c;
                    }
                }
                else
                {
                    this.CloseConnection();
                }
                this.CloseConnection();
            }
            else
            {
            }
            character ch = new character(1, 1, 1, "a", "b", "c", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            return ch;
        }

        public List<short_character> GetCharacters(uint account_id)
        {
            List<short_character> playable_characters = new List<short_character>();

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

        public List<short_entity> GetRaceLanguage(uint id_race)
        {
            string query = @"select id_language, name, description 
                                from dnd.language 
                            where id_language in 
                                (select dnd.language_has_race.language 
                                    from dnd.language_has_race 
                                where race = " + id_race
                            + " );";
            return GetShortEntities(query);
        }

        public List<short_entity> GetCharacterLanguage(uint id_character)
        {
            string query = @"select id_language, name, description 
                                from dnd.language 
                            where id_language in 
                                (select dnd.language_has_character.language 
                                    from dnd.language_has_character
                                where character = " + id_character
                            + " );";
            return GetShortEntities(query);
        }

        private List<short_entity> GetShortEntities(string query)
        {
            List<short_entity> list_entities = new List<short_entity>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

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

                this.CloseConnection();
            }
            return list_entities;
        }
        #endregion

        #region TEMPLATES
        public List<characteristic> GetCharacteristics(uint id_template, uint id_type=0)
        {
            List<characteristic> new_characteristic = new List<characteristic>();

            string query_characteristics = @"SELECT 
                characteristic.id_characteristic AS uid, 
                characteristic.name AS name, 
                characteristic.description AS description, 
                characteristic.abreviation AS abreviation, 
                characteristic.characteristic_type AS type, 
                SUM(template_has_characteristic.value) AS base, 
                SUM(template_has_modifier.modifier) AS modifier 
                    FROM dnd.characteristic 
                    LEFT JOIN dnd.template_has_characteristic 
                        ON characteristic.id_characteristic = template_has_characteristic.characteristic 
                    LEFT JOIN dnd.template_has_modifier 
                        ON characteristic.id_characteristic = template_has_modifier.characteristic 
                WHERE template_has_characteristic.template = " + id_template;
            // query_characteristics = @"SELECT characteristic.id_characteristic AS uid, characteristic.name AS name, characteristic.description AS description, characteristic.abreviation AS abreviation, characteristic.characteristic_type AS type, SUM(template_has_characteristic.value) AS base, SUM(template_has_modifier.modifier) AS modifier FROM characteristic LEFT JOIN template_has_characteristic ON characteristic.id_characteristic = template_has_characteristic.characteristic LEFT JOIN template_has_modifier ON characteristic.id_characteristic = template_has_modifier.characteristic WHERE template_has_characteristic.template = " + id_template;

            if (id_type > 0)
                query_characteristics += " AND characteristic.characteristic_type =" + id_type;
            query_characteristics += " GROUP BY characteristic.id_characteristic; ";

            if (OpenConnection())
            {
                //Get the characteristics values and modifiers of this template (summing all existing ones)
                MySqlCommand cmd_cha = new MySqlCommand(query_characteristics, connection);
                MySqlDataReader dataReader_cha = cmd_cha.ExecuteReader();


       
                    while (dataReader_cha.Read() && !dataReader_cha.IsDBNull(0))
                    {
                    try {
                        var c = new characteristic()
                        {
                            uid = dataReader_cha.GetUInt32(0),
                            name = dataReader_cha.IsDBNull(1) ? null : dataReader_cha.GetString(1),
                            description = dataReader_cha.IsDBNull(2) ? null : dataReader_cha.GetString(2),
                            abreviation = dataReader_cha.IsDBNull(3) ? null : dataReader_cha.GetString(3),
                            type = dataReader_cha.GetUInt16(4),

                            value = dataReader_cha.GetInt16(5),
                            modifier = dataReader_cha.GetInt16(6)
                        };
                        new_characteristic.Add(c);
                    }
                    catch(Exception k) { }
                    }

                dataReader_cha.Close();
                CloseConnection();
            }

             return new_characteristic;
               
            }

        public template GetTemplate(uint id_template)
        {
            template new_template = new template();

            /*string query_characteristics = @"SELECT 
                            characteristic.id_characteristic AS uid,
                            characteristic.name AS name,
                            characteristic.description AS description,
                            characteristic.abreviation AS abreviation,
                            characteristic.characteristic_type AS type,
	                        SUM(template_has_characteristic.value) AS base,
	                        SUM(template_has_modifier.modifier) AS modifier
                                FROM DnD.characteristic
                                LEFT JOIN DnD.template_has_characteristic
                                ON characteristic.id_characteristic = template_has_characteristic.characteristic
                                LEFT JOIN DnD.template_has_modifier
                                ON characteristic.id_characteristic = template_has_modifier.characteristic
                            WHERE template_has_characteristic.template = " + id_template;*/

            string query_template = @"SELECT
                            id_template,
                            name,
                            description
                                FROM DnD.template
                            WHERE id_template=" + id_template;

            var characteristics = GetCharacteristics(id_template);

            if (OpenConnection())
            {
                /*//Get the characteristics values and modifiers of this template (summing all existing ones)
                MySqlCommand cmd_cha = new MySqlCommand(query_characteristics, connection);
                MySqlDataReader dataReader_cha = cmd_cha.ExecuteReader();
                if (dataReader_cha.HasRows)
                {
                    while (dataReader_cha.Read())
                    {
                        characteristic c = new characteristic()
                        {
                            uid = dataReader_cha.GetUInt32(0),
                            name = dataReader_cha.IsDBNull(1) ? null : dataReader_cha.GetString(1),
                            description = dataReader_cha.IsDBNull(2) ? null : dataReader_cha.GetString(2),
                            abreviation = dataReader_cha.IsDBNull(3) ? null : dataReader_cha.GetString(3),
                            type = dataReader_cha.GetUInt16(4),

                            value = dataReader_cha.GetInt16(5),
                            modifier = dataReader_cha.GetInt16(6)
                        };
                        new_template.characteristics.Add(c);
                    }
                }
                dataReader_cha.Close();*/

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

                new_template.characteristics = GetCharacteristics(id_template);

                CloseConnection();
            }

            // Returned the now completed template structure
            return new_template;
        }
        #endregion

        #region RACES AND CLASSES
        public complete_class GetClass(uint id_class)
        {
            complete_class new_class = new complete_class();

            return new_class;

        }

        public complete_race GetRace(uint id_race)
        {
            complete_race new_race = new complete_race();

            string query = "SELECT id_race, name, description, template, img from race where id_race=" + id_race + ";";

            var languages = GetRaceLanguage(id_race);
            uint tmp_template;

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
                uint id_template = 0;

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

                new_race.template = GetTemplate(id_template);
                new_race.innates_languages = GetRaceLanguage(id_race);
                this.CloseConnection();
            }
            // Functions calling 
            //new_race.template = GetTemplate(tmp_template);

            return new_race;
        }
        #endregion
    }
}