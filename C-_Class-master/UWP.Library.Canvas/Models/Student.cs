using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UWP.Library.Canvas.DTO;
using UWP.Library.Canvas.Models;

namespace Objects.Models
{
    public class Student : Person
    {
        public PersonClassification Classification { get; set; }
        public Dictionary<string, List<Submission>> Grades { get; set; }
        public Dictionary<string, decimal> CourseGrade { get; set; }
        public List<Course> Courses { get; set; }


        public Student()
        {
            Grades = new Dictionary<string, List<Submission>>();
            Courses = new List<Course>();
            CourseGrade = new Dictionary<string, decimal>();

        }

        public Student(PersonDTO dto)
        {
            Id= dto.Id;
            Name= dto.Name;
        }

        public Student(Person p)
        {
            Name= p.Name;
            Id = p.Id;
            Grades = new Dictionary<string, List<Submission>>();
            Courses = new List<Course>();
            CourseGrade = new Dictionary<string, decimal>();
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }

        public decimal CalculateGrade(Course c)
        {
            Grades.TryGetValue(c.classCode, out List<Submission> subs);
            decimal final = 0;
            List<decimal> points = new List<decimal>();
           

            foreach(var g in c.AssignmentGroups)
            {
                decimal ep = 0;
                decimal tp = 0;
                string curGroup = string.Empty;
                bool change;
                foreach(var s in subs)
                {
                    change = false;
                    if (g.Name == s.Assignment.AssignedGroup)
                    {
                        ep += s.Grade;
                        curGroup= s.Assignment.AssignedGroup;
                        change = true;
                    }
                    if (s.Assignment.AssignedGroup != curGroup && !change || subs.LastOrDefault() == s)
                    {
                         subs.ForEach(curSub => { if (curSub.Assignment.AssignedGroup == curGroup) { tp += curSub.Assignment.totalPoints; } });
                        if(tp != 0)
                         points.Add(((ep / tp) * (g.weight / 100)));
                         change = false;
                        curGroup = string.Empty;
                    }
                }
               
            }

            points.ForEach(p => final += p);


            return final * 100;
        }
        
    }
}

public enum PersonClassification
{
    Freshman = 0,
    Sophmore = 1,
    Junior = 2,
    Senior = 3
}



