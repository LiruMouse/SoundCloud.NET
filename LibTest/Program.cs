using SoundCloud.NET;
using SoundCloud.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

            Track track = man.GetTrack("https://soundcloud.com/civiltwilight/civil-twilight-story-of-an-immigrant");

            Console.WriteLine(track.Title);

            Console.ReadLine();
        }
    }
}
