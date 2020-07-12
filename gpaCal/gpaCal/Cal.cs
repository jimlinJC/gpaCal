using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpaCal
{
    class Cal
    {
     public double gpa { get; set; }
     public int credit { get; set; }
     public double total
        {
            get { return this.gpa * this.credit; }
        }
            

     
    }
}
