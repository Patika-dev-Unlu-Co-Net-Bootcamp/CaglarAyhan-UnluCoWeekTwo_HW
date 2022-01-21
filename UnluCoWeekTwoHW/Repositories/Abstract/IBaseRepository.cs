using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekTwoHW.Repositories.Abstract
{
    public interface IBaseRepository<T> where T:class
    {
        //Bütün verileri bütün bilgileri ile birlikte listeler. 
        IEnumerable<T> GetAll();
        // Kullanıcının parametre olarak verdiği alanları listeliyorum.
        IEnumerable<T> GetAllSpec(params string[] colums);
        ICollection<T> GetById(object id);
        IEnumerable<T> GetByName(string name);
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(object id);
        bool ChangeStatus(object id);
    }
}
