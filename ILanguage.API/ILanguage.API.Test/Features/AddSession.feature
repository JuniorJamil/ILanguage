Feature: AddSession
	In order to get a new diet
	As a customer user
	I want to see all the sessions of one nutricionist

@Sessions
Scenario: Add a id of the nutricionist to search
	Given The user enter 1 like id of the nutricionist
	When the user enter to search
	Then the result should be a list of the sessions that the nutricionist have available