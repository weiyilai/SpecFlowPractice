using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Interface
{
    public interface IHash
    {
        string GetHashResult(string passwordByDao);
    }
}
