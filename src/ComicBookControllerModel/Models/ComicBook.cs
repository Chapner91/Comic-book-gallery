using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicBookControllerModel.Models
{
	[Table("ComicBook", Schema = "Data")]
	public class ComicBook
	{
		public int ComicBookID { get; set; }
		[Required]
		public string SeriesTitle { get; set; }
		public int IssueNumber { get; set; }
		public string Description { get; set; }
		public DateTime PublishedOn { get; set; }
		public decimal? AverageRating { get; set; }
	}
}
