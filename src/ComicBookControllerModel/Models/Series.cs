using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookControllerModel.Models
{
	[Table("Series", Schema = "DATA")]
	public class Series
	{
		
		public Series()
		{
			ComicBooks = new List<ComicBook>();
		}

		public int SeriesID { get; set; }
		[Required, StringLength(100)]
		public string Title { get; set; }
		public string Discription { get; set; }

		public ICollection<ComicBook> ComicBooks { get; set; }
	}
}
