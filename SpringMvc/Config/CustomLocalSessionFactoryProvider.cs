using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Bytecode;
using Spring.Data.NHibernate;
using Spring.Data.NHibernate.Bytecode;

namespace SpringMvc.Config
{
    public class CustomLocalSessionFactoryProvider: LocalSessionFactoryObject
    {
        public override IBytecodeProvider BytecodeProvider
        {
            get { return new BytecodeProvider(ApplicationContext); }
            set { }
        }
    }
}