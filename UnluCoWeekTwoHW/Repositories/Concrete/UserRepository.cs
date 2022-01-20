using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;
using UnluCoWeekTwoHW.Repositories.Abstract;

namespace UnluCoWeekTwoHW.Repositories.Concrete
{
    public class UserRepository : IBaseRepository<User>
    {
        public HashSet<User> userDb = new HashSet<User>()
        {
            new  User
            {
               Id=1,
               FirstName="Darius",
               SecondName="Ilsa",
               UserName="DariusInd",
               Password="123"

            },
                    new  User
            {
               Id=2,
               FirstName="Darius2",
               SecondName="Ilsa",
               UserName="DariusInd2",
               Password="123"

            },
                         new  User
            {
               Id=3,
               FirstName="Darius3",
               SecondName="Ilsa",
               UserName="DariusInd3",
               Password="123"

            }
        };
        
        public bool ChangeStatus(object id)
        {
            
            throw new NotImplementedException();
        }

        public string Create(User obj)
        {
            userDb.Add(obj);
            return "Baş";
        }

        public bool Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllSpec(params string[] colums)
        {
            throw new NotImplementedException();
        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
