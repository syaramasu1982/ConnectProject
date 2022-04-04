Feature: EditMyProfile
	As a user I want to launch UI Connect application
	So that I can Edit My Profile

#@connect-regression
#Scenario: Perform Edit My Profile
#	#steps
#	Given I launch the application
#	And I enter the following details
#		| UserName  | Password   |
#		| MNORRIS12 | CIIPproject123 |
#	And I click login button
#	Then I see my full name as "EMMA LAVERY"
#	And I see my position as "Policy Delivery"
#	And I can update title as "Miss"
#	And I can update first name as "RACHEL"
#	And I can update last name as "BEALEY"
#	And I can update marital status as "Single"
#	And I can update effective date as "02/10/2020"
#	And I click save
#	And I verify success message alert as "Successfully Updated!"

@connect-regression @editmyprofile
Scenario: Perform Future Date Validation in My Profile
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I verify future date validation
	Then I click on logout button

@connect-regression @editmyprofile
Scenario Outline: Perform address change in My Profile
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I can select address type as "<addressType>"
	And I can update address line 1 as "<addressLine1>"
	And I can update address line 2 as "<addressLine2>"
	And I can update address line 3 as "<addressLine3>"
	And I can update town as "<town>"
	And I can select county as "<county>"
	And I can update postcode as "<postCode>"
	And I click address save
	Then I click on logout button

Examples:
	| addressType | addressLine1      | addressLine2 | addressLine3 | town   | county | postCode |
	| Other       | 10 Chalgrove Road |              |              | Sutton |        | SM2 5JT  |

@connect-regression @editmyprofile
Scenario Outline: Perform Add a new address and start date = effective date in my profile
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I click add new address
	And I can select address type as "<addressType>"
	And I can update address line 1 as "<addressLine1>"
	And I can update address line 2 as "<addressLine2>"
	And I can update address line 3 as "<addressLine3>"
	And I can update town as "<town>"
	And I can select county as "<county>"
	And I can update postcode as "<postCode>"
	And I add start date as "<startDate>"
	And I click checkbox to make default address 
	And I click address save
	Then I click on logout button

Examples:
	| addressType | addressLine1      | addressLine2 | addressLine3 | town   | county | postCode | startDate    |
	| Other       | 10 Chalgrove Road |              |              | Sutton |        | SM2 5JT  | current date |

@connect-regression @editmyprofile
Scenario Outline: Perform add secondary address and start date <  effective date in my Profile
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I click add new address
	And I can select address type as "<addressType>"
	And I can update address line 1 as "<addressLine1>"
	And I can update address line 2 as "<addressLine2>"
	And I can update address line 3 as "<addressLine3>"
	And I can update town as "<town>"
	And I can select county as "<county>"
	And I add start date as "<startDate>"
	And I click address save
	And I go to secondary address page
	And I remove the seondary address
	And I click address save
	Then I click on logout button

Examples:
	| addressType | addressLine1      | addressLine2 | addressLine3 | town   | county | postCode | startDate |
	| Other       | 10 Chalgrove Road |              |              | Sutton |        | SM2 5JT  | past date |  


@connect-regression @editmyprofile
Scenario Outline: Perform add new address and start date >  effective date in my Profile
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I click add new address
	And I can select address type as "Recruiting"
	And I can update address line 1 as "1 Chalgrove Road"
	And I can update address line 2 as ""
	And I can update address line 3 as ""
	And I can update town as "Suotton"
	And I can select county as ""
	And I can update postcode as "SM2 5JT"
	And I add start date as "06/10/2020"
	And I click address save
	Then I click on logout button
