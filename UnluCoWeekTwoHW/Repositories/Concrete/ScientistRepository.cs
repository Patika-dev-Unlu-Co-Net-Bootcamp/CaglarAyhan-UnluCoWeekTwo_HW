using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Data;
using UnluCoWeekTwoHW.Entities.Concrete;
using UnluCoWeekTwoHW.Error_Management;
using UnluCoWeekTwoHW.Extensions;
using UnluCoWeekTwoHW.Repositories.Abstract;


namespace UnluCoWeekTwoHW.Repositories.Concrete
{
    public class ScientistRepository : IScientistRepository
    {
        FakeDatabase fakeDatabase = new FakeDatabase();
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
        public Scientist GetById(object id)
        {
            var scientist = scientistsDb.Where(a => a.ScientistId == (int)id).FirstOrDefault();
            return scientist;
        }
        public IEnumerable<Scientist> GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Scientist> GetAll()
        {
            var scientist = scientistsDb.Where(a=> true).ToHashSet();
            return scientist;
        }
        public IEnumerable<Scientist> GetAllSpec(params string[] colums)
        {
            throw new NotImplementedException();
        }
        public string Create(Scientist obj)
        {
            if (scientistsDb.AddIfNotExists(obj)) //yazdığımız extension method u kullandık
            {
                return $"{obj.ScientistName} isimli bilim insanı sisteme başarı ile eklenmiştir."; 
            }
            return Messages.ExistingData(obj.ScientistName);
        }
        public bool Delete(object id)
        {
            var scientist = scientistsDb.Where(a => a.ScientistId == (int)id).FirstOrDefault();
            scientistsDb.Remove(scientist);
            return true;
        }
        public bool ChangeStatus(object id)
        {
            var scientist = scientistsDb.Where(a => a.ScientistId == (int)id).FirstOrDefault();
            if(scientist.isActive==true)
            {
                scientist.isActive = false;              
                return true;
            }
            else
            {
                scientist.isActive = true;
                return true;
            }       
        }     
        public bool Update(Scientist obj)
        {
            var scientist = scientistsDb.Where(a => a.ScientistId == obj.ScientistId).FirstOrDefault();
            if (scientist != null)
            {
                scientist.ScientistName = scientist.ScientistName;
                scientist.ScientistSecondName = scientist.ScientistSecondName;

                return true;
            }
            return false;
        }
    }
}
