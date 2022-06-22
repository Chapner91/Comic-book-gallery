using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
	public class ComicBookAverageRating
	{
		//DB Properties
		public int ComicBookAverageRatingID { get; set; }
		public int ComicBookId { get; set; }
		public decimal AverageRating { get; set; }
		public DateTime Date { get; set; }

		//Navigation Properties
		public ComicBook ComicBook { get; set; }
	}
}
