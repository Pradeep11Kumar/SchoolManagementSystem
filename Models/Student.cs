using SchoolManagement.Controllers.BaseEntity;

namespace SchoolManagement.Models
{
    public class Student :BaseEntity
    {
        public string Name { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }

    }
}
