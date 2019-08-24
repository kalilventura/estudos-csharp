using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudMySql.DAO
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public Client()
        {

        }

        public Client(string name, string lastname, string cpf, string rg)
        {
            Name = name;
            Lastname = lastname;
            Cpf = cpf;
            Rg = rg;
        }

        public Client(int id, string name, string lastname, string cpf, string rg)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Cpf = cpf;
            Rg = rg;
        }
    }
}
