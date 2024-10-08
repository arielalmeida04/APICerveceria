using System.ComponentModel.DataAnnotations;
namespace university_apibackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public string Id { get; set; } = string.Empty;  
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; } =string.Empty;
        public DateTime? UpdateUP { get; set; }
        public string DeleteBy {  get; set; } =string.Empty;
        public DateTime? DeleteUP { get; set; }
        public bool IsDeleted { get; set; } =false;
    }
}
