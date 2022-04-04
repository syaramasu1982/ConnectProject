Feature: EditMyEmergencyContacts
	As a user I want to launch UI Connect application
	So that I can Edit My emergency contacts

@connect-regression @editemergencycontact
Scenario Outline: Perform update emergency contact details
	Given I login as an employee
	And I click on edit my profile
	And I select  emergency contact Title as "<title>"
	And I update emergency contact first name as "<firstName>"
	And I update emergency contact last name as "<lastName>"
	And I select emergency contact relationship as "<relationship>"
	And I update emergency contact home phone as "<homePhone>"
	And I update emergency contact mobile phone as "<mobilePhone>"
	And I update emergency contact work phone as "<workPhone>"
	And I check primary contact
	And I uncheck use my address for this person
	And I can update emergency contact address line 1 as "<addressLine1>"
	And I can update emergency contact address line 2 as "<addressLine2>"
	And I can update emergency contact address line 3 as "<addressLine3>"
	And I can update emergency contact town as "<town>"
	And I select emergency contact county as "<county>"
	And I can update emergency contact post code as "<postCode>"
	Then I can save emergency contact details 

Examples:
	| title | firstName | lastName | relationship | homePhone   | mobilePhone | workPhone  | addressLine1     | addressLine2     | addressLine3     | town    | county | postCode |
	| Miss  | Indra     | Rani     | Sister       | 123458789 | 07701776 | 02098987 | 1 Chalgrove Road | 2 Chalgrove Road | 3 Chalgrove Road | Belfast | Antrim | BT1 6BD  |

@connect-regression @editemergencycontact
Scenario Outline: Perform add emergency contact details
	Given I login as an employee
	And I click on edit my profile
	And I click Add new emergency contact
	And I select  emergency contact Title as "<title>"
	And I update emergency contact first name as "<firstName>"
	And I update emergency contact last name as "<lastName>"
	And I select emergency contact relationship as "<relationship>"
	And I update emergency contact home phone as "<homePhone>"
	And I update emergency contact mobile phone as "<mobilePhone>"
	And I update emergency contact work phone as "<workPhone>"
#	And I uncheck use my address for this person
	And I can update emergency contact address line 1 as "<addressLine1>"
	And I can update emergency contact address line 2 as "<addressLine2>"
	And I can update emergency contact address line 3 as "<addressLine3>"
	And I can update emergency contact town as "<town>"
	And I select emergency contact county as "<county>"
	And I can update emergency contact post code as "<postCode>"
	Then I can save emergency contact details 

Examples:
	| title | firstName | lastName | relationship | homePhone   | mobilePhone | workPhone  | addressLine1     | addressLine2     | addressLine3     | town    | county | postCode |
	| Miss  | Indraa     | Ranii     | Sister       | 123456709 | 0770126776 | 020989987 | 1 Chalgrove Road | 2 Chalgrove Road | 3 Chalgrove Road | Belfast | Antrim | BT1 6BD  |


