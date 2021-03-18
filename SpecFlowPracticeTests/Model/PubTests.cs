using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SpecFlowPractice.Interface;
using SpecFlowPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model.Tests
{
    [TestClass()]
    public class PubTests
    {
        #region Stub 通常使用在驗證目標回傳值，以及驗證目標物件狀態的改變
        /// <summary>
        /// 驗證收費人數
        /// </summary>
        [TestMethod]
        public void Test_Charge_Customer_Count()
        {
            // arrange
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/03/19");

            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);
            target.TimeWrapper = fakeTimeWrapper;

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer { IsMale = true },
                new Customer { IsMale = false },
                new Customer { IsMale = false },
            };

            decimal expected = 1;

            // act
            var actual = target.CheckIn(customers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 驗證收費的總金額
        /// </summary>
        [TestMethod]
        public void Test_Income()
        {
            // arrange
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/03/19");

            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);

            target.TimeWrapper = fakeTimeWrapper;

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer { IsMale = true },
                new Customer { IsMale = false },
                new Customer { IsMale = false },
            };

            var inComeBeforeCheckIn = target.GetInCome();
            Assert.AreEqual(0, inComeBeforeCheckIn);

            decimal expectedIncome = 100;

            // act
            var chargeCustomerCount = target.CheckIn(customers);

            var actualIncome = target.GetInCome();

            // assert
            Assert.AreEqual(expectedIncome, actualIncome);
        }
        #endregion

        #region Mock 驗證目標物件與外部相依介面的互動方式
        /// <summary>
        /// 2男1女的測試案例中，是否只呼叫ICheckInFee介面兩次
        /// </summary>
        [TestMethod]
        public void Test_CheckIn_Charge_Only_Male()
        {
            // arrange mock
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/03/19");

            var customers = new List<Customer>();

            // 2男1女
            var customer1 = new Customer { IsMale = true };
            var customer2 = new Customer { IsMale = true };
            var customer3 = new Customer { IsMale = false };

            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);

            MockRepository mock = new MockRepository();
            ICheckInFee stubCheckInFee = mock.StrictMock<ICheckInFee>();

            using (mock.Record())
            {
                // 期望呼叫ICheckInFee的GetFee()次數為2次
                stubCheckInFee.GetFee(customer1);

                LastCall.
                    IgnoreArguments().
                    Return((decimal)100).
                    Repeat.
                    Times(2);
            }

            using (mock.Playback())
            {
                var target = new Pub(stubCheckInFee);

                target.TimeWrapper = fakeTimeWrapper;

                var count = target.CheckIn(customers);
            }
        }
        #endregion

        #region Fake 當目標物件使用到靜態方法，或.net framework本身的物件，甚至於針對一般直接相依的物件，我們都可以透過fake object的方式，直接模擬相依物件的行為。 正統作法可參考單元測試的藝術 7.5 章
        /// <summary>
        /// 只有當天為星期五，女生才免費入場
        /// </summary>
        [TestMethod]
        public void Test_Friday_Charge_Customer_Count()
        {
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/03/19");

            //arrange
            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);
            target.TimeWrapper = fakeTimeWrapper;

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer { IsMale = true },
                new Customer { IsMale = false },
                new Customer { IsMale = false },
            };

            decimal expected = 1;

            //act
            var actual = target.CheckIn(customers);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 當天為星期六，1男2女，收費人數為3人
        /// </summary>
        [TestMethod]
        public void Test_Saturday_Charge_Customer_Count()
        {
            //arrange
            var fakeTimeWrapper = new FakeTimeWrapper();
            fakeTimeWrapper.MockTime = Convert.ToDateTime("2021/03/20");

            ICheckInFee stubCheckInFee = MockRepository.GenerateStub<ICheckInFee>();
            Pub target = new Pub(stubCheckInFee);

            stubCheckInFee.Stub(x => x.GetFee(Arg<Customer>.Is.Anything)).Return(100);

            var customers = new List<Customer>
            {
                new Customer { IsMale = true },
                new Customer { IsMale = false },
                new Customer { IsMale = false },
            };

            decimal expected = 3;

            //act
            var actual = target.CheckIn(customers);

            //assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }

    /// <summary>
    /// Fake
    /// </summary>
    public class FakeTimeWrapper : ITimeWrapper
    {
        internal DateTime MockTime;
        public DateTime Now => MockTime;
    }
}