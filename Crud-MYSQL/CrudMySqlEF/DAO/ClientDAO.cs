using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CrudMySql.DAO
{
    class ClientDAO
    {
        private readonly string connection = @"Server=localhost;Database=cliente;Uid=root;Pwd='';";

        private MySqlConnection Connection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                return conn;
            }
            catch (MySqlException error)
            {
                Console.WriteLine("Error: " + error.Message);
                return null;
            }
        }

        private void Desconnect(MySqlConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                else
                {
                    Console.WriteLine("There is no connection to the database");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void Insert(Client client)
        {
            string query = "INSERT INTO Clients(name,lastname,Cpf,Rg) VALUES (?name,?lastname,?cpf,?rg)";
            var con = Connection();

            try
            {
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("?name", client.Name);
                command.Parameters.AddWithValue("?lastname", client.Lastname);
                command.Parameters.AddWithValue("?cpf", client.Cpf);
                command.Parameters.AddWithValue("?rg", client.Rg);
                command.ExecuteNonQuery();
                command.Dispose();

                Console.WriteLine("Customer successfully registered");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Desconnect(con);
            }
        }

        public void Delete(string name)
        {
            string query = "DELETE FROM clients WHERE name = ?name";
            var conn = Connection();
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("?name", name);
                command.ExecuteNonQuery();
                command.Dispose();

                Console.WriteLine("Customer deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Desconnect(conn);
            }
        }

        public void Alter(string name, string lastname, int id)
        {
            string query = "UPDATE clients set name = ?name, lastname = ?lastname WHERE clientid = ?id";
            var conn = Connection();
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("?name", name);
                command.Parameters.AddWithValue("?lastname", lastname);
                command.Parameters.AddWithValue("?id", id);
                command.ExecuteNonQuery();
                command.Dispose();

                Console.WriteLine("Customer registration successfully changed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Desconnect(conn);
            }
        }

        public void Alter(Client client, int id)
        {
            string query = "UPDATE clients SET name = ?name, lastname = ?lastname, cpf = ?cpf, rg = ?rg WHERE clientid = ?id";
            var con = Connection();
            try
            {
                MySqlCommand command = new MySqlCommand(query, con);
                command.Parameters.AddWithValue("?name", client.Name);
                command.Parameters.AddWithValue("?lastname", client.Lastname);
                command.Parameters.AddWithValue("?cpf", client.Cpf);
                command.Parameters.AddWithValue("?rg", client.Rg);
                command.Parameters.AddWithValue("?id", id);
                command.ExecuteNonQuery();
                command.Dispose();
                Console.WriteLine("Customer registration successfully changed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Desconnect(con);
            }
        }

        public void ListAllClients()
        {
            string query = "SELECT clientid,name,lastname,cpf,rg FROM clients";
            var conn = Connection();

            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    //Console.WriteLine("Id\t\t Name \t\t Lastname\t\t CPF\t\t RG \t\t");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("id: {0} name: {1} lastname: {2} cpf: {3} rg: {4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
            finally
            {
                Desconnect(conn);
            }
        }
    }
}
