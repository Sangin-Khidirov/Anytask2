using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfCinema
{
    public class UsersModel
    {
        public List<User> Users { get; set; }
    }

    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Status { get; set; }

        public List<Film> Basket { get; set; }

        public override string ToString()
        {
            return $"Login: {Login}, Password: {Password}, Status: {Status}, Films: {Basket}";
        }
    }

    public class UsersFilms
    {
        public List<UsersFilm> Film { get; set; }
    }

    public class Films
    {
        public List<Film> Film { get; set; }
    }
    public class UsersFilm
    {
        public string Name { get; set; }
        public string MovieTime { get; set; }
        public string Seat { get; set; } // ваше место
        public string SeatMax { get; set; }
        /// <summary>
        /// Сеанс фильма
        /// </summary>
        /// <summary>
        /// Какой залл в кинотеатре
        /// </summary>
        /// <summary>
        /// Время данного фильма
        /// </summary>
        public override string ToString()
        {
            return $"Название: {Name}, Время: {MovieTime}, Место: {Seat}";
        }
    }

    public class Film
    {
        public string Name { get; set; }
        public string MovieTime { get; set; }
        public string Seat { get; set; } // ваше место
        public string SeatMax { get; set; }
        /// <summary>
        /// Сеанс фильма
        /// </summary>
        /// <summary>
        /// Какой залл в кинотеатре
        /// </summary>
        /// <summary>
        /// Время данного фильма
        /// </summary>
        public override string ToString()
        {
            return $"Название: {Name}, Время: {MovieTime}, Мест свободно: {Seat}, Мест всего: {SeatMax}";
        }
    }
 
    public class Seat
    {
        public int SeatNumber { get; set; }
        public bool Occupied { get; set; }
        public override string ToString()
        {
            if (Occupied == true)
            {
                return $"Место: {SeatNumber} - занято";
            }
            return $"Место: {SeatNumber} - свободно";
        }
    }

}
