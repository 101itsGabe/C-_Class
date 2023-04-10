using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Assignment : Item
    {
        public decimal earnedPoints { get; set; }
        public decimal totalPoints { get; set; }
        public string earnedPointsString 
        { 
            get
            { return earnedPoints.ToString(); }
            set {
                if (decimal.TryParse(value, out decimal r))
                    earnedPoints = r; 
            }
            
        }
        public DateTime dueDate { get; set; }

        public string AssignedGroup { get; set; }

        private static int lastId = 0;

        public int Id
        {
            get; private set;
        }

        public Assignment()
        {
            Id = ++lastId;
        }
        public Assignment(Assignment a)
        {
            Id = ++lastId;
            AssignedGroup = a.AssignedGroup;
            dueDate = a.dueDate;
            earnedPoints= a.earnedPoints;
            totalPoints= a.totalPoints;
        }


        public override string ToString()
        {
            return $"[{Id}] {Name} - {dueDate}";
        }
    }

}

