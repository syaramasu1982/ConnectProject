Feature: EditMyBankDetails
	As a user I want to launch UI Connect application
	So that I can Edit My bank details

@connect-regression @editbankdetails
Scenario Outline: Edit bank details
	Given I login as an employee
	And I click on edit my profile
	And I select bank name as "<bankName>"
	And I update bank barnch as "<bankBranch>"
	And I update sort code as "<sortCode>"
	And I update account number as "<accountNumber>"
	And I update account name as "<accountName>"
	And I update bulidng society number as "<buildingSocietyNumber>"
	And I save my bank details
	Then I click on logout button

Examples:
	| bankName | bankBranch | sortCode | accountNumber | accountName | buildingSocietyNumber |
	| CitiBank | Swindon    | 010203   | 231029380     | MR Raman    | 343234                |