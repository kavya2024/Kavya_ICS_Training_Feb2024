using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class CountryController : ApiController
    {
      
        private static List<Country> countries = new List<Country>()
        {
            new Country {CountryId  = 1, CountryName = "India", CountryCapital = "New Delhi" },
            new Country { CountryId = 2, CountryName = "Afghanistan", CountryCapital = "Kabul" },
            new Country { CountryId = 3, CountryName = "Vatican", CountryCapital = "vatican City" }
        };

        // GET: Country

        [HttpGet]

        public IEnumerable<Country> Get()

        {

            return countries;

        }

        // GET: api/Country/5

        public IHttpActionResult Get(int id)

        {

            var country = countries.FirstOrDefault(c => c.CountryId == id);

            if (country == null)

                return NotFound();

            return Ok(country);

        }

        // POST: api/Country

        public IHttpActionResult Post(Country country)

        {

            country.CountryId = countries.Count + 1;

            countries.Add(country);

            return CreatedAtRoute("DefaultApi", new { id = country.CountryId }, country);

        }

        // PUT: api/Country/5

        public IHttpActionResult Put(int id, Country country)

        {

            var existingCountry = countries.FirstOrDefault(c => c.CountryId == id);

            if (existingCountry == null)

                return NotFound();

            existingCountry.CountryName = country.CountryName;

            existingCountry.CountryCapital = country.CountryCapital;

            return Ok(countries);

        }

        // DELETE: api/Country/5

        public IHttpActionResult Delete(int id)

        {

            var country = countries.FirstOrDefault(c => c.CountryId == id);

            if (country == null)

                return NotFound();

            countries.Remove(country);

            return Ok(country);

        }

    }
}

