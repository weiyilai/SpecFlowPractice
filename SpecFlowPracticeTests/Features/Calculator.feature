Feature: Calculator
	Simple calculator for adding two numbers

@mytag
Scenario: Add Two Numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 70
	And the second number is 50
	When the two numbers are subtract
	Then the result should be 20

Scenario: Multiply two numbers
	Given the first number is 7
	And the second number is 5
	When the two numbers are multiply
	Then the result should be 35

Scenario: Divide two numbers
	Given the first number is 70
	And the second number is 10
	When the two numbers are divide
	Then the result should be 7