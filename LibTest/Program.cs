using SoundCloud.NET;
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

            User u = man.GetUser("https://soundcloud.com/nightcorereality");

            Console.WriteLine(u.Username);
            Console.WriteLine(u.Online);

            foreach (Track t in u.GetTracks())
            {
                Console.WriteLine(t.Title);
            }

            //SoundCloudManager.write("http://api.soundcloud.com/playlists/109804597.json?client_id=YOUR_CLIENT_ID");
            SoundCloudManager.write("http://api.soundcloud.com/tracks/139322451.json?client_id=YOUR_CLIENT_ID");

            Track track = man.GetTrack("https://soundcloud.com/bloes-brothers/bloes-brothers-36-klingande");
            Console.WriteLine(track.Title);

            Console.ReadLine();
        }
    }
}
