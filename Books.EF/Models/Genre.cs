using System.ComponentModel.DataAnnotations;

namespace Books.EF.Models
{
    public enum Genre
    {
        [Display(Name = "Non Fictional")]
        NonFictional,
        Romance,
        Terror,
        Comedy
    }
}