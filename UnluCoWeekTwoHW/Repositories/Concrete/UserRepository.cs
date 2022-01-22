using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Concrete;
using UnluCoWeekTwoHW.Extensions;
using UnluCoWeekTwoHW.Repositories.Abstract;

namespace UnluCoWeekTwoHW.Repositories.Concrete
{
    public class UserRepository : IUserRepository
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
        public ICollection<User> GetById(object id)
        {
            var user = userDb.Where(a => a.Id == (int)id).ToList<User>();
            return user;
        }
        public bool Login(User _user){
        var user = userDb.Where(a=>a.UserName==_user.UserName && b=>b.Password == _user.Password)
        
        if(user !=null && user.Any())
        return true;
        }
        return false
        
        public bool ChangeStatus(object id)
        {
           
            throw new NotImplementedException();
        }
        public bool Create(User obj)
        {
            if (userDb.addHashingifNotExist(obj))
            {
                return true;
            }
            return false;
        }
        public bool Delete(object id)
        {
            var user = userDb.Where(a => a.Id == (int)id).FirstOrDefault();
            userDb.Remove(user);
            return true;

        }
        public IEnumerable<User> GetAll()
        {
            var users = userDb.Where(a => true).ToList();
            return users;
        }

        public IEnumerable<User> GetAllSpec(params string[] colums)
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
