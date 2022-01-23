using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    class Reminder : Event
    {
        public Reminder(string name, string description, DateTime date) : base(name, description, date)
        {
            // конструктор Напоминания, с временем
            setName = name;
            setDate = date;
            setDescription = description;
        }
    }
}
