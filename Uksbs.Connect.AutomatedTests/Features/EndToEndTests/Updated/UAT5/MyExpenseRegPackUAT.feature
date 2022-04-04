Feature: My Expenses End to End Automation 


@smoketest
Scenario Outline: 01 Employee creates claim and assign different business allocation at claim level
	Given I login as an employee
	Then I should see my expenses tile in dashboard
	And I should see create/view expenses button	
	When I click on create or view expenses
	Then I will be redirected to my expense claims page	
	And I validate my expense claims page
	When I click on create expense claim button
	Then Expense claim setup should be displayed
	When I click on select template "<templateName>"
	Then I enter description as "<description>"
	And I click on next button
	And I click on next button
	And I click on close popup button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<amount1>"
	And I select expense type as "<type1>"
	And I enter justification as "<justification1>"
	And I click on save button
	And I click on close popup button
	And I click add button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<amount2>"
	And I select expense type as "<type2>"
	And I enter justification as "<justification2>"
	And I click on save button
	And I click on close popup button
	And I click add button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<amount3>"
	And I select expense type as "<type3>"
	And I enter justification as "<justification3>"
	And I click on save button
	And I click on close popup button
	And I click on mileage
	Then I select expense date as "<date>"
	And I select expense type as "<mileageType>"
	And I enter trip distance in miles as "<miles>"
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button
	When I click on expense allocations
	And I enter cost centre as "<costCentre>"
	And I enter programme as "<programme>"
	And I enter analysis as "<analysis1>"
	Then I click on apply all 
	And I click on close popup button
	And I refresh the page
	Then I click on view menu
	When I click on iexpenses
	Then I should see my expenses details in the list as |"<description>" "<dateSubmitted>" "<approverName>" "<claimStatus>"|
	When I click on my expense claim status as "<claimStatus>"
	Then I click on edit button
	And I click on next button
	And I click on close popup button
	When I click on three dots to expand claim
	Then I update cost centre as "<updateCostCentre>"
	And I update programme as "<updateProgramme>"
	Then I update analysis as "<updateAnalysis>"
	And I click on save button
	And I click on close popup button
	And I click on next button
	And I click on close popup button
	Then I select submit claim check box
	And I click submit button
	And I click on close popup button
	And I click on view my expenses
	And I refresh the page
	Then I click on view menu
	When I click on iexpenses
	Then I should see my expenses details in the list as |"<description>" "Submitted today" "<approverName>" "<claimStatusPending>"|
	And I click on logout button

Examples:
	| templateName    | description    | date     | amount1 | type1                              | justification1 | amount2 | type2                    | justification2 | amount3 | type3                          | justification3 | claimStatus | currency  | mileageType                 | miles | justification | costCentre | programme | analysis1 | approverName                         | updateCostCentre | updateProgramme | updateAnalysis | dateSubmitted | claimStatusPending       |
	| UK Claims       | Assign Diff BA | 11.06.21 | 7.01    | Breakfast - Early Start            | Breakfast      | 13.93   | Parking/Tolls            | Parking        | 14.00   | Lunch                          | Lunch          | Saved       |           | Private Car - Standard Rate | 10    | Mileage       | 100002     | 000001    | 00004     | Approver: Faulkner, Mr Andrew Victor | 102040           | 100180          | 00002          |               | Pending Manager Approval |
	| Overseas Claims | Assign Diff BA | 11.06.21 | 7.01    | Overseas Meals - Breakfast - Other | Breakfast      | 13.93   | Overseas Parking & Tolls | Parking        | 14.00   | Overseas Meals - Lunch - Other | Lunch          | Saved       | US Dollar | Overseas Trip - UK Mileage  | 10    | Mileage       | 100002     | 000001    | 00004     | Approver: Faulkner, Mr Andrew Victor | 102040           | 100180          | 00002          |               | Pending Manager Approval |  


