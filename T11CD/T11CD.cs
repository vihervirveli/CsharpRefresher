using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTC8440
{
    public class Song
    {
        private int length = 0;
        public string Name { get; set; }
        public int Length { get { return length; } set { length = value; } }
        public int Minutes { get; set; }
        public int Seconds { get; set; }


        public Song(string name, string durationStr)
        {
            Name = name;
            string[] durationParts = durationStr.Split(':');
            if (Int32.TryParse(durationParts[0], out int minutes) && Int32.TryParse(durationParts[1], out int seconds))
            {
                length = minutes * 60 + seconds;
                Minutes = minutes;
                Seconds = seconds;

            }

        }//constructor

        /// <summary>
        /// Returns the Song as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} lasts {Minutes}:{Seconds} minutes";
        }
    }//Song class

    public class CD
    {
        public string albumDuration = "";
        public string Artist { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public List<Song> Songs { get; set; }
        public string AlbumDuration { get { return albumDuration; } }


        /// <summary>
        /// Constructor for the CD objects
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="name"></param>
        /// <param name="genre"></param>
        /// <param name="price"></param>
        /// <param name="songs"></param>
        public CD(string artist, string name, string genre, decimal price, List<Song> songs)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            Songs = songs;
            int duration = 0;
            foreach (Song song in Songs)
            {
                duration += song.Length;
            }
            int durationMinutes = (int)duration / 60;
            int durationSeconds = duration % 60;
            albumDuration = $"{durationMinutes}:{durationSeconds}";

        }

        /// <summary>
        /// Returns all the information on the songs on the CD in one string
        /// </summary>
        /// <returns></returns>
        public string SongsOutput()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Song song in Songs)
            {
                sb.Append($"{song}\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns all the CD info in one string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"=== CD content: ===\n\nArtist:{Artist}\nName: {Name}\nGenre: {Genre}\nPrice: {Price}\n=== List of songs: ===\n{SongsOutput()}\nDuration of the entire album: {AlbumDuration}";
        }

    }//CD class

    internal class T11CD
    {

        public static void TestT11()
        {

            Song s1 = new Song("Shudder Before the Beautiful", "06:29");
            Song s2 = new Song("Weak Fantasy", "05:23");
            Song s3 = new Song("Elan", "04:45");
            Song s4 = new Song("Yours Is an Empty Hope", "05:34");
            Song s5 = new Song("Our Decades in the Sun", "06:37");
            Song s6 = new Song("My Walden", "04:38");
            Song s7 = new Song("Endless Forms Most Beautiful", "05:07");
            Song s8 = new Song("Edema Ruh", "05:15");
            Song s9 = new Song("Alpenglow", "04:45");
            Song s10 = new Song("The Eyes of Sharbat Gula", "06:03");
            Song s11 = new Song("The Greatest Show on Earth", "24:00");
            List<Song> songs = new List<Song> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11 };
            CD cd = new CD("Nightwish", "Endless Forms Most Beautiful", "Symphonic metal", 19.9M, songs);
            Console.WriteLine(cd);

            Console.WriteLine();
            Song s2e1 = new Song("Cool Riddens", "04:23");
            Song s2e2 = new Song("I own you", "2:35");
            Song s2e3 = new Song("Hello", "04:45");
            List<Song> songs2 = new List<Song> { s2e1, s2e2, s2e3 };
            CD cd2 = new CD("Rager", "Cool Album", "Pop", 9.3M, songs2);
            Console.WriteLine(cd2);
        }
        static void Main(string[] args)
        {

            TestT11();
            Console.ReadKey();
        }
    }
}
