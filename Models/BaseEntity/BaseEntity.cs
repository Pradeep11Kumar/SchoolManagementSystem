using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Controllers.BaseEntity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
