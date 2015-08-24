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
            #region Get track by ID

            {
                // Create a new SoundCloudManager
                SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

                // Get a track
                Track track = man.GetTrack(187426021);

                // Do something with it 
                Console.WriteLine(track.Id);
                Console.WriteLine(track.Title);
                Console.WriteLine(track.User.Username);
            }

            #endregion

            #region Get track by URL

            {
                // Create a new SoundCloudManager
                SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

                // Get a track
                Track track = man.GetTrack("https://soundcloud.com/exgftheband/wearethehearts");

                // Do something with it 
                Console.WriteLine(track.Id);
                Console.WriteLine(track.Title);
                Console.WriteLine(track.User.Username);
            }

            #endregion

            #region Get playlist by ID

            {
                // Create a new SoundCloudManager
                SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

                // Get a playlist
                Playlist playlist = man.GetPlaylist(130316479);

                // Do something with it 
                Console.WriteLine(playlist.Id);
                Console.WriteLine(playlist.Title);
                Console.WriteLine(playlist.User.Username);
            }

            #endregion

            #region Get playlist by URL

            {
                // Create a new SoundCloudManager
                SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

                // Get a playlist
                Playlist playlist = man.GetPlaylist("https://soundcloud.com/songsthatbelong/sets/volume-ii");

                // Do something with it 
                Console.WriteLine(playlist.Id);
                Console.WriteLine(playlist.Title);
                Console.WriteLine(playlist.User.Username);
            }

            #endregion

            #region Get user by ID

            {
                // Create a new SoundCloudManager
                SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

                // Get an user
                User user = man.GetUser(70692);

                // Do something with it 
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Username);
            }

            #endregion

            #region Get user by URL

            {
                // Create a new SoundCloudManager
                SoundCloudManager man = new SoundCloudManager("YOUR_CLIENT_ID");

                // Get an user
                User user = man.GetUser("https://soundcloud.com/rac");

                // Do something with it 
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Username);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
