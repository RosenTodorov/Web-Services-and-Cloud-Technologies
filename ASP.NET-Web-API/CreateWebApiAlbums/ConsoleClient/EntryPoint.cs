namespace ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;

    using Albums.Data;
    using Albums.Models;
    using Albums.Data.Repositories;
    using Newtonsoft.Json;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Xml;


    public class EntryPoint
    {
        private const string serviceRoot = "http://localhost:27393/";

        static void GetAlbums(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("albums").Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        static void AddAlbum(HttpClient httpClient, Album theAlbum)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theAlbum));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = httpClient.PostAsync("albums", postContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album added!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error adding student");
            }
        }

        private static void UpdateAlbumName(HttpClient httpClient, int albumId, string newName)
        {
            HttpContent putContent = new StringContent(newName);
            putContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = httpClient.PutAsJsonAsync("albums/id/" + albumId, newName).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album name updated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating album name!");
            }
        }

        private static void DeleteAlbum(HttpClient httpClient, int albumId)
        {
            var response = httpClient.DeleteAsync("albums/id/" + albumId).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album deleted!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error deleting album!");
            }
        }

        public static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceRoot);

            var album = new Album() { Title = "Reign of Hell", Producer = "Telerik Academy", Year = "2014" };

            var songs = new List<Song>();
            songs.Add(new Song() { Title = "DSA is coming!", Genre = "demonical", Year = "2014" });
            songs.Add(new Song() { Title = "We are not prepared!", Genre = "demonical", Year = "2014" });
            songs.Add(new Song() { Title = "Gonna sell my soul!", Genre = "demonical", Year = "2014" });

            var artists = new List<Artist>();
            artists.Add(new Artist() { Name = "Daniel", Country = "Bulgaria", DateOfBirth = DateTime.Parse("1986-11-06") });
            artists[0].Songs.Add(songs[0]);
            artists[0].Songs.Add(songs[1]);
            artists.Add(new Artist() { Name = "Ivan", Country = "Bulgaria", DateOfBirth = DateTime.Parse("1989-07-18") });
            artists[1].Songs.Add(songs[2]);

            album.Artists = artists;

            AddAlbum(httpClient, album);

            GetAlbums(httpClient);

            UpdateAlbumName(httpClient, 1, "Hope");

            GetAlbums(httpClient);

            DeleteAlbum(httpClient, 1);
        }
    }
}