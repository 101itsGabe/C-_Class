using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Objects.Models
{
    public class Announcement : Item
    {
        
        public override string ToString()
        {
           
            return $"{Name} - {Description}";

        }
    }

     
}
