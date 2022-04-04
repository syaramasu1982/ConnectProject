Feature: MyTeam
	I should be able to: login, and to see My Team tile. 
	And also I should  be able to change the line manager of my employee.

@connect-regression1 @myteam @boe
Scenario Outline: 01 Perform my team scenarios
	Given I login as an employee
	Then I should see my team tile
	And I should see pie chart in my team tile left side
	And I should see number of directs in pie chart as "<noInPieChart>"
	And I should see directs in pie chart as "<directsInPieChart>"
	And I should see my name in my team tile as "<myName>"
	And I should see my position in my team tile as "<myPosition>"
	And I should see my manager name in my team tile as "<myManagerName>"
	And I should see my manager position in my team tile as "<myManagerPosition>"
	When I click on the manager in my team tile right side as "<myManagerName>" 
	Then I should see manager name in my team tile back as "<myManagerName>" 
	And I should see manager position in my team tile back as "<myManagerPosition>" 
	And I should see manager email in my team tile back as "<myManagerEmail>" 
	When I click back button
	Then the tile flips back to my team tile
	When I click on view my team
	Then I will be redirected to the team view page
	And I should see title of manager in team view as "<managerTitle>"
	And I should see my manager name in team view as "<myManagerName>"
	And I should see my manager position in team view as "<myManagerPosition>"
	And I should see my manager grade in team view as "<managerGrade>"
	When I mouse over the tile that has my manager name
	Then I should see my manager email as "<myManagerEmail>"
	
	##And I should see title with my details as "My Profile"
	#When I mouse over the tile that has my user name
	#Then I should see my phone number as "Work Tel: 020 7215 1813"
	#And I should see my email as "Email: Mark.Begbie@tst1.uksbs.co.uk"
	#When I click on view profile
	#Then I will be redirected to the profile screen
	#And I should see my full name as "Mark Begbie"
	#And I should see my job description as "Operational Delivery"
	#And I should see person type as "Employee"
	##And I should see work location address as |"1 Victoria Street" "London" "SW1H 0ET" ""|
	#And I should see work email address as "Mark.Begbie@tst1.uksbs.co.uk"
	#And I should see work phone number as "020 7215 1813"
	#And I should see organisation job description as "Operational Delivery"
	#And I should see organisation location as "BEIS - 1 Victoria Street"
	#And I should see organisation department as "Manufacturing, Defence and Marine - 102056"
	#And I should see organisation department cost centre as "102056"
	#And I should see organisation grade as "BIS-G7 (New Terms).London"
	#And I should see organisation employee programme code as "100101"
	#And I should see manager tile title as "Manager"
	#And I should see manager name as "Marks Noriss"
	#And I should see manager position as "Policy Delivery"
	#And I should see number of direct reports as "Reports"
	#And I should see number of total reports as "0 directs"
	#Then I click logout icon

Examples:
	| noInPieChart | directsInPieChart | myName      | myPosition      | myManagerName    | myManagerPosition | myManagerEmail                    | managerTitle | managerGrade                        |
	| 5            | People            | Mark Norris | Policy Delivery | Keith Hodgkinson | Policy Delivery   | Keith.Hodgkinson@tst1.uksbs.co.uk | My Manager   | BIS-Senior Civil Service.Pay Band 1 |  

