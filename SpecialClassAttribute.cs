using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SpecialClassAttribute : Attribute
    {
        public int ID { get; set; } = 0;

        public SpecialClassAttribute()
        { 
        
        }

        public SpecialClassAttribute(int id)
        {
            ID = id;
        }
    }
}
