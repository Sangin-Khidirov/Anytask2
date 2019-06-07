using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWorldOfCinema;
using CinemaWeb.Models.DataAccessPostgreSqlProvider;

namespace CinemaWeb.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoUpload(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var xs = new XmlSerializer(typeof(Cinema));
                var cinema = (Cinema)xs.Deserialize(stream);


                using (var db = new CinemaDbContext())
                {
                    var dbs = new DbCinema()
                    {
                        Name = cinema.Name,
                        Adress = cinema.Adress,
                    };
                    dbs.Films = new Collection<DbFilm>();
                    foreach (var film in cinema.Films)
                    {
                        dbs.Films.Add(new DbFilm()
                        {
                            Name = film.Name,
                            Seats = film.Seats,
                            Time = film.Time,
                        });
                    }
                   
                    db.Cinemas.Add(dbs);
                    db.SaveChanges();
                }

                return View(cinema);
            }
        }



        public ActionResult List()
        {
            List<DbCinema> list;
            using (var db = new CinemaDbContext())
            {
                list = db.Cinemas.Include(s => s.Films).ToList();
            }
            return View(list);
        }
    }
}