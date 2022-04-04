Feature: My Annual Leave End to End Automation


@smoketest
Scenario Outline: 01 Employee creates leave request, manager approves leave request, employee verifies the status and manager deletes approved leaves
	Given I login as an employee
	Then I should see my annual leave tile in dashboard	
	When I click on create or view leave
	Then I will be redirected to the my absences page
	When I click on create absence
	Then I see create absence window
	And I select type as "<type>"
	And I select reason as "<reason>"
	And I select start date as "<startDate>"
	And I select end date as "<endDate>"
	And I select duration as "<duration>"
	And I click submit button on create absence
	And I click on close popup button
	Then I should see the absence request details in the list as |"<type>" "<durationDays>" "<dateSubmitted>" "<statusPending>"|
	And I click on logout button

	Given I login as manager
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on notification state toaction
	Then I should see leave request details
	When I click on leave request to action as |"<leaveRequest>" "<empName>" "<action>"|
	Then I click on accept button
	And I click on close popup button
	And I click on logout button

	Given I login as an employee
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on Absence
	Then I should see my absense details
	When I click on status as "<statusApproved>"
	Then I should see the absence request details in the list as |"<type>" "<durationDays>" "<dateSubmitted>" "<statusApproved>"|
	And I should see holiday balance
	And I click on logout button
#
	Given I login as manager
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on manager absence view
	Then I should see my direct reports title
	Then I should see list of my direct reports
	And I click on my direct report as "<myDirectReport>"
	When I click on status approved
	Then I should see all my approved absences
	When I click on leave request to delete as |"<type>" "<durationDays>" "<dateSubmitted>" "<statusApproved>"|
	Then I click on delete absence button

	Examples:
	| type              | reason            | startDate    | endDate      | duration | dateSubmitted      | statusPending | leaveRequest  | empName         | action    | durationDays | statusApproved | myDirectReport  |
	| Annual Leave Days | Annual Leave Days | future date  | future date  | 0.50     | Submitted on today | Pending       | Leave Request | Everett, Robert | To action | 0.5 day      | Approved       | Everett, Robert |
	| Annual Leave Days | Annual Leave Days | past date    | past date    | 0.50     | Submitted on today | Pending       | Leave Request | Everett, Robert | To action | 0.5 day      | Approved       | Everett, Robert |
	| Sickness          | Bacterial         | current date | current date |          | Submitted on today | Pending       | Leave Request | Everett, Robert | To action | 1 day        | Approved       | Everett, Robert |  
#	| Industrial Action (Half Day) | Industrial Action | future date  | future date  | 0.50     | Submitted on today | Pending       | Leave Request | Norris, Mark | To action | 0.5 day      | Approved       | Mark Norris    |  

@smoketest
Scenario Outline: 02 Employee creates annual leave and manager declines leave request
	Given I login as an employee
	Then I should see my annual leave tile in dashboard
	When I click on i icon
	Then I should see annual leave entry from INSS and DIT
	And I close the i icon
	And I should see pie chart in my annual leave tile left side
	#And I should see number of remaining leaves in pie chart as "26.86"
	And I should see the days remaining in pie chart as "Days Remaining"	
	When I click on create or view leave
	Then I will be redirected to the my absences page
	And I click on view menu
	When I click on manager absence view
	Then I should see list of my direct reports
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	And I click on view menu
	When I click on Absence
	Then I should see my absense details
	And I should see team calendar button
	And I should see create absence button 
	And I should see holiday balance
	And I should see status details
	And I should see a list of my leaves
	When I click on create absence
	Then I see create absence window
	And I select type as "<type>"
	And I select reason as "<reason>"
	And I select start date as "<startDate>"
	And I select end date as "<endDate>"
	And I select duration as "<duration>"
	And I click submit button on create absence
	And I click on close popup button
	And I click on view menu
	When I click on Absence
	Then I should see my absense details
	Then I should see the absence request details in the list as |"<type>" "<durationDays>" "<dateSubmitted>" "<statusPending>"|
	And I click on logout button

	Given I login as manager
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on notification state toaction
	Then I should see leave request details
	When I click on leave request to action as |"<leaveRequest>" "<empName>" "<action>"|
	Then I click on decline button
	And I click on close popup button
	Then I click on logout button

	Examples:
	| type              | reason            | startDate   | endDate     | duration | dateSubmitted      | statusPending | leaveRequest  | empName         | action    | durationDays | statusApproved | myDirectReport |
	| Annual Leave Days | Annual Leave Days | future date | future date | 0.50     | Submitted on today | Pending       | Leave Request | Everett, Robert | To action | 0.5 day      | Approved       | Robert Everett |
	| Annual Leave Days | Annual Leave Days | past date   | past date   | 0.50     | Submitted on today | Pending       | Leave Request | Everett, Robert | To action | 0.5 day      | Approved       | Robert Everett |  

@smoketest
Scenario Outline: 03 Manager to create leave on employee behalf and delete
	Given I login as manager
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on manager absence view
	Then I should see my direct reports title
	Then I should see list of my direct reports
	And I click on my direct report as "<myDirectReport>"
	When I click on create absence
	Then I see create absence window
	And I select type as "<type>"
	And I select reason as "<reason>"
	And I select start date as "<startDate>"
	And I select end date as "<endDate>"
	And I select duration as "<duration>"
	And I click submit button on create absence
	And I click on close popup button
	When I click on status as "<status>"
	Then I should see the absence request details in the list as |"<type>" "<durationDays>" "<dateSubmitted>" "<status>"|
	When I click on leave request to delete as |"<type>" "<durationDays>" "<dateSubmitted>" "<status>"|
	Then I click on delete absence button
	And I click on close popup button
	And I click on logout button

Examples:
	| type               | reason            | startDate   | endDate     | duration | dateSubmitted      | durationDays | myDirectReport | status   |
	| Industrial Action  | Industrial Action | past date   | past date   | 1.00     | Submitted on today | 1 day        | Robert Everett | Taken    |
	| Special Leave Paid | Training          | future date | future date | 1.50     | Submitted on today | 1.5 days     | Robert Everett | Approved |
	| Annual Leave Days  | Annual Leave Days | future date | future date | 0.30     | Submitted on today | 0.3 day      | Robert Everett | Approved |  


@smoketest
Scenario Outline: 04 Create sick leave scenario with future date
	Given I login as an employee
	Then I should see my annual leave tile in dashboard	
	When I click on create or view leave
	Then I will be redirected to the my absences page
	When I click on create absence
	Then I see create absence window
	And I select type as "<type>"
	And I select reason as "<reason>"
	And I select start date as "<startDate>"
	And I select end date as "<endDate>"
	And I should be able to see the submit button disabled
	Then I click on logout button

Examples:
	| type     | reason | startDate   | endDate     |
	| Sickness | Asthma | future date | future date |
