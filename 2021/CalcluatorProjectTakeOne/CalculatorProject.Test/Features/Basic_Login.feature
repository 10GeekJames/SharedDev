
Feature: Basic Site Login
    As a User
    I want the basic ability
    to use the website login features

    @G2G
    @Basic
    @Navigation
    @Login
    Scenario: I can header click to the login page
        Given I navigate to the home page
        When I click to login
        And I wait a moment
        Then I should be on the login page

    @G2G
    @Basic
    @Navigation
    @Login
    Scenario: I can login to the site
        Given I perform all login activities
        Then I should be logged in
        