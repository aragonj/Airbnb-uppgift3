using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb_uppgift3
{
    class Country
    {
        //List of variables
        private string countryNamn;
        private int countryInvånare;
        private int countryBnpPerCapita;
        private List<City> cityList = new List<City>();


        // constructor
        public Country(string CountryNamn, int CountryInvånare, int CountryBnpPerCapita)
        {
            countryNamn = CountryNamn;
            countryInvånare = CountryInvånare;
            countryBnpPerCapita = CountryBnpPerCapita;
            cityList = CityList;
        }
        // getter setters
        public string CountryNamn
        {
            get { return countryNamn; }
            set { countryNamn = value; }
        }
        public int CountryInvånare
        {
            get { return countryInvånare; }
            set { countryInvånare = value; }
        }
        public int CityBnpPerCapita
        {
            get { return countryBnpPerCapita; }
            set { countryBnpPerCapita = value; }
        }
        public List<City> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }
        public void AddCity(City myCity)
        {
            CityList.Add(myCity);
        }
    }
}
