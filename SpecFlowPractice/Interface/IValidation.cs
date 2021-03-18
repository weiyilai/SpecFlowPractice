using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Interface
{
    public interface IValidation
    {
        /// <summary>
        /// 驗證
        /// </summary>
        /// <param name="id">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns>true: 通過</returns>
        bool CheckAuthentication(string id, string password);
    }
}
