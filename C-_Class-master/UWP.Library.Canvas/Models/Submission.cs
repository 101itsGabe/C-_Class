using Objects.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UWP.Library.Canvas.Models
{
    public class Submission
    {
        private static int lastId = 0;
        public int Id
        {
            get; private set;
        }

        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public string Content { get; set; }

        public decimal Grade { get; set; }
        public string GradeString 
        { 
            get { return Grade.ToString(); }
            set
            {
                if (decimal.TryParse(GradeString, out decimal g))
                    Grade = g;
            }
        }
        

        public Submission()
        {
            Id = ++lastId;
            Content = string.Empty;
            Grade = 0;
        }

        public override string ToString()
        {
            return $"[{Id}] ({Grade}) {Student.Name}: {Assignment.Name}";
        }
    }
}
