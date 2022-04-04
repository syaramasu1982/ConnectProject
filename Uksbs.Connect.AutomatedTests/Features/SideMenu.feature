Feature: SideMenu
	As a user I want to launch UI Connect application
	So that I can Check if the user is able to open/close the side menu 
	and Check if the user is able to access all the links from the menu.

@connect-regression @sidemenu
Scenario: Perform Side Menu Validations
	#steps
	Given I login as an employee
	Then I click on view menu
	When I click on my oracle homepage
	Then New tab will be opened
	And I verify EBS home page
	And I close new tab
	Then I click on view menu
	When I click on professional qualifications
	Then New tab will be opened
	And I should see other professional qualifications from EBS
	And I close new tab
	Then I click on view menu
	When I click on iexpenses
	#Then New tab will be opened
	Then I should see expenses home from EBS
	#And I close new tab
	Then I click on view menu
	When I click on Absence
	Then I should see my absense details
	And I click on view menu
	When I click on manager absence view
	Then I should see list of my direct reports
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	And I click on view menu
	When I click on team
	Then I should see my manager and directs
	And I click on view menu
	When I click on isupport
	Then New tab will be opened
	And I should see iSupport Resources from EBS
	And I close new tab
	Then I click on logout button