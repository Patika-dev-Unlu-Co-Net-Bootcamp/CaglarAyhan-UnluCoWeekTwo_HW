using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCoWeekTwoHW.Entities.Abstract;

namespace UnluCoWeekTwoHW.Entities.Concrete
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
