using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Attributes
{
    /// <summary>
    /// Beschreibt einen URL Parameter für die Suche
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    class UrlParameterProperty : Attribute
    {
        /// <summary>
        /// Name des Parameters
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// Legt einen neuen URL Parameter an
        /// </summary>
        /// <param name="paramName"></param>
        public UrlParameterProperty(string paramName)
        {
            this.ParameterName = paramName;
        }
    }
}