@smoketest
Scenario Outline: 02 Employee submits my expenses request, Manager approves claim and employee validates approve claim notification
	Given I login as an employee
	Then I should see my expenses tile in dashboard
	And I should see create/view expenses button	
	When I click on create or view expenses
	Then I will be redirected to my expense claims page	
	And I validate my expense claims page
	When I click on create expense claim button
	Then Expense claim setup should be displayed
	When I click on select template "<templateName>"
	Then I enter description as "<description>"
	And I click on next button
	And I click on next button
	And I click on close popup button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<amount>"
	And I select expense type as "<expenseType>"
	And I click on save button
	And I click on mileage
	Then I select expense date as "<date>"
	And I select expense type as "<mileageType>"
	And I enter trip distance in miles as "<miles>"
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button
	And I click on next button
	Then I should see the error message as "<errorMessage>" 
	And I click on receipt
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button

	When I click on add attachments
	Then I enter attachmement title as "<title>"
	And I enter attachment description as "<description>"
	And I will upload expense bill		
	And I click on add button
	And I click on add button
	And I click on view
	Then I should see the bill
	And I click on close
	Then I should see number of attachments
	And I click on next button
	And I click on close popup button
	Then I select submit claim check box
	And I click submit button
	And I click on view my expenses
	And I refresh the page
	Then I click on view menu
	When I click on iexpenses
	Then I should see my expenses details in the list as |"<description>" "Submitted today" "<approverName>" "<claimStatusPending>"|
	And I click on logout button

	Given I login as manager
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on notification state toaction
	Then I should see expense details
	When I click on expense claim to action as |"Expense", "<empName>", "To action"|
	Then I enter approver comments as "Testing"
	Then I click on approve button
	And I click on logout button

	Given I login as an employee
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	And I should see the status of my expense has been approved |"Expense", "has been approved", "Faulkner, Andrew"|
	When I click on my approved expense
	Then I click on mark as read
	And I click on logout button

	Examples:
	| templateName    | description           | date     | amount | expenseType                        | justification | claimStatusPending       | currency  | mileageType                 | miles | errorMessage                      | empName         | managerName      | title      | approverName                         |
	| UK Claims       | Trip to Italy Approve | 11.06.21 | 5      | Lunch                              | Testing       | Pending Manager Approval |           | Private Car - Standard Rate | 10    | The following fields are required | Everett, Robert | Faulkner, Andrew | Automation | Approver: Faulkner, Mr Andrew Victor |
	| Overseas Claims | Trip to Italy Approve | 11.06.21 | 5      | Overseas Meals - Breakfast - Other | Testing       | Pending Manager Approval | US Dollar | Overseas Trip - UK Mileage  | 10    | The following fields are required | Everett, Robert | Faulkner, Andrew | Automation | Approver: Faulkner, Mr Andrew Victor |  

@smoketest
Scenario Outline: 03 Employee submits my expenses Manager rejects claim and employee validates rejected claim notification
	Given I login as an employee
	Then I should see my expenses tile in dashboard
	And I should see create/view expenses button	
	When I click on create or view expenses
	Then I will be redirected to my expense claims page	
	And I validate my expense claims page
	When I click on create expense claim button
	Then Expense claim setup should be displayed
	When I click on select template "<templateName>"
	Then I enter description as "<description>"
	And I click on next button
	And I click on next button
	And I click on close popup button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<amount>"
	And I select expense type as "<expenseType>"
	And I click on save button
	And I click on mileage
	Then I select expense date as "<date>"
	And I select expense type as "<mileageType>"
	And I enter trip distance in miles as "<miles>"
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button
	And I click on next button
	Then I should see the error message as "<errorMessage>" 
	And I click on receipt
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button

	When I click on add attachments
	Then I enter attachmement title as "<title>"
	And I enter attachment description as "<description>"
	And I will upload expense bill		
	And I click on add button
	And I click on add button
	And I click on view
	Then I should see the bill
	And I click on close
	Then I should see number of attachments
	And I click on next button
	And I click on close popup button
	Then I select submit claim check box
	And I click submit button
	And I click on view my expenses
	And I refresh the page
	Then I click on view menu
	When I click on iexpenses
	Then I should see my expenses details in the list as |"<description>" "Submitted today" "<approverName>" "<claimStatusPending>"|
	And I click on logout button

	Given I login as manager
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	When I click on notification state toaction
	Then I should see expense details
	When I click on expense claim to action as |"Expense", "<empName>", "To action"|
	Then I enter approver comments as "Testing"
	Then I click on reject button
	And I click on logout button

	Given I login as an employee
	Then I should see my annual leave tile in dashboard
	And I click on view menu
	When I click on notifications
	Then I should see list of notification and some filters
	And I should see the status of my expense has been rejected |"Expense", "has been rejected", "<managerName>"|
	When I click on my rejected expense
	Then I click on mark as read
	And I click on logout button

	Examples:
	| templateName    | description           | date     | amount | expenseType                        | justification | claimStatusPending       | currency  | mileageType                 | miles | errorMessage                      | empName         | managerName      | title      | approverName                         |
	| UK Claims       | Trip to Italy Rejects | 11.06.21 | 5      | Lunch                              | Testing       | Pending Manager Approval |           | Private Car - Standard Rate | 10    | The following fields are required | Everett, Robert | Faulkner, Andrew | Automation | Approver: Faulkner, Mr Andrew Victor |  
	| Overseas Claims | Trip to Italy Rejects | 11.06.21 | 5      | Overseas Meals - Breakfast - Other | Testing       | Pending Manager Approval | US Dollar | Overseas Trip - UK Mileage  | 10    | The following fields are required | Everett, Robert | Faulkner, Andrew | Automation | Approver: Faulkner, Mr Andrew Victor |  


