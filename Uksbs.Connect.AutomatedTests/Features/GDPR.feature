Feature: GDPRVerification
	As a user I want to launch UI Connect application
	So that I can validate the items in Dashboard

@connect-regression @gdpr
Scenario: Perform GDPR Verification
	#steps
	Given I login as an employee
	Then I click GDPR privacy
	And I verify GDPR privacy notice
	Then I click privacy notice
	And I close new tab
	Then I click GRPR privacy