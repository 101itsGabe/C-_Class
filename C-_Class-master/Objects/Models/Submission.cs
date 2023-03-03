using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public Assignment? Assignment { get; set; }

        public Course Course { get; set; }

        public Submission(int id, Assignment? assignment, Course c)
        {
            Id = id;
            Assignment = assignment;
            Course = c;
        }

        public decimal returnGrade(decimal poa)
        {//POA point on assignment from student
                return poa / Assignment.totalPoints;
        }
    }
}
