using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebGallery.Models
{
    public class GalleryDbInitializer : DropCreateDatabaseAlways<GalleryContext>
    {
        protected override void Seed(GalleryContext db)
        {

            var test = new City {Name = "Paris", FullName = "Paris", State = State.Favorite};
            //("Tallinn", "Tallinn", State.Undefined);

            db.Cities.Add(test);
            db.Cities.Add(new City("London", "London", State.Undefined));
            db.Cities.Add(new City("Berlin", "Berlin", State.Undefined));

            db.Countries.Add(new Country("Germany", "Germany", State.Undefined));
            db.Countries.Add(new Country("Great Britain", "United Kingdom of Great Britain and Northern Ireland", State.Undefined));
            db.Countries.Add(new Country("Estonia", "Estonia", State.Undefined));
            db.Countries.Add(new Country("Estonia", "Estonia", State.Undefined));

            db.Continents.Add(new Continent("Europe", "Europe", State.Undefined));
            db.Continents.Add(new Continent("Asia", "Asia", State.Undefined));
            db.Continents.Add(new Continent("Australia", "Australia", State.Undefined));

            base.Seed(db);
        }
    }
}