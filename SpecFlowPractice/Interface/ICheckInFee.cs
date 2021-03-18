using SpecFlowPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Interface
{
    public interface ICheckInFee
    {
        /// <summary>
        /// 取得費用
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        decimal GetFee(Customer customer);
    }
}