@smoketest
Scenario Outline: 04 Employee withdraw expenses, edit withdrawn expense and delete
	Given I login as an employee
	Then I should see my expenses tile in dashboard
	And I should see create/view expenses button	
	When I click on create or view expenses
	Then I will be redirected to my expense claims page	
	And I validate my expense claims page
	When I click on create expense claim button
	Then Expense claim setup should be displayed
	#When I click on uk claims select template
	#When I click on overseas claims select template

	When I click on select template "<templateName>"
	Then I enter description as "<description>"
	And I click on next button 
	And I click on next button
	And I click on close popup button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<amount>"
	And I select expense type as "<expenseType>"
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button
	And I click on next button
	And I click on close popup button
	Then I select submit claim check box
	And I click submit button
	And I click on view my expenses
	Then I click on view menu
	When I click on iexpenses
	Then I will be redirected to my expense claims page	
	And I validate my expense claims page
	When I click on my expense claim status as "<claimStatusPending>"
	Then I click on withdraw button
	Then I should see withdraw deletion
	And I click on yes button
	And I click on close popup button
	When I click on my expense claim status as "<claimStatusWithdraw>"
	Then I click on edit button
	And I click on next button
	And I click on close popup button
	Then I select expense date as "<date>"
	And I select currency as "<currency>"
	And I enter amount as "<addAmount>"
	And I select expense type as "<addExpenseType>"
	And I enter justification as "<justification>"
	And I click on save button
	And I click on close popup button
	And I click on next button
	And I click on close popup button
	Then I select submit claim check box
	And I click submit button
	And I click on view my expenses
	And I refresh the page
	Then I click on view menu
	When I click on iexpenses
	Then I should see my expenses details in the list as |"<description>" "Submitted today" "<approverName>" "<claimStatusPending>"|

	When I click on my expense claim status as "<claimStatusPending>"
	Then I click on withdraw button
	Then I should see withdraw deletion
	And I click on yes button
	And I click on close popup button
	When I click on my expense claim status as "<claimStatusWithdraw>"
	Then I click on delete button
	Then I should see confirm deletion
	And I click on yes button
	And I click on close popup button
	And I click on logout button

	Examples:
        | templateName    | description             | date     | amount | expenseType                    | justification | claimStatusPending       | currency  | approverName                         | claimStatusWithdraw | addAmount | addExpenseType |
        | UK Claims       | Trip to London Withdraw | 11.06.21 | 5      | Lunch                          | Testing       | Pending Manager Approval |           | Approver: Faulkner, Mr Andrew Victor | Withdrawn           | 10        | Hospitality    |
        | Overseas Claims | Trip to London Withdraw | 11.06.21 | 5      | Overseas Meals - Lunch - Other | Testing       | Pending Manager Approval | US Dollar | Approver: Faulkner, Mr Andrew Victor | Withdrawn           | 10        | Hospitality    |  

