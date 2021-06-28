
Feature: Basic Calculator Works
    As a User
    I want the basic ability
    to use the Calculator

    @Calc
    @Calculator
    Scenario: I can add two numbers
        Given I have a calculator
        When I add <number_one> plus <number_two>
        Then I get <answer>
        Examples:
            | number_one | number_two | answer |
            | 1          | 1          | 2      |
            | 1          | 2          | 3      |
            | 3          | 2          | 5      |
            | 5          | 3          | 8      |
            | 8          | 5          | 13     |

