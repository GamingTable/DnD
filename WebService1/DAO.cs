using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebService1.DataStructures;
using DnDService.DataStructures;

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

        }

        //try to close connection to databse. Return true if succeed, false if not.
        private bool CloseConnection()
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

        private List<short_entity> GetShortEntities(string query)
        { 
            List<short_entity> list_entities = new List<short_entity>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    for (var i = 0; dataReader.Read(); ++i)
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
    }
}