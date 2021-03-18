using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowPractice.Interface;
using SpecFlowPractice.Model;
using SpecFlowPracticeTests.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SpecFlowPracticeTests.Model
{
    [TestClass()]
    public class ValidationTests
    {
        private UnityContainer _unityContainer;
        IAccount _iAccount;
        IHash _iHash;

        [TestInitialize]
        public void Init()
        {
            _unityContainer = UnityConfig.RegisterComponents();

            _iAccount = _unityContainer.Resolve<IAccount>();
            _iHash = _unityContainer.Resolve<IHash>();
        }

        [TestMethod()]
        public void CheckAuthenticationTest()
        {
            // arrange
            Validation target = new Validation(_iAccount, _iHash);
            string id = "123";
            string password = "456";
            // 期望為true，因為預期hash後的結果是"123456"，而password回來的結果也是"123456"，所以為true
            bool expected = true;

            // act
            bool actual;
            actual = target.CheckAuthentication(id, password);
            
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
