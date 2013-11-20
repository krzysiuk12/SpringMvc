using SpringMvc.Models.POCO;
using SpringMvc.Models.DataGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.UserAccounts.Services.Interfaces;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class UserAccountGeneratorService : IUserAccountGeneratorService
    {
        private IAuthorizationService AuthorizationService { get; set; }

        #region Data
        private string[] firstNames = new string[] { "Bryan", "William", "Andrew", "Bryan", "Harold", "Rudy", "Jess", "Michael", "Felipe", "Glen", 
                                                     "George", "Richard", "Michael", "Thomas", "Jacques", "Johnny", "Michael", "Anthony", "Bryan", "Juan",
                                                     "Krista", "Felicia", "Janice", "Katelyn", "Samantha", "Meghan", "Edwin", "Constance", "Jeremy", "Catherine",
                                                     "Allison", "Marion", "Amanda", "Ethel", "Erin", "Lorene", "Julie", "Venessa", "Ruby", "Sasha" };

        private string[] lastNames = new string[] { "Savell", "Myers", "Miller", "Long", "Boner", "Moss", "Irving", "Fisher", "Gayman", "Beauchamp", 
                                                    "Bratten", "Alexander", "Reynolds", "Odonoghue", "Moore", "Harbour", "Brown", "Morris", "Garrison", "Leach", 
                                                    "Peters", "Smith", "Melancon", "Coats", "Miranda", "Farris", "Setliff", "Valentin", "White", "Keeling", 
                                                    "Dunn", "Terry", "Earl", "Maldonado", "Stubblefield", "Mills", "Rogers", "Libby", "Acosta", "Grey" };

        private int[] birthDateMonths = new int[] { 9, 12, 7, 11, 5, 12, 10, 2, 7, 3, 1, 1, 1, 8, 1, 11, 11, 8, 1, 5, 4, 10, 1, 6, 10,
                                                    3, 7, 2, 12, 9, 11, 3, 2, 2, 11, 11, 5, 5, 4, 3};

        private int[] birthDateDays = new int[] { 8, 10, 30, 2, 3, 20, 8, 12, 5, 23, 17, 11, 28, 31, 4, 10, 15, 16, 23, 26, 27, 28, 10,
                                                  6, 3, 8, 9, 23, 15, 30, 6, 24, 10, 11, 14, 2, 14, 5, 23, 14 };

        private int[] birthDateYears = new int[] {  1981, 1982, 1989, 1950, 1965, 1978, 1960, 1949, 1964, 1982, 
                                                    1982, 1947, 1982, 1947, 1978, 1967, 1965, 1961, 1967, 1951, 
                                                    1964, 1971, 1956, 1983, 1947, 1959, 1961, 1981, 1978, 1952,
                                                    1958, 1943, 1952, 1970, 1960, 1973, 1987, 1954, 1954, 1988 };

        private string[] personalId = new string[] { "81090859103", "82121018653", "89073067794", "50110277513", "65050372093", "78122032553", "60100814324", "49021221195", "64070584770", "82032367284",
                                                     "82011777062", "47011183104", "82012847657", "47083111607", "78010418800", "67111044708", "65111589371", "61081626355", "67012320775", "51052651080",
                                                     "64042756522", "71102886873", "56011058716", "83060662761", "47100357321", "59030831862", "61070940499", "81022396814", "78121527610", "52093019350",
                                                     "58110661163", "43032435163", "52021037365", "70021159002", "60111483470", "73110290130", "87051474674", "54050559748", "54042314390", "88031495961"};

        private string[] postcodes = new string[] { "686", "3388", "796", "2505", "1986", "777", "467", "409", "1395", "526",
                                                    "4561", "1181", "4280", "849", "1888", "3078", "1676", "3014", "2564", "103",
                                                    "4150", "2043", "1178", "2829", "2422", "4382", "2809", "3342", "4768", "838",
                                                    "2980", "3865", "2404", "3643", "4799", "2538", "3769", "1248", "1830", "2603"};

        private string[] streets = new string[] { "Benedum Drive", "Tuna Street", "Cerullo Road", "Maryland Avenue", "Custer Street", "Rocket Drive", "Ridenour Street", "State Street", "Fairway Drive", "Corbin Branch Road",
                                                  "Thunder Road", "Pritchard Court", "Owagner Lane", "Fleming Way", "Paul Wayne Haggerty Road", "Gorby Lane", "Olive Street", "Williams Lane", "Quiet Valley Lane", "Hewes Avenue",
                                                  "Butternut Lane", "Valley Lane", "Snowbird Lane", "Sycamore Street", "Grant View Drive", "Pearcy Avenue", "Lilac Lane", "Stoney Lonesome Road", "Scenic Way", "Poplar Chase Lane",
                                                  "Leverton Cove Road", "Lynn Ogden Lane", "Turkey Pen Road", "Del Dew Drive", "Richards Avenue", "Quiet Valley Lane", "Rhode Island Avenue", "Elk Creek Road", "Hinkle Lake Road", "Dola Mine Road" };

        private string[] cities = new string[] { "Seattle", "Columbus", "Las Vegas", "Cambridge", "Montgomery", "Danbury", "Sioux Falls",
                                                 "Austin", "Monrovia", "Madison", "Pearsall", "Chicago", "El Paso", "Hyattsville",
                                                 "Northadams", "Newport News", "Evanston", "Camden", "Milwaukee", "Philadelphia",
                                                 "San Francisco", "Naugatuck", "Harlingen", "Arlington Heights", "Livonia", "Houston",
                                                 "Salt Lake City", "Fargo", "Minot", "Chicago", "Fredericksburg", "Indianapolis",
                                                 "Rochelle Park", "Fort Wayne", "Rochester", "Stanford", "Warsaw", "Cracow", "Texas", "Los Angeles"};

        private string[] countries = new string[] { "Argentina", "Australia", "Austria", "Bahamas", "Belgium", "Bosnia Herzegovina",
                                                    "Botswana", "Brazil", "Bulgaria", "Canada", "Cape Verde", "Chile", "China", "Colombia",
                                                    "Croatia", "Cyprus", "Czech Republic", "Denmark", "Ecuador", "Egypt", "Estonia",
                                                    "Finland", "France", "Georgia", "Germany", "Greece", "Haiti", "Hungary", "Iceland",
                                                    "India", "Israel", "Italy", "Japan", "Latvia", "Liechtenstein", "Lithuania",
                                                    "Monaco", "Netherlands", "Norway", "Poland"};

        private string[] phoneNumbers = new string[] { "501962406", "502244820", "503907935", "603811947", "605581783", "721655442", "723637638", "812618611", "885140967", "509998791",
                                                       "501599512", "502703770", "503340522", "603538312", "605134811", "721678494", "723563820", "812385461", "885630057", "509366335",
                                                       "501350610", "502983891", "503109056", "603101583", "605894776", "721661704", "723107895", "812549590", "885987514", "509448179",
                                                       "501589611", "502961631", "503572302", "603241861", "605343000", "721580419", "723271374", "812841888", "885535907", "509695984" };

        private string[] identityCardNumbers = new string[] {   "ATA904868", "ATA257223", "ATA741302", "ATA391350", "ATA491550", "ATA331948", "ATA663085", "ATA237833", "ATA950349", "ATA908670",
                                                                "ATA332223", "ATA854220", "ATA733733", "ATA651703", "ATA622050", "ATA784268", "ATA302891", "ATA463719", "ATA719388", "ATA790746", 
                                                                "ATA368190", "ATA561301", "ATA375615", "ATA452506", "ATA575489", "ATA953469", "ATA365154", "ATA590516", "ATA206407", "ATA542776", 
                                                                "ATA767902", "ATA114119", "ATA854393", "ATA424089", "ATA697698", "ATA309533", "ATA837254", "ATA338452", "ATA541651", "ATA905114" };

        #endregion

        public List<Address> GenerateAddress()
        {
            List<Address> userAddress = new List<Address>();

            for (int index = 0; index < streets.Length; index++)
            {
                userAddress.Add(new Address()
                {
                    Street = streets[index],
                    City = cities[index],
                    PostalCode = postcodes[index],
                    Country = countries[index]
                });
            }
            return userAddress;
        }

        public List<PersonalData> GeneratePersonalData(List<Address> userAddressList)
        {
            List<PersonalData> userPersonalData = new List<PersonalData>();

            for (int index = 0; index < firstNames.Length; index++)
            {
                userPersonalData.Add(new PersonalData()
                {
                    FirstName = firstNames[index],
                    MiddleName = firstNames[(index + 13) % firstNames.Length],
                    LastName = lastNames[index],
                    DateOfBirth = new System.DateTime(birthDateYears[index], birthDateMonths[index], birthDateDays[index]),
                    Sex = (Math.Floor((double)(index / 20)) == 0) ? PersonalData.Gender.MALE : PersonalData.Gender.FEMALE,
                    IdentityCardNumber = identityCardNumbers[index],
                    PESEL = personalId[index],
                    PhoneNumber = phoneNumbers[index],
                    Address = userAddressList.ElementAt(index)
                });
            }
            return userPersonalData;
        }

        public List<UserAccount> GenerateUsers(List<PersonalData> userPersonalDataList)
        {
            List<UserAccount> users = new List<UserAccount>();

            for (int index = 0; index < firstNames.Length; index++)
            {
                int rand = new Random().Next(30);
                UserAccount user = new UserAccount()
                {
                    Login = firstNames[index] + lastNames[index],
                    Password = AuthorizationService.EncryptPassword(lastNames[index]),
                    Email = firstNames[index] + lastNames[index] + "@mail.com",
                    PersonalData = userPersonalDataList.ElementAt(index),
                };
                switch (index % 10)
                { 
                    case 7:
                        user = GenerateDatesForUserWithStatus(UserAccount.Status.EXPIRED, user);
                        break;
                    case 8:
                        user = GenerateDatesForUserWithStatus(UserAccount.Status.REMOVED, user);
                        break;
                    case 9:
                        user = GenerateDatesForUserWithStatus(UserAccount.Status.LOCKED_OUT, user);
                        break;
                    default:
                        user = GenerateDatesForUserWithStatus(UserAccount.Status.ACTIVE, user);
                        break;
                }
                users.Add(user);
            }
            return users;
        }

        private UserAccount GenerateDatesForUserWithStatus(UserAccount.Status status, UserAccount user)
        {
            user.AccountStatus = status;
            if (status == UserAccount.Status.ACTIVE || status == UserAccount.Status.LOCKED_OUT)
            {
                int rand = new Random().Next(30);
                user.LastPasswordChangedDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(rand));
                user.LastSuccessfulSignInDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(rand - rand % 10));
                user.ValidTo = DateTime.Now.Date.AddDays(rand + 31);
                user.ValidFrom = DateTime.Now.Date.Subtract(TimeSpan.FromDays((rand % 10) * rand));
            }
            else if (status == UserAccount.Status.REMOVED)
            {
                int rand = new Random().Next(61);
                user.LastPasswordChangedDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(3 * 31 + rand + rand % 10));
                user.LastSuccessfulSignInDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(3 * 31 + rand % 31));
                user.ValidTo = DateTime.Now.Date.Subtract(TimeSpan.FromDays(32 + rand % 31));
                user.ValidFrom = DateTime.Now.Date.Subtract(TimeSpan.FromDays(62 + 2 * ((rand % 4) + 1) * rand));
            }
            else
            {
                int rand = new Random().Next(61);
                user.LastPasswordChangedDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(31 + rand + rand % 10));
                user.LastSuccessfulSignInDate = DateTime.Now.Date.Subtract(TimeSpan.FromDays(31 + rand % 31));
                user.ValidTo = DateTime.Now.Date.Subtract(TimeSpan.FromDays(rand % 31));
                user.ValidFrom = DateTime.Now.Date.Subtract(TimeSpan.FromDays(2 * ((rand % 3) + 1) * rand));
            }
            return user;
        }
        public IList<LogInOutEvent> GenerateLogInOutEvents(List<UserAccount> userList)
        {
            IList<LogInOutEvent> logInOutEventsList = new List<LogInOutEvent>();
            foreach (UserAccount user in userList)
            {
                DateTime validFrom = user.ValidFrom;
                DateTime lastSuccesfulSignIn = user.LastSuccessfulSignInDate;
                int timeSpan = (int) (lastSuccesfulSignIn.Date - validFrom.Date).Days;
                int rand = new Random().Next(timeSpan / 3) + 1;
                int daySpan = (int) timeSpan / rand;
                while (daySpan < timeSpan)
                {
                    if (daySpan % 6 == 1)
                    {

                        logInOutEventsList.Add(new LogInOutEvent() {
                            IpAddress = "192.168.0.1",
                            UserAccount = user,
                            Type = LogInOutEvent.ActionType.LOGIN_FAILURE,
                            GeneratedOn = lastSuccesfulSignIn.Date.Subtract(TimeSpan.FromDays(daySpan))
                        });
                    }
                    else
                    {
                        logInOutEventsList.Add(new LogInOutEvent()
                        {
                            IpAddress = "192.168.0.1",
                            UserAccount = user,
                            Type = LogInOutEvent.ActionType.LOGIN_SUCCESSFUL,
                            GeneratedOn = lastSuccesfulSignIn.Date.Subtract(TimeSpan.FromDays(daySpan))
                        }); 
                        logInOutEventsList.Add(new LogInOutEvent()
                        {
                            IpAddress = "192.168.0.1",
                            UserAccount = user,
                            Type = LogInOutEvent.ActionType.LOGOUT,
                            GeneratedOn = lastSuccesfulSignIn.Date.Subtract(TimeSpan.FromDays(daySpan))
                        });
                    }
                    daySpan += daySpan;
                }
            }
            return logInOutEventsList;
        }
    }
}