using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    [Serializable]
    class Celebration : Event
    {
        public Celebration(string name, string description, DateTime date) : base(name, description, date)
        {
            // Конструктор праздника, с датой и без времени
            setName = name;
            setDate = date.Date;
            setDescription = description;
        }


    }
}
