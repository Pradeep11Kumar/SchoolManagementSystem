using SchoolManagement.Controllers.BaseEntity;

namespace SchoolManagement.Models
{
    public class Mark :BaseEntity
    {   
        public int StudentId { get; set; }
        public Student Student { get; set; }      
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public decimal ObtainedMarks { get; set; }
        public int TotalMarks { get; set; }

    }
}
