Feature: My Over Time
	I should be able to: login, and perform my overtime scenarios

@connect-regressionuat @myovertime
Scenario Outline: 01 My Over Time Validations
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	And I should see create/view overtime button
	When I click on i icon on my overtime tile
	Then I should see information message
	And I close the i icon
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	When I click on create overtime button
	Then my overtime screen should be displayed
	And I select period as "<period>"
	#And I enter comments as "Automation"
	Then I select hours type as "<hoursType1>"
	And I enter overtime hours on monday as "<hours1>"
	And I click add overtime
	Then I select next row hours type as "<hoursType2>"
	And I enter next overtime hours on monday as "<hours2>"
	Then I click on save button
	And I click on close popup button
	And I should see my overtime request was added
	When I click on my overtime details icon
	Then I should see my overtime hours type as "<hoursType1>" and "<hoursType2>"
	And I should see my overtime hours as "<hours1>" and "<hours2>"

Examples:
	| period | hoursType1                   | hours1 | hoursType2                     | hours2 |
	| July   | Bank Holiday Overtime Worked | 1.30   | Bank Holiday Traveltime Worked | 1.00   | 

@connect-regressionuat @myovertime
Scenario Outline: 02 Employee updates overtime with status working and Submit
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	And I should see create/view overtime button
	When I click on i icon on my overtime tile
	Then I should see information message
	And I close the i icon
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	When I click on pencil icon
	#Then I enter comments as "Update Automation"
	Then I update hours type as "<hoursType1>"
	And I enter overtime hours on monday as "<hours1>"
	Then I update hours type as "<hoursType2>"
	And I enter overtime hours on monday as "<hours2>"
	Then I click on save button

Examples:
	 | hoursType1                   | hours1 | hoursType2                     | hours2 |
	 | Bank Holiday Overtime Worked | 1.30   | Bank Holiday Traveltime Worked | 1.00   | 

@connect-regressionuat @myovertime
Scenario: 03 Employee submits overtime with status working
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	When I click on pencil icon
	Then I tick two checkboxes
	And I click submit button
	When I click on notifications
	Then I should see list of notification and some filters

@connect-regressionuat @myovertime
Scenario: 04 Employee updates or deletes submitted overtime
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	And I should not see update icon

@connect-regressionuat @myovertime
Scenario Outline: 05 Manager approves overtime
	Given I login as manager
	Then I should see my overtime tile in dashboard
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on notification state toaction
	Then I should see leave request details
	When I click on leave request to action as |"<leaveRequest>" "<empName>" "<toAction>"|
	Then I click on accept button

Examples:
	 | leaveRequest | empName      | toAction  |
	 | Overtime     | Norris, Mark | To action |  


@connect-regressionuat @myovertime
Scenario: 06 Check employee notification
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on notification state toaction
	Then I should see leave request details
	When I click on leave request to action as |"<leaveRequest>" "<empName>" "<toAction>"|

Examples:
	 | leaveRequest | empName      | toAction  |
	 | Overtime     | Norris, Mark | To action | 

@connect-regressionuat @myovertime
Scenario: 07 Employee updates or deletes approved overtime
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	And I should not see update icon

@connect-regressionuat @myovertime
Scenario: 08 Employee creates two overtimes on same period
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	And I should see create/view overtime button
	When I click on i icon on my overtime tile
	Then I should see information message
	And I close the i icon
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	When I click on create overtime button
	Then my overtime screen should be displayed
	And I select period as "<period>"
	#And I enter comments as "Automation"
	Then I select hours type as "<hoursType>"
	And I enter overtime hours on monday as "<hours1>"
	And I click add overtime
	Then I select next row hours type as "<hoursType>"
	And I enter next overtime hours on monday as "<hours2>"
	Then I click on save button
	And I click on close popup button
	And I should see my overtime request was added
	When I click on my overtime details icon
	Then I should see my overtime hours type as "<hoursType>" and "<hoursType>"
	And I should see my overtime hours as "<hours1>" and "<hours2>"

Examples:
	| period | hoursType                    | hours1 | hours2 |
	| June   | Bank Holiday Overtime Worked | 1.30   | 1.00   |

@myovertime @boe
Scenario Outline: 10 Employee Requests Overtime and Save
	Given I login as an employee
	Then I should see my overtime tile in dashboard
	And I should see create/view overtime button
	When I click on i icon on my overtime tile
	Then I should see information message
	And I close the i icon
	When I click on create or view overtime
	Then I will be redirected to the my overtime page
	When I click on refine search criteria
	#Then The search criteria should be displayed
	When I select status as "Approved"
	And I click on search button
	#Then I should the see list of the items status as "Approved"
	When I click on clear button
	Then I should see the selected status cleared
	When I click on search button
	#Then I should see all list of my overtimes
	#When I select start date and end dates
	#Then I should see the updated list according to the selected

	When I click on create overtime button
	Then my overtime screen should be displayed
	And I select period as "<period>"
	#And I enter comments as "Automation"
	Then I select hours type as "<hoursType1>"
	And I enter overtime hours on monday as "<hours1>"
	And I click add overtime
	Then I select next row hours type as "<hoursType2>"
	And I enter next overtime hours on monday as "<hours2>"
	Then I click on save button
	And I click on close popup button
	#And I should see my overtime request was added and status as "Working"
	When I click on my overtime details icon
	Then I should see my overtime hours type as "<hoursType1>" and "<hoursType2>"
	And I should see my overtime hours as "<hours1>" and "<hours2>"

	When I click on pencil icon
	#Then I enter comments as "Update Automation"
	When I click delete icon from the existing list
	Then The row should disappear from the request "<hoursType1>"
	And I click add overtime
	Then I select next row hours type as "<hoursType1>"
	And I enter next overtime hours on monday as "<hours1>"
	#Then I should see total hours as calculated

	#Then I tick two checkboxes
	When I check the checkbox of I have read and understood my organisations overtime policy
	Then I should see submit button remains disabled
	When I check the checkbox of I confirm that I have line manager pre-approval to work overtime and budget holder approval to allow me to submit my claim
	Then I should see submit button becomes enabled
	When I uncheck the checkbox of I have read and understood my organisations overtime policy
	Then I should see submit button remains disabled
	When I check the checkbox of I have read and understood my organisations overtime policy
	Then I should see submit button becomes enabled
	And I click submit button
	Then I click on close popup button
	#Then I should see the status as "Submitted"
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on messages and select type as "Overtime"
	Then I should see overtime messages
	And I click on the last overtime notification
	Then The request details should be displayed
	When I click on overtime information
	And I click on mark as read button
	Then Overtime notification disappears from the list


	Then I update hours type as "<hoursType1>"
	And I enter overtime hours on monday as "<hours1>"
	Then I update hours type as "<hoursType2>"
	And I enter overtime hours on monday as "<hours2>"
	Then I click on save button

Examples:
	| period | hoursType1                   | hours1 | hoursType2                     | hours2 |
	| July   | Bank Holiday Overtime Worked | 1.30   | Bank Holiday Traveltime Worked | 1.00   | 
