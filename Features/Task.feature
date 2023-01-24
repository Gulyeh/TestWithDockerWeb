Feature: Task

@Task
Scenario: Check variant of the task, order and presence of tests and create new project and test and check if new tests exists
    Given I send a POST request to an API to generate token of variant number 2
    When I navigate to main url
    Then Projects page is opened
    
    When I pass variant token to cookies
    And I refresh page
    Then Footer contains variant number '2'

    When I click on 'Nexage' project in table
    Then Tests on the first page are ordered by descending by start date

    When I get a list of tests from project using POST API request
    Then Tests list received from API contain tests displayed on the Test Page

    When I return to previous page
    And I click on Add Button on Projects page
    And I switch tabs to the latest opened
    Then Add project page is opened

    When I enter randomly generated project name
    And I click Save Project button on Add Project Page
    Then Alert with message about successful saving appeared

    When I close currently opened tab
    And I switch to first tab
    And I refresh page
    Then Added project name has appeared on the list

    When I click on added project on the list
    And I create a new test with random test name and random method name and random env
    And I add the created test to the created project by a POST API request
    And I send POST API request with screenshot to added test
    And I send POST API request with log to added test
    Then Added test is displayed on the list 



