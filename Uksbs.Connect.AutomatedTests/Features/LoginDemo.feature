Feature: LoginDemo 
	In order to login EBS webpage

@smoke-test
Scenario: Login to EBS application
	Given I launch ebs application
	And I enter username as "UFT_FIN"
	And I enter password as "RoeSIT2021"	
	Then I click on login button
	And I should see dashboard items in EBS

@smoke-test
Scenario Outline: Login to EBS application Pass and Fail
	Given I launch ebs application
	And I enter username as "<UserName>"
	And I enter password as "<Password>"	
	Then I click on login button
	And I should see dashboard items in EBS

Examples:
	| UserName | Password   |
	| UFT_FIN  | RoeSIT2021 |
	| UFT_HR   | RoeSIT2021 |  
