using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SchoolMaster.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<SchoolMasterEntities>
    {
        protected override void Seed(SchoolMasterEntities context)
        {
            var teachers = new List<Teacher>
            {
                new Teacher { LastName = "Dinsoreanu", FirstMidName = "Mihaela", Cabinet = "M08", Email = "mihaela.dinsoreanu@cs.utcluj.ro" },
                new Teacher { LastName = "Potolea", FirstMidName = "Rodica", Cabinet = "C09", Email = "rodica.potolea@cs.utcluj.ro" }
            };

            teachers.ForEach(p => context.Teachers.Add(p));
        }
    }
}