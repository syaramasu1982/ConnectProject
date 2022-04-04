Feature: Connect Basic Checks

@smoketest
Scenario: Perform Dashboard validation
	Given I login as an employee
	Then I should see the Dashboard Items
	Then I click on logout button

@smoketest
Scenario: Perform P60 access verification
	Given I login as an employee
	Then I open most recent p60
	And I close new tab
	Then I click view all in p60
	And I open oldest p60
	Then I close new tab
	Then I click on logout button

@smoketest
Scenario: Perform Payslips access verification	
	Given I login as an employee
	Then I open most recent payslip
	And I close new tab
	Then I click view all in payslips
	And I open oldest payslip
	Then I close new tab
	Then I click on logout button

@smoketest
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
	Then I click on logout button

Examples:
	| gender | nationality | nationalitySecondary | nationalIdentity | ethnicity      | sexualOrientation        | religious |
	| Male   | TOGO        | AMERICA              | English          | Asian - Indian | Other sexual orientation | Hindu     |

@smoketest
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
	Then I click on logout button
	
Examples:
	| contactDetails | contactMethod |
	| abc@gmail.com  | Email         |  

@smoketest
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

#@smoketest
#Scenario Outline: Edit bank details
#	Given I login as an employee
#	And I click on edit my profile
#	And I select bank name as "<bankName>"
#	And I update bank barnch as "<bankBranch>"
#	And I update sort code as "<sortCode>"
#	And I update account number as "<accountNumber>"
#	And I update account name as "<accountName>"
#	And I update bulidng society number as "<buildingSocietyNumber>"
#	And I save my bank details
#	Then I click on logout button
#
#Examples:
#	| bankName | bankBranch | sortCode | accountNumber | accountName | buildingSocietyNumber |
#	| CitiBank | Swindon    | 010203   | 231029380     | MR Raman    | 343234                |

@smoketest
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
	Then I click on logout button

Examples:
	| title | firstName | lastName | relationship | homePhone   | mobilePhone | workPhone  | addressLine1     | addressLine2     | addressLine3     | town    | county | postCode |
	| Miss  | Indra     | Rani     | Sister       | 123458789 | 07701776 | 02098987 | 1 Chalgrove Road | 2 Chalgrove Road | 3 Chalgrove Road | Belfast | Antrim | BT1 6BD  |

@smoketest
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
	Then I click on logout button

Examples:
	| title | firstName | lastName | relationship | homePhone   | mobilePhone | workPhone  | addressLine1     | addressLine2     | addressLine3     | town    | county | postCode |
	| Miss  | Indraa     | Ranii     | Sister       | 123456709 | 0770126776 | 020989987 | 1 Chalgrove Road | 2 Chalgrove Road | 3 Chalgrove Road | Belfast | Antrim | BT1 6BD  |


#@regressiontest
#Scenario: Perform Future Date Validation in My Profile
#	#steps
#	Given I launch the application
#	And I enter the following details
#		| UserName  | Password   |
#		| MNORRIS12 | U4TPa55w0rd321 |
#	And I click login button
#	And I click on edit my profile
#	And I verify future date validation
#	Then I click on logout button

@smoketest
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
	| Other       | 11 Chalgrove Road |              |              | Sutton |        | SM2 5JT  |

@smoketest
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
	And I select start date as "<startDate>"
	And I click checkbox to make default address 
	And I click address save
	Then I click on logout button

Examples:
	| addressType | addressLine1      | addressLine2 | addressLine3 | town   | county | postCode | startDate    |
	| Other       | 10 Chalgrove Road |              |              | Sutton |        | SM2 5JT  | current date |

@smoketest
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
	And I select start date as "<startDate>"
	#And I click address save
	#And I go to secondary address page
	#And I remove the seondary address
	#And I click address save
	Then I click on logout button

Examples:
	| addressType | addressLine1      | addressLine2 | addressLine3 | town    | county | postCode | startDate |
	| Other       | 10 Chalgrove Road |              |              | Swindon |        | SN2 5JT  | past date |   


@smoketest
Scenario Outline: Perform add new address and start date >  effective date in my Profile
	#steps
	Given I login as an employee
	And I click on edit my profile
	And I click add new address
	And I can select address type as "<addressType>"
	And I can update address line 1 as "<addressLine1>"
	And I can update address line 2 as ""
	And I can update address line 3 as ""
	And I can update town as "<town>"
	And I can select county as ""
	And I can update postcode as "<postCode>"
	And I select start date as "<startDate>"
	And I click address save
	Then I click on logout button

Examples:
	| addressType | addressLine1     | addressLine2 | addressLine3 | town    | county | postCode | startDate   |
	| Recruiting  | 1 Chalgrove Road |              |              | Suotton |        | SM2 5JT  | future date |    

@smoketest
Scenario: Perform Feedback Verification
	#steps
	Given I login as an employee
	Then I verify Feedback message
	And I click UKSBS connect feedback
	Then I close new tab
	And I click service request feedback
	Then I close new tab
	Then I click on logout button

@smoketest
Scenario: Perform GDPR Verification
	#steps
	Given I login as an employee
	Then I click GDPR privacy
	And I verify GDPR privacy notice
	Then I click privacy notice
	And I close new tab
	Then I click GRPR privacy
	Then I click on logout button

@smoketest
Scenario: Perform Oracle Homepage Access
	#steps
	Given I login as an employee
	When I click view my responsibilities
	Then New tab will be opened
	And I verify EBS home page
	And I close new tab
	Then I click on logout button

@smoketest
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

@smoketest
Scenario: Perform Support Links Access
	#steps
	Given I login as an employee
	Then I click raise service request
	And I close new tab
	Then I click using UKSBS service
	And I close new tab
	Then I click guides to using oracle
	And I close new tab
	Then I click on logout button

@smoketest
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