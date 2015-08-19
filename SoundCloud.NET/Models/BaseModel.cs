using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Models
{
    public abstract class BaseModel
    {
        #region Internal Properties

        internal SoundCloudManager SoundCloudManager { get; set; }

        #endregion Internal Properties
    }
}
