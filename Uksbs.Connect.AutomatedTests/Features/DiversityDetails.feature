Feature: DiversityDetails
	As a user I want to launch UI Connect application
	So that I can Edit My bank details

@connect-regression @diversitydetails
Scenario Outline: Edit Diversity Details
	Given I login as an employee
	And I click on edit my profile
#	And I select Gender as "<gender>"
	And I select nationality as "<nationality>"
	And I select nationality secondary as "<nationalitySecondary>"
	And I select national identity as "<nationalIdentity>"
	And I select ethnicity as "<ethnicity>"
	And I select sexual orientation as "<sexualOrientation>"
	And I select religious belieft as "<religious>"
	Then I save diversity details

Examples:
	| gender | nationality | nationalitySecondary | nationalIdentity | ethnicity      | sexualOrientation        | religious |
	| Male   | TOGO        | AMERICA              | English          | Asian - Indian | Other sexual orientation | Hindu     |