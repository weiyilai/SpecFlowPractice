using SpecFlowPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model
{
    public class Pub
    {
        private readonly ICheckInFee _checkInFee;
        private decimal _inCome = 0;
        internal ITimeWrapper TimeWrapper = new TimeWrapper();

        public Pub(ICheckInFee checkInFee)
        {
            _checkInFee = checkInFee;
        }

        /// <summary>
        /// 入場
        /// </summary>
        /// <param name="customers"></param>
        /// <returns>收費的人數</returns>
        public int CheckIn(List<Customer> customers)
        {
            var result = 0;

            foreach (var customer in customers)
            {
                var isFemale = !customer.IsMale;
                // for fake
                var isLadyNight = TimeWrapper.Now.DayOfWeek == DayOfWeek.Friday;

                // 女生免費入場
                if (isLadyNight && isFemale)
                {
                    continue;
                }
                else
                {
                    // for stub, validate status: income value
                    // for mock, validate only male
                    _inCome += _checkInFee.GetFee(customer);

                    result++;
                }
            }

            // for stub, validate return value
            return result;
        }

        public decimal GetInCome()
        {
            return _inCome;
        }
    }
}
