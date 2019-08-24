using CrudNHibernate.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNHibernate.NHibernate
{
    class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Email);
            Map(x => x.Curso);
            Map(x => x.Sexo);
            Table("Alunos");
        }
    }
}
