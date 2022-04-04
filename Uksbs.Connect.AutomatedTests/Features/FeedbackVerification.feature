Feature: FeedbackVerification
	As a user I want to launch UI Connect application
	So that I can I can verify if the user is able to access and verify the Feedback

@connect-regression @feedbackverification
Scenario: Perform Feedback Verification
	#steps
	Given I login as an employee
	Then I verify Feedback message
	And I click UKSBS connect feedback
	Then I close new tab
	And I click service request feedback
	Then I close new tab