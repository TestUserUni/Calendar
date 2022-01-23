using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp13
{
    [Serializable]
    abstract class Event
    {
        private string name; //Название события
        private string desc; //Описание события
        private DateTime date; //Дата события

        public Event()
        {
            // пустой конструктор
        }
        public Event(string name, string desc)
        {
            this.name = name;
            this.desc = desc; // конструктор с сегодняшней датой
            date = DateTime.Now;
        }
        public Event(string name, string desc, DateTime date)
        {
            this.name = name;
            this.desc = desc; // конструктор с заданной датой
            this.date = date;
        }
        public string getName 
        {
            get { return name; } //получить название
         
        }
        public string setName
        {
            set { name = value; } // задать название
        }
        public string getDescription
        {
            get { return desc; } // получить описание
         
        }
        public string setDescription
        {
            set { desc = value; } // задать описание
        }
        public DateTime getDate
        {
            get { return date; } // получить дату
          
        }
        public DateTime setDate
        {
            set { date = value; } // задать дату

        }
    }
}
