using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class UserAccountGeneratorService
    { 
        private List<string> firstNamesFemale = new List<string> { "Aleksandra", "Alicja", "Anna", "Barbara", "Brunhilda",
                                                                   "Daria", "Ewa", "Ewelina", "Joanna", "Katarzyna", "Maria",
                                                                   "Monika", "Natalia", "Patrycja", "Sacha"};

        private List<string> firstNamesMale = new List<string> { "Aleksander", "Andrzej", "Dariusz", "Edward", "Henryk", "Jan",
                                                                 "Krzysztof", "Maciej", "Marcin", "Piotr", "Patryk", "Robert",
                                                                 "Thor", "Tomasz", "Zbigniew" };

        private List<string> lastNamesFemale = new List<string> { "Kowalska", "Zawadzka", "Piotrowska", "Nowak", "Pilch", "Jankowska",
                                                                  "Sikora", "Mazur", "Kaczmarczyk", "Kucharska", "Wysocka", "Krawczyk",
                                                                  "Wawrzyniak", "Majewska", "Grey"};

        private List<string> lastNamesMale = new List<string> { "Wojciechowski", "Pawlik", "Jarosz", "Ostrowski", "Kozak", "Baran", "Kot",
                                                                "Owczarek", "Marczak", "Kowalski", "Konieczny", "Gaik", "Odinson", "Lis", "Polak"};
    }
}