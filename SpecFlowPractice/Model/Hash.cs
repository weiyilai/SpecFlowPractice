using SpecFlowPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model
{
    public class Hash : IHash
    {
        public string GetHashResult(string passwordByDao)
        {
            // 使用SHA512
            return "123456";
        }
    }
}
