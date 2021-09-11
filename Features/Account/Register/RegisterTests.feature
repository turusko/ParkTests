@Registration
Feature: RegisterTests


Scenario: User gives password with less than 8 characters gets warning
	When the user provides a password "abcd"
	Then error appears with the text "The password does not meet the correct format."
	And password requirement "Have at least 8 characters" is not ticked
	And password requirement "Include an uppercase letter" is not ticked
	And password requirement "Include a lowercase letter" is ticked
	And password requirement "Include a number" is not ticked


Scenario: User gives password with equal to 8 characters all lower case
	When the user provides a password "abcdefgh"
	Then error appears with the text "The password does not meet the correct format."
	And password requirement "Have at least 8 characters" is ticked
	And password requirement "Include an uppercase letter" is not ticked
	And password requirement "Include a lowercase letter" is ticked
	And password requirement "Include a number" is not ticked

Scenario: User gives password with equal to 8 characters lower and upper case
	When the user provides a password "abcdefGH"
	Then error appears with the text "The password does not meet the correct format."
	And password requirement "Have at least 8 characters" is ticked
	And password requirement "Include an uppercase letter" is ticked
	And password requirement "Include a lowercase letter" is ticked
	And password requirement "Include a number" is not ticked

Scenario: User gives password with equal to 8 characters lower and a number
	When the user provides a password "abcdefgh1"
	Then error appears with the text "The password does not meet the correct format."
	And password requirement "Have at least 8 characters" is ticked
	And password requirement "Include an uppercase letter" is not ticked
	And password requirement "Include a lowercase letter" is ticked
	And password requirement "Include a number" is ticked

Scenario: User gives password with equal to 8 characters upper and a number
	When the user provides a password "ABCDEFGH1"
	Then error appears with the text "The password does not meet the correct format."
	And password requirement "Have at least 8 characters" is ticked
	And password requirement "Include an uppercase letter" is ticked
	And password requirement "Include a lowercase letter" is not ticked
	And password requirement "Include a number" is ticked

Scenario: User can update password making it valid
	When the user provides a password "ABCDEFGH1"
	And error appears with the text "The password does not meet the correct format."
	And the user provides a password "ABCaEFGH1"
	Then error with the text "Password its required" disappears
	And password requirement "Have at least 8 characters" is ticked
	And password requirement "Include an uppercase letter" is ticked
	And password requirement "Include a lowercase letter" is ticked
	And password requirement "Include a number" is ticked

Scenario: User enters no details and press next getting validation errors
	When user select Next 
	Then error appears with the text "Mobile number is required"
	And error appears with the text "Email address is required"
	And error appears with the text "Password is required"

Scenario: User can correct validation issues and error messages dissapear
	Given User select next
	And error appears with the text "Mobile number is required"
	And error appears with the text "Email address is required"
	And error appears with the text "Password is required"
	When the user provides a password "Password123"
	And the user provides mobile number "07891662241"
	And the user provides email address "Test123@email.com"
	And user select Next
	Then error with the text "Mobile number is required" disappears
	And error with the text "Email address is required" disappears
	And error with the text "Password its required" disappears