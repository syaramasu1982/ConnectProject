Feature: AccessP60s
	As a user I want to launch UI Connect application
	I can verify if the user is able to access and verify the P60s

@connect-regression @accessp60
Scenario: Perform P60 access verification
	#steps
	Given I login as an employee
	Then I open most recent p60
	And I close new tab
	Then I click view all in p60
	And I open oldest p60
	Then I close new tab