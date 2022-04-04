Feature: ViewMyProfile
	As a user I want to launch UI Connect application
	So that I can View My Profile

@connect-regression @viewprofile
Scenario Outline: Perform View My Profile
	#steps
	Given I login as an employee
	Then I see my full name as "<fullName>"
	And I see my position as "<position>"
	And I click on view profile
	Then I see marital status as "<maritalStatus>"
	And I see ni number as "<niNumber>"
	And I see dob as "<DOB>"
	And I see employee no as "<empNo>"
	And I see cost center code as "<costCenterCode>"
	And I see line manager as "<lineManager>"
	And I click on back
	Then I click on logout button

Examples:
	| fullName    | position        | maritalStatus             | niNumber  | DOB         | empNo    | costCenterCode | lineManager         |
	| MARK NORRIS | Policy Delivery | Married/Civil Partnership | NH006561D | 04 JUL 1965 | 15030311 | 102056         | Mr Keith Hodgkinson |

	#Then I check my username and position
	#	| FullName  | Position   |
	#	| EMMA LAVERY | Policy Delivery |

	#And I click on view profile
	#Then I see profile information
	#| MaritalStatus            | NINumber | DOB         | EmployeeNo | CostCentreCode | LineManager    |
	#| Married/Civil Partnership | JT449492A | 09 OCT 1978 | 15033413    | 100241           | Ms Clare Dobson |
	