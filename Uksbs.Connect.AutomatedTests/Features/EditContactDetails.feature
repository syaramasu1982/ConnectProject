Feature: EditContactDetails
	As a user I want to launch UI Connect application
	So that I can Edit My Profile

@connect-regression @editcontactdetails
Scenario Outline: Perform add contact details
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I click add new contact details
	And I enter contact details as "<contactDetails>"
	And I select contact method as "<contactMethod>"
	Then I click save button
	And I delete the contact details
	Then I click save button
	
Examples:
	| contactDetails | contactMethod |
	| abc@gmail.com  | Email         |  