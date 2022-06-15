using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookControllerModel.Models
{
	[Table("Role", Schema = "DATA")]
	public class Role
	{
		public int ID { get; set; }
		
		[Required, StringLength(100)]
		public string Name { get; set; }
}
}
