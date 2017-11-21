Feature: GmailAuthorization
	In that case I want to check different ways to authorize in GMail

Scenario Outline: Authorization With Valid Data
	Given I have opened Gmail on Login Page
	When I enter <ValidLogin> in Login Field
	And I submit Login
	Then Opens Password Page
	When I have entered <ValidPassword> in Password Field
	And I submit Password
	Then Opens Inbox Page and authorization is succeed

Examples: 
	| ValidLogin    | ValidPassword  |
	| test.task.zel | 'Test1234Test' |