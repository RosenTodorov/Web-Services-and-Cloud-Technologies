using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Albums.Data;
using Albums.Models;

namespace Albums.Services.Controllers
{
    public class AlbumsController : ApiController
    {
        private AlbumsData data;

        public AlbumsController()
            : this(new AlbumsData())
        {
        }

        public AlbumsController(AlbumsData data)
        {
            this.data = data;
        }

        // GET albums/
        public HttpResponseMessage GetAllAlbums()
        {
            try
            {
                var albums = data.Albums.All().Select(album => new { Title = album.Title, Year = album.Year, Producer = album.Producer });

                return Request.CreateResponse(HttpStatusCode.OK, albums);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Error occured while trying to load albums");
            }
        }

        // GET albums/id/1
        public HttpResponseMessage GetAlbumById(int id)
        {
            try
            {
                var albumToGet = data.Albums.All().Where(album => album.Id == id).Select(album => new { Title = album.Title, Year = album.Year, Producer = album.Producer }).FirstOrDefault();

                if (albumToGet == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Album not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK, albumToGet);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Error occured while trying to load album.");
            }
        }

        // POST albums
        [HttpPost]
        public HttpResponseMessage AddAlbum([FromBody]Album album)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Album is not valid entity.");
                }

                var albumToAdd = new Album() { Title = album.Title, Producer = album.Producer, Year = album.Year };
                this.data.Albums.Add(albumToAdd);

                foreach (var artist in album.Artists)
                {
                    var currentArtist = new Artist() { Name = artist.Name, Country = artist.Country, DateOfBirth = artist.DateOfBirth };
                    this.data.Artists.Add(currentArtist);
                    albumToAdd.Artists.Add(currentArtist);

                    foreach (var song in artist.Songs)
                    {
                        var currentSong = new Song() { Title = song.Title, Year = song.Year, Genre = song.Genre, AlbumId = albumToAdd.Id, ArtistId = currentArtist.Id };
                        this.data.Songs.Add(currentSong);
                        currentArtist.Songs.Add(currentSong);
                    }
                }

                this.data.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Album added.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Error occured while saving album.");
            }
        }

        // PUT albums/id/1
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]string newTitle)
        {
            try
            {
                var albumToUpdate = this.data.Albums.All().Where(album => album.Id == id).FirstOrDefault();

                if (albumToUpdate == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Album not found");
                }

                albumToUpdate.Title = newTitle;
                this.data.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Album name updated");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Error occured while trying to load album.");
            }
        }

        // DELETE albums/1
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var albumToDelete = this.data.Albums.All().Where(album => album.Id == id).FirstOrDefault();

                if (albumToDelete == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Album not found");
                }

                this.data.Albums.Delete(albumToDelete);
                this.data.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Album deleted.");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Error occured while trying to load album.");
            }
        }
    }
}