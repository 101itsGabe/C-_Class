using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Models
{
    public class Module : Item
    {
        public List<ContentItem> ContentItems { get; set; }
        public Module() 
        {
            ContentItems = new List<ContentItem>();
        }

    }
}
