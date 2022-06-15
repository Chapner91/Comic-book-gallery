using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookControllerModel.Models
{
	[Table("Artist", Schema ="DATA")]
	public class Artist
	{
		public int ArtistID { get; set; }
		[Required, StringLength(100)]
		public string Name { get; set; }

		public ICollection<ComicBookArtist> ComicBooks { get; set; }

		public Artist()
		{
			ComicBooks = new List<ComicBookArtist>();
		}
	}
}
