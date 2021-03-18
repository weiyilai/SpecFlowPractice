using SpecFlowPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model
{
    public class Validation : IValidation
    {
        private IAccount _account;
        private IHash _hash;

        public Validation(IAccount account, IHash hash)
        {
            _account = account;
            _hash = hash;
        }

        public bool CheckAuthentication(string id, string password)
        {
            if (_account == null)
            {
                throw new ArgumentNullException();
            }

            if (_hash == null)
            {
                throw new ArgumentNullException();
            }

            // 取得資料中，id對應的密碼                       
            var passwordBy = this._account.GetPassword(id);

            // 針對傳入的password，進行hash運算
            var hashResult = this._hash.GetHashResult(password);

            // 比對hash後的密碼，與資料中的密碼是否吻合
            return passwordBy == hashResult;
        }
    }
}
