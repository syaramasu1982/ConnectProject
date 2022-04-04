Feature: OracleHomepage
	As a user I want to launch UI Connect application
	So that I can Verify Oracle Homepage access

@connect-regression @oraclehomepage
Scenario: Perform Oracle Homepage Access
	#steps
	Given I login as an employee
	When I click view my responsibilities
	Then New tab will be opened
	And I verify EBS home page
	And I close new tab