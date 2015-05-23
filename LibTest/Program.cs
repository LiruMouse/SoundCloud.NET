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

            Console.ReadLine();
        }
    }
}
