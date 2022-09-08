using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_2._7.Entities
{
    public class Client : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public List<Schedule> Schedules { get; set; }
        public enum GenderType
        {
            Male,
            Female
        }

        
    }
}
