Feature: GmailFailCheck
	In that case I want to check test fail

Scenario Outline: Fail Check
	Given I have opened Gmail on Login Page
	When I enter <InvalidLogin> in Login Field
	And I submit Login
	Then Authorization is unsucceed, but fails
	
Examples: 
	| InvalidLogin     | 
	| test.invalid.zel |