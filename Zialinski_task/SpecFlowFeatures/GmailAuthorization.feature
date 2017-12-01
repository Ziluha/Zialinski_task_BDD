Feature: GmailAuthorization
	In that case I want to check different ways to authorize in GMail

Scenario Outline: Authorization With Valid Data
	Given I have opened Gmail on Login Page
	When I enter <ValidLogin> in Login Field
	And I submit Login
	Then Opens Password Page
	When I enter <ValidPassword> in Password Field
	And I submit Password
	Then Opens Inbox Page and authorization is succeed

Examples: 
	| ValidLogin    | ValidPassword  |
	| test.task.zel | 'Test1234Test' |

Scenario Outline: Authorization With Invalid Login
	Given I have opened Gmail on Login Page
	When I enter <InvalidLogin> in Login Field
	And I submit Login
	Then Authorization is unsucceed, because Login in invalid

Examples: 
	| InvalidLogin     | 
	| test.invalid.zel |

Scenario Outline: Authorization With Invalid Password
	Given I have opened Gmail on Login Page
	When I enter <ValidLogin> in Login Field
	And I submit Login
	Then Opens Password Page
	When I enter <InvalidPassword> in Password Field
	And I submit Password
	Then Authorization is unsucceed, because Password is invalid

Examples: 
	| ValidLogin    | InvalidPassword |
	| test.task.zel | 'Test1234Inv'   |