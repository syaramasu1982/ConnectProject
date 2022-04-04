Feature: As an employee I want to login to connect application
		 so that I can check all my employment details

@loginsuccess
Scenario: Employee Login success
	Given I login as an employee
	Then I should see the Dashboard Items
	Then I click on logout button
	Given I login as manager
	Then I should see the Dashboard Items
	Then I click on logout button

@loginsuccess
Scenario: Manager Login success
	Given I login as manager
	Then I should see the Dashboard Items
	Then I click on logout button

@loginfail
Scenario: Employee Login failure
	Given I login as an employee
	Then I should see the Dashboard Items
	Then I click on logout button

@loginfail
Scenario: Manager Login failure
	Given I login as manager
	Then I should see the Dashboard Items
	Then I click on logout button
	Then I click on logout button
