using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfCinema
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Staff
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Стаж
        /// </summary>
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Имя: {Name}, Должность: {Position}, Стаж: {Status}";
        }
    }
    public class Cinema
    {
        /// <summary>
        /// Кинотеатр
        /// </summary>
        public string CinemaHalls { get; set; }
        /// <summary>
        /// Заллы кинотеатра
        /// </summary>

        public readonly int halls = 7; // наличие заллов в кинотеатре
        public bool Seats { get; } // места в залле (заняты или нет)
        public override string ToString()
        {
            return $"Заллы кинотеатра: {CinemaHalls}, Наличие заллов в кинотеатре: {halls} , Места: {Seats}";
        }
    }
    public class SeanceOfFilm
    {
        /// <summary>
        /// Сеанс фильма
        /// </summary>
        public string WhichCinemaHall { get; set; }
        /// <summary>
        /// Какой залл в кинотеатре
        /// </summary>
        public string MovieTime { get; set; }
        /// <summary>
        /// Время данного фильма
        /// </summary>
        public override string ToString()
        {
            return $"Какой залл в кинотеатре: {WhichCinemaHall}, Время данного фильма: {MovieTime}";
        }
    }
}