using SpecFlowPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model
{
    public class Account : IAccount
    {
        public string GetPassword(string id)
        {
            return "123456";
        }
    }
}
