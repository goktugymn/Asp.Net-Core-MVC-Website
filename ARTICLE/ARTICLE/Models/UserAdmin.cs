using System.ComponentModel.DataAnnotations;

namespace ARTICLE.Models
{
	public class UserAdmin
	{
		[Key]
		public int AdminID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string AdminRole { get; set; }
	}
}
