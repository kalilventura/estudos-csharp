using CrudMySql.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientDAO clientDAO = new ClientDAO();
            
            clientDAO.Insert(new Client("Bob", "Tabor", "40779955425", "399061824"));
            clientDAO.Insert(new Client("Carl", "Grimes", "40888966552", "3333333333"));
            clientDAO.Insert(new Client("Jim", "Jinkins", "407965514", "2222222222"));
            clientDAO.Insert(new Client("John", "Snow", "11111111111", "399011111"));
            
            clientDAO.ListAllClients();

            Console.ReadLine();
        }

    }


}
