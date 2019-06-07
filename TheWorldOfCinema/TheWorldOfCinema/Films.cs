using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfCinema
{
    public class Cinema
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Film> Films { get; set; }

    }

    public class Film
    {
        public string Name { get; set; } //Название фильма
        public string Seats { get; set; } //Места
        public string Time { get; set; } //Время
        public override string ToString()
        {
            return $"Название: {Name}, Мест: {Seats}, Время: {Time}";
        }
    }
}
