using SpringMvc.Models.DataGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class UserAccountGeneratorService : IUserAccountGeneratorService
    {
        #region Data
        private string[] firstNamesMale = new string[] { "Bryan", "William", "Andrew", "Bryan", "Harold", "Rudy", "Jess", "Michael",
                                                         "Felipe", "Glen", "George", "Richard", "Michael", "Thomas", "Jacques", "Johnny",
                                                         "Michael", "Anthony", "Bryan", "Juan" };

        private string[] firstNamesFemale = new string[] { "Krista", "Felicia", "Janice", "Katelyn", "Samantha", "Meghan", "Edwin",
                                                           "Constance", "Jeremy", "Catherine", "Allison", "Marion", "Amanda", "Ethel",
                                                           "Erin", "Lorene", "Julie", "Venessa", "Ruby", "Sasha" };

        private string[] lastNames = new string[] { "Savell", "Myers", "Miller", "Long", "Boner", "Moss", "Irving", "Fisher", "Gayman",
                                                    "Beauchamp", "Bratten", "Alexander", "Reynolds", "Odonoghue", "Moore", "Harbour",
                                                    "Brown", "Morris", "Garrison", "Leach", "Peters", "Smith", "Melancon", "Coats",
                                                    "Miranda", "Farris", "Setliff", "Valentin", "White", "Keeling", "Dunn", "Terry",
                                                    "Earl", "Maldonado", "Stubblefield", "Mills", "Rogers", "Libby", "Acosta", "Grey" };

        private string[] birthDates = new string[] { "9/8/1981", "12/10/1982", "7/30/1989", "11/2/1950", "5/3/1965", "12/20/1978",
                                                     "10/8/1960", "2/12/1949", "7/5/1964", "3/23/1982", "1/17/1982", "1/11/1947",
                                                     "1/28/1982", "8/31/1947", "1/4/1978", "11/10/1967", "11/15/1965", "8/16/1961",
                                                     "1/23/1967", "5/26/1951", "4/27/1964", "10/28/1971", "1/10/1956", "6/6/1983",
                                                     "10/3/1947", "3/8/1959", "7/9/1961", "2/23/1981", "12/15/1978", "9/30/1952",
                                                     "11/6/1958", "3/24/1943", "2/10/1952", "2/11/1970", "11/14/1960", "11/2/1973",
                                                     "5/14/1987", "5/5/1954", "4/23/1954", "3/14/1988"};

        private string[] personalId = new string[] { "81090859103", "82121018653", "89073067794", "50110277513", "65050372093",
                                                     "78122032553", "60100814324", "49021221195", "64070584770", "82032367284",
                                                     "82011777062", "47011183104", "82012847657", "47083111607", "78010418800",
                                                     "67111044708", "65111589371", "61081626355", "67012320775", "51052651080",
                                                     "64042756522", "71102886873", "56011058716", "83060662761", "47100357321",
                                                     "59030831862", "61070940499", "81022396814", "78121527610", "52093019350",
                                                     "58110661163", "43032435163", "52021037365", "70021159002", "60111483470",
                                                     "73110290130", "87051474674", "54050559748", "54042314390", "88031495961"};

        private string[] postcodes = new string[] { "686", "3388", "796", "2505", "1986", "777", "467", "409", "1395", "526",
                                                    "4561", "1181", "4280", "849", "1888", "3078", "1676", "3014", "2564", "103",
                                                    "4150", "2043", "1178", "2829", "2422", "4382", "2809", "3342", "4768", "838",
                                                    "2980", "3865", "2404", "3643", "4799", "2538", "3769", "1248", "1830", "2603"};

        private string[] cities = new string[] { "Seattle", "Columbus", "Las Vegas", "Cambridge", "Montgomery", "Danbury", "Sioux Falls",
                                             "Austin", "Monrovia", "Madison", "Pearsall", "Chicago", "El Paso", "Hyattsville",
                                             "Northadams", "Newport News", "Evanston", "Camden", "Milwaukee", "Philadelphia",
                                             "San Francisco", "Naugatuck", "Harlingen", "Arlington Heights", "Livonia", "Houston",
                                             "Salt Lake City", "Fargo", "Minot", "Chicago", "Fredericksburg", "Indianapolis",
                                             "Rochelle Park", "Fort Wayne", "Rochester"};

        private string[] countries = new string[] { "Argentina", "Australia", "Austria", "Bahamas", "Belgium", "Bosnia Herzegovina",
                                                    "Botswana", "Brazil", "Bulgaria", "Canada", "Cape Verde", "Chile", "China", "Colombia",
                                                    "Croatia", "Cyprus", "Czech Republic", "Denmark", "Ecuador", "Egypt", "Estonia",
                                                    "Finland", "France", "Georgia", "Germany", "Greece", "Haiti", "Hungary", "Iceland",
                                                    "India", "Israel", "Italy", "Japan", "Latvia", "Liechtenstein", "Lithuania",
                                                    "Monaco", "Netherlands", "Norway", "Poland"};

        #endregion

    }
}