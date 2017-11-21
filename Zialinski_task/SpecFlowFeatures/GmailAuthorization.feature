Feature: GmailAuthorization
	In that case I want to check different ways to authorize in GMail

Scenario Outline: Authorization With Valid Data
	Given I have entered <ValidLogin> in Login Field
	When I press Next Button
	Then Opens Password Page
	Given I have entered <ValidPassword> in Password Field
	When I press Next Button
	Then Opens Inbox Page and authorization is succeed

Examples: 
| ValidLogin    | ValidPassword  |
| test.task.zel | "Test1234Test" |