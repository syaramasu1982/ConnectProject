Feature: SupportLinks
	As a user I want to launch UI Connect application
	So that I can Verify Support Links access

@connect-regression @supportlinks
Scenario: Perform Support Links Access
	#steps
	Given I login as an employee
	Then I click raise service request
	And I close new tab
	Then I click using UKSBS service
	And I close new tab
	Then I click guides to using oracle
	And I close new tab
	Then I click on logout button