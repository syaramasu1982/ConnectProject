Feature: AccessPayslips
	As a user I want to launch UI Connect application
	I can verify if the user is able to access and verify the Payslips

@connect-regression @accesspayslips
Scenario: Perform Payslips access verification
	#steps
	Given I login as an employee
	Then I open most recent payslip
	And I close new tab
	Then I click view all in payslips
	And I open oldest payslip
	Then I close new tab