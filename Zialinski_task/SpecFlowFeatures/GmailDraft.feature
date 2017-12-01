Feature: GmailDraft
	In that case I want to check Gmail Drafts

Scenario: Add Message To Drafts
	Given I have opened Gmail on Login Page and authorized with valid data. Inbox Page is opened
	When I click Compose button
	Then Opens Compose box and I input Message Subject
	When Saved label is presented
	Then I click Drafts Link
	When Draft Page is opened
	And My message is presented in Drafts
	Then Message successfully added in drafts

Scenario: Delete Message From Drafts
	Given I have opened Gmail on Login Page and authorized with valid data. Inbox Page is opened
	Then I click Drafts Link
	When Draft Page is opened
	And I choose first Draft
	Then I click Discard Drafts button
	When Count of Drafts equals count of Drafts at start minus 1
	Then Draft successfully deleted