﻿using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.DataGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class GeneratorService
    {
        private IBookTypeGeneratorService BookTypeGeneratorService { get; set; }
        private IOrderGeneratorService OrderGeneratorService { get; set; }
        private IUserAccountGeneratorService UserAccountGeneratorService { get; set; }
        private IServiceLocator ServiceLocator { get; set; }
    }
}