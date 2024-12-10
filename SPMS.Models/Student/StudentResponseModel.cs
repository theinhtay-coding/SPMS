using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMS.Models.Student
{
    public class StudentResponseModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public int GradeId { get; set; }

        public int CurrentYearId { get; set; }

        public DateOnly EnrollmentDate { get; set; }
    }
}
