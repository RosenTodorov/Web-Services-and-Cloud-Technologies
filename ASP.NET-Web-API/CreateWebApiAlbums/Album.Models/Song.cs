namespace Albums.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        private ICollection<Artist> artists;

        public Song()
        {
            this.artists = new HashSet<Artist>();
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Title { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string Year { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }


        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}