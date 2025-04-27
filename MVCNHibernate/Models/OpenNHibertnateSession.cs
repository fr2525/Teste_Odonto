using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNHibernate.Models
{
    public class OpenNHibertnateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\nhibernate.configuration.xml");
            configuration.Configure(configurationPath);
            var clienteConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Cliente.mapping.xml");
            configuration.AddFile(clienteConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}