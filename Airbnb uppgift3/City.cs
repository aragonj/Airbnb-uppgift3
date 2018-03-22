using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb_uppgift3
{
    class City

    {

        public City(string nameCity, int citizenCity, double MiddleIncome, int tourist, List<Accomodation> accommodates)

        {

            NameCity = nameCity;

            CitizenCity = citizenCity;

            MiddleIncome = middleIncome;

            Tourist = tourist;

            Accommodates = accommodates;

           // AverageCost = accommodates.Average(a => a.Price);   // LINQ, beräkna medelvärde

            countValues = accommodates.Count();    // LINQ, beräkna antal

        }
        public string NameCity { get; set; }

        public int CitizenCity { get; set; }

        public double middleIncome { get; set; }

        public int Tourist { get; set; }

        public List<Accomodation> Accommodates { get; } = new List<Accomodation>();

        public int AccommodationCount

        {

            get { return Accommodates.Count; }

        }

        public double AverageCost { get; set; }

        public int countValues { get; set; }
    }
}