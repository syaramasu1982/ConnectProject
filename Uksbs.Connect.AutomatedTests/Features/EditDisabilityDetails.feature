Feature: EditDisabilityDetails
	As a user I want to launch UI Connect application
	So that I can Edit disability details

@connect-regression @editdisabilitydetails
Scenario Outline: Edit Disability Details
	Given I login as an employee
	And I click on edit my profile
	And I select disability status as "<disabilityStatus>"
	And I select reason 1 as "<reason1>"
	And I update reason other 1 as "<reasonOther1>"
	And I update special requirements 1 as "<specialRequirements1>"
	And I select reason 2 as "<reason2>"
	And I update reason other 2 as "<reasonOther2>"
	And I update special requirements 2 as "<specialRequirements2>"
	And I select reason 3 as "<reason3>"
	And I update reason other 3 as "<reasonOther3>"
	And I update special requirements 3 as "<specialRequirements3>"
	And I select grant access to manager as "<grantAccess>"
	And I select risk assessment carried out as "<riskAssessment>"
	Then I save disability details
	Then I click on logout button
	
Examples:
	| disabilityStatus | reason1 | reasonOther1 | specialRequirements1 | reason2 | reasonOther2 | specialRequirements2 | reason3 | reasonOther3 | specialRequirements3 | grantAccess | riskAssessment |
	| No               | None    | Diabetic     | test                 | None    | Diabetic     | test                 | None    | Diabetic     | test                 | Yes         | Yes            |  