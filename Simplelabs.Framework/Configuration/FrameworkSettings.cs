﻿using Simplelabs.Framework.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration
{
    /// <summary>
    /// Configuración del Framework
    /// </summary>
    public class FrameworkSettings : ConfigurationSection
    {
        private const string nhibernate = "nhibernate";

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(nhibernate)]
        public NHibernateSettings NHibernate
        {
            get { return (NHibernateSettings)this[nhibernate]; }
        }
    }
}
