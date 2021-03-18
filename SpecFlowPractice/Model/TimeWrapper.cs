using SpecFlowPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model
{
    public class TimeWrapper : ITimeWrapper
    {
        public DateTime Now => DateTime.Now;
    }
}
