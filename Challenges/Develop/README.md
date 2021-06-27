# Develop Challenge

This challenge is to create a simple application with a very basic user interface.

## Requirements

* A console application in C#. 
* Can read the [mtcars](/mtcars.csv) dataset & display it.
* Allows editing of rows.
* Can save data back to the csv.

## Aditional
* Implement a sorting algorithm, and add an option to sort the dataset before saving
* Input Validation.

# Summary
///The file path for the csv can be changed using the constant at the top of the csvmanager class.\\\

Potential improvements:
The type of application being changed from a console application to a forms or similar application which can use interactible controls.

This change would allow the user to change the data presented to them in a much simpler and faster way than a console application allows,
	more specifically with the use of textboxes to present the data which can then detect if a value has been changed.

Additionally, I would rewite some of the code for this application to be more object oriented rather than procedural, this can be done via
	a CCar class and CSVManager class if the application type is able to handle UI events.