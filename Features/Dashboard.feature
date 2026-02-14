
Feature: Test1

#@env:qa @site:SiteA @role:admin
#Scenario: Admin accesses dashboard
#  Given I open dashboard
#  Then I should see admin widgets


@env:qa @site:SiteA @role:admin
Scenario: Admin accesses PIM
  Given I open dashboard
  When clik on PIM link
  Then user navigates to PIM page

@env:qa @site:SiteA @role:admin
Scenario: Admin accesses 
  Given I open dashboard
  When click on "Admin" menu on dashboard
  Then Verify success full navigation to admin page



@env:qa @site:SiteA @role:admin
Scenario: Admin Access User Table
  Given I open dashboard
  When click on "Admin" menu on dashboard
  Then Verify success full navigation to admin page
  When User get the username from table  