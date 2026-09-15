using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Capdien
{
    public class CapdienVm
    {
        public int Id { get; set; }       
        public string? Tenthietbi { get; set; }      
        public string? Ghichu { get; set; }
    }
}
