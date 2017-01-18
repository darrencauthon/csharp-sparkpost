Feature: Message Events

Background:
	Given my api key is 'yyy'

Scenario: Samples
	When I ask for samples of 'bounce'
	Then it should return a 200