@connect-regression1 @myteam @boe
Scenario: 02 Perform my team scenarios with manager credentials
	Given I login as manager
	Then I should see my team tile
	And I should see pie chart in my team tile left side
	And I should see number of directs in pie chart as "5"
	And I should see directs in pie chart as "People"
	When I click navigation bullets
	Then I should see list of my team members
	When I click on one of my team member as "<teamMemberName>" 
	Then I should see team member name in my team tile back as "<teamMemberName>" 
	And I should see team member position in my team tile back as "<teamMemberPosition>" 
	And I should see team member email in my team tile back as "<teamMemberEmail>" 
	And I should see team member telephone number in my team tile back as "<teamMemberContact>" 
	When I click back button
	Then the tile flips back to my team tile


 #   #And I verify pie chart number should be equal to total list of people
	When I click on view my team
	Then I will be redirected to the team view page
	And I should see title of manager in team view as "<managerTitle>"
	And I should see my manager name in team view as "<managerName>"
	And I should see my manager position in team view as "<managerPosition>"
	And I should see my manager grade in team view as "<managerGrade>"
	#And I should see my manager telephone number as "Tel: 02072154094"
	When I mouse over the tile that has my manager name
	Then I should see my manager work telephone number as "<managerPhone>"
	And I should see my manager email as "<managerEmail>"
	When I mouse over the tile that has my direct reports as "<directReportName>"
	Then I should see my direct reports work telephone number as "<directReportPhone>"
	And I should see my direct reports email as "<directReportEmail>"
	When I click on view profile as "<directReportName>"
	Then I will be redirected to the profile screen
	And I should see full name as "<directReportName>"
	And I should see job description as "<directReportPosition>"
	And I should see person type as "<directReportType>"
	#And I should see work location address as |"Polaris House" "North Star Avenue" "Swindon" "SN2 1SZ"|
	And I should see work email address as "<directReportEmail>"
	And I should see work phone number as "<directReportPhone>"
	And I should see organisation job description as "<orgJob>"
	And I should see organisation location as "<orgLocation>"
	And I should see organisation department as "<orgDepartment>"
	And I should see organisation department cost centre as "<orgCostCentre>"
	And I should see organisation grade as "<orgGrade>"
	And I should see organisation employee programme code as "<orgProgramCode>"
	And I should see manager tile title as "Manager"
	And I should see manager name as "<myName>"
	And I should see manager position as "<managerPosition>"
	And I should see number of direct reports as "Reports"
	And I should see number of total reports as "3 directs"
	When I click on how to update organizational information’
	Then I should see dialog window as "Updating Organisational Data"
	And I close dialog window
	When I click on manager to update line manager
	#Then I should see dialog window header as "Change of Manager"
	#And I select new manager as "Claire Barcham | UKSA - Commercial - 110005 - Programme"
	#And I select effective start date as "21.10.20"
	#Then I click submit button

Examples:
	| noInPieChart | directsInPieChart | teamMemberName | teamMemberPosition | teamMemberEmail              | teamMemberContact | managerTitle | managerName     | managerPosition | managerGrade                        | managerPhone | managerEmail                     | directReportName | directReportPhone | directReportEmail            | directReportPosition | directReportType | orgJob          | orgLocation              | orgDepartment                              | orgCostCentre | orgGrade                  | orgProgramCode | myName           |
	| 5            | people            | Mark Norris    | Policy Delivery    | mark.norris@tst1.uksbs.co.uk | 0747085499        | My Manager   | Hannah Boardman | Policy Delivery | BIS-Senior Civil Service.Pay Band 2 |              | Hannah.boardman@tst1.uksbs.co.uk | Mark Norris      | 0747085499        | mark.norris@tst1.uksbs.co.uk | Policy Delivery      | Employee         | Policy Delivery | BEIS - 1 Victoria Street | Manufacturing, Defence and Marine - 102056 | 102056        | BIS-G6 (New Terms).London | 100183         | Keith Hodgkinson |

@connect-regression1 @myteam @boe
Scenario Outline: 03 Perform my team scenarios with updated employee credentials
	Given I launch the application
	And I enter the following details
		| UserName  | Password   |
		| GPRITCHA28 | CIIPproject123 |
	And I click login button
	Then I should see my team tile
	And I should see pie chart in my team tile left side
	And I should see number of directs in pie chart as "<noInPieChart>"
	And I should see directs in pie chart as "<directsInPieChart>"
	And I should see my name in my team tile as "<myName>"
	And I should see my position in my team tile as "<myPosition>"
	And I should see my manager name in my team tile as "<myManagerName>"
	And I should see my manager position in my team tile as "<myManagerPosition>"
	When I click on the manager in my team tile right side as "<myManagerName>"
	Then I should see manager name in my team tile back as "<myManagerName>" 
	And I should see manager position in my team tile back as "<myManagerPosition>" 
	And I should see manager email in my team tile back as "<myManagerEmail>" 
	When I click back button
	Then the tile flips back to my team tile

Examples:
	| noInPieChart | directsInPieChart | myName           | myPosition      | myManagerName | myManagerPosition | myManagerEmail              |
	| 2            | People            | George Pritchard | Policy Delivery | Tobias Lin    | Policy Delivery   | Tobias.Lin@tst1.uksbs.co.uk |  


