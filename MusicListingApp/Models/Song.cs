using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicListingApp.Models
{
    public class Song
    {
        public int SongId { get; set; }

        public string SongName { get; set; }

        public string Artist { get; set; }

        public string ReleaseDate { get; set; }

        public string Genre { get; set; }

    }
}
