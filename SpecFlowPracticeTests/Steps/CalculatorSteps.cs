using FluentAssertions;
using SpecFlowPractice.Model;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowPracticeTests.Steps
{
    [Binding]
    public sealed class CalculatorSteps
    {
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        private ScenarioContext _scenarioContext;
        public CalculatorSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int first)
        {
            _calculator.FirstNumber = first;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int second)
        {
            _calculator.SecondNumber = second;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [When(@"the two numbers are subtract")]
        public void WhenTheTwoNumbersAreSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"the two numbers are multiply")]
        public void WhenTheTwoNumbersAreMultiply()
        {
            _result = _calculator.Multiply();
        }

        [When(@"the two numbers are divide")]
        public void WhenTheTwoNumbersAreDivide()
        {
            _result = _calculator.Divide();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }
    }
}
