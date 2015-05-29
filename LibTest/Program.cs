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

            Track track = man.GetTrack("https://soundcloud.com/bloes-brothers/bloes-brothers-36-klingande");
            Console.WriteLine(track.Title);

            Console.WriteLine("------------");

            User test = man.GetUser("https://soundcloud.com/validworks");

            foreach (Set set in test.GetPlaylists())
            {
                Console.WriteLine(set.Title);
            }

            Console.WriteLine("------------");

            foreach (User user in test.GetFollowers())
            {
                Console.WriteLine(user.Username);
            }

            Console.WriteLine("------------");

            foreach (User user in test.GetFollowings())
            {
                Console.WriteLine(user.Username);
            }

            Console.WriteLine("------------");

            foreach (Track fav in test.GetFavorites())
            {
                Console.WriteLine(fav.Title);
            }

            Console.ReadLine();
        }
    }
}
