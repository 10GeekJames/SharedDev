
Feature: Basic Blazor Calculator Works
    As a User
    I want the basic ability
    to use the Calculator

    @Calc
    @Calculator
    @Blazor
    Scenario: I can blazor add two numbers
        Given I am on the blazor calculator page
        When I submit the calculator form using <behavior>, <number_one>, <number_two>
        Then I see <answer>
        Examples:
            | behavior | number_one | number_two | answer |
            | Add      | 1          | 1          | 2      |
            | Subtract | 1          | 2          | -1     |
            | Multiply | 3          | 2          | 6      |
            | Divide   | 6          | 3          | 2      |
            | Add      | 8          | 5          | 13     |


