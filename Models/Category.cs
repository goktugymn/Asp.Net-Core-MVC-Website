using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace Article.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        
        [Required(ErrorMessage="Kategori boş bırakılamaz")]
        [StringLength(20,ErrorMessage = "Lütfen 3-20 karakter sınırını aşmayınız",MinimumLength =3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Book> Books { get; set; }
    }
}
