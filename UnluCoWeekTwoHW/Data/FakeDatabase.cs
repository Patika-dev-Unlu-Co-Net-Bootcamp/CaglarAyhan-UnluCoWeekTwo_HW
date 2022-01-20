using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;

namespace UnluCoWeekTwoHW.Data
{
    public class FakeDatabase
    {
        public HashSet<Scientist> scientistsDb = new HashSet<Scientist>()
        {
            new  Scientist
            {
                ScientistId=1,
                ScientistName="Albert",
                ScientistSecondName="Einstein",
                ScientistFieldOfStudy="theoretical physics",
                ScientistNationality="Germany",
                Popularity=1200,
                ScientistUniversity="University Of Zurich"
            },
                  new Scientist
            {
                ScientistId=2,
                ScientistName="Max",
                ScientistSecondName="Planck",
                ScientistFieldOfStudy="theoretical physics",
                ScientistNationality="Germany",
                Popularity=1000,
                ScientistUniversity="Ludwig Maximilian University of Munich",
                isActive=true
            },
                        new Scientist
            {
                ScientistId=3,
                ScientistName="Marie Salomea Skłodowska",
                ScientistSecondName="Curie ",
                ScientistFieldOfStudy="physicist and chemist ",
                ScientistNationality="Germany",
                Popularity=1100,
                ScientistUniversity="University of Paris",
                isActive=true
            }
        };
    }
}