@connect-regression1 @myteam @boe
Scenario Outline: 04 Perform my team scenarios with updated manager credentials
	Given I launch the application
	And I enter the following details
		| UserName  | Password   |
		| CBARCHAM33 | CIIPproject123 |
	And I click login button
	Then I should see my team tile
	When I click on view my team
	Then I will be redirected to the team view page
	And I should see title in team view as "My Direct Reports"
	When I mouse over the tile that has my direct reports as "<directReports>"
	Then I should see my direct reports work telephone number as "<directReportTelephone>"
	And I should see my direct reports email as "<directReportEmail>"
	When I click on view profile as "<directReports>"
	Then I will be redirected to the profile screen
	And I should see my full name as "<directReports>"
	And I should see my job description as "<myPosition>"
	And I should see person type as "Employee"
	And I should see work location address as |"Polaris House" "North Star Avenue" "Swindon" "SN2 1SZ"|
	And I should see work email address as "<directReportEmail>"
	And I should see work phone number as "<directReportTelephone>"
	And I should see organisation job description as "Policy Delivery"
	And I should see organisation location as "<orgLocation>"
	And I should see organisation department as "<orgDepartment>"
	And I should see organisation department cost centre as "<orgCostCentre>"
	And I should see organisation grade as "<orgGrade>"
	And I should see organisation employee programme code as "<orgProgramCode>"
	And I should see manager tile title as "Manager"
	And I should see manager name as "Claire Barcham"
	And I should see manager position as "Programme and Project Management (PPM)"
	And I should see number of direct reports as "Reports"
	And I should see number of total reports as "7 directs"
	When I click on how to update organizational information’
	Then I should see dialog window as "Updating Organisational Data"
	And I close dialog window

Examples:
	| directReports    | directReportTelephone  | directReportEmail                 | myPosition      | orgLocation   | orgDepartment                      | orgCostCentre | orgGrade                     | orgProgramCode | myName |
	| George Pritchard | Work Tel: 07795 012687 | george.pritchard@tst1.uksbs.co.uk | Policy Delivery | Polaris House | UKSA - Commercial - 110005 - Admin | 110005        | UKSA-G7 (New Terms).National |                |        |

@connect-regression1 @myteam @boe
Scenario: 05 Perform my team scenarios with updated manager credentials with future date
	Given I launch the application
	And I enter the following details
		| UserName  | Password   |
		| CBARCHAM33 | CIIPproject123 |
	And I click login button
	Then I should see my team tile
	When I click on view my team
	Then I will be redirected to the team view page
	And I should see title in team view as "My Direct Reports"
	When I mouse over the tile that has my direct reports as "<directReports>"
	Then I should see my direct reports work telephone number as "<directReportTelephone>"
	And I should see my direct reports email as "<directReportEmail>"
	When I click on view profile as "<directReports>"
	Then I will be redirected to the profile screen
	And I should see my full name as "<directReports>"
	When I click on manager to update line manager
	Then I should see dialog window header as "Change of Manager"
	And I select new manager as "Tobias Lin | UKSA - Commercial - 110005 - Programme"
	And I select effective start date as "23.10.20"
	Then I click submit button

Examples:
	| directReports    | directReportTelephone  | directReportEmail                 | 
	| George Pritchard | Work Tel: 07795 012687 | george.pritchard@tst1.uksbs.co.uk | 


@connect-regression1 @myteam @boe
Scenario: 06 Perform my team scenarios with updated employee credentials afer future date
	Given I launch the application
	And I enter the following details
		| UserName  | Password   |
		| GPRITCHA28 | CIIPproject123 |
	And I click login button
	Then I should see my team tile
	And I should see pie chart in my team tile left side
	And I should see number of directs in pie chart as "4"
	And I should see directs in pie chart as "People"
	And I should see my name in my team tile as "George Pritchard"
	And I should see my position in my team tile as "Policy Delivery"
	And I should not see my manager name in my team tile as "Tobias Lin"
	And I should see my manager position in my team tile as "Programme and Project Management (PPM)"
	When I click on the manager in my team tile right side as "Claire Barcham"
	Then I should see manager name in my team tile back as "Claire Barcham" 
	And I should see manager position in my team tile back as "Programme and Project Management (PPM)" 
	And I should see manager email in my team tile back as "claire.barcham@tst1.uksbs.co.uk" 
	When I click back button
	Then the tile flips back to my team tile

Examples:
	| myName    | myPosition  | directReportEmail                 | 
	| George Pritchard | Policy Delivery | george.pritchard@tst1.uksbs.co.uk |
