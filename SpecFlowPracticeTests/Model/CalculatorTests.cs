using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPractice.Model.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        /// <summary>
        /// 加法計算
        /// </summary>
        [TestMethod()]
        public void Add_Input_First_1_Second_2_Return_3()
        {
            // arrange 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式
            Calculator target = new Calculator
            {
                FirstNumber = 1,
                SecondNumber = 2
            };
            int expected = 3;

            // act 呼叫目標物件的方法
            int actual = target.Add();

            // assert 驗證是否符合預期
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 減法計算
        /// </summary>
        [TestMethod()]
        public void Subtract_Input_First_5_Second_2_Return_3()
        {
            // arrange 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式
            Calculator target = new Calculator
            {
                FirstNumber = 5,
                SecondNumber = 2
            };
            int expected = 3;

            // act 呼叫目標物件的方法
            int actual = target.Subtract();

            // assert 驗證是否符合預期
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 乘法計算
        /// </summary>
        [TestMethod()]
        public void Multiply_Input_First_5_Second_2_Return_10()
        {
            // arrange 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式
            Calculator target = new Calculator
            {
                FirstNumber = 5,
                SecondNumber = 2
            };
            int expected = 10;

            // act 呼叫目標物件的方法
            int actual = target.Multiply();

            // assert 驗證是否符合預期
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 除法計算
        /// </summary>
        [TestMethod()]
        public void Subtract_Input_First_6_Second_2_Return_3()
        {
            // arrange 初始化目標物件、相依物件、方法參數、預期結果，或是預期與相依物件的互動方式
            Calculator target = new Calculator
            {
                FirstNumber = 6,
                SecondNumber = 2
            };
            int expected = 3;

            // act 呼叫目標物件的方法
            int actual = target.Divide();

            // assert 驗證是否符合預期
            Assert.AreEqual(expected, actual);
        }
    }
}