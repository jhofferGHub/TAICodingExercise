Table of Contents
1) TAI Exercise Instructions
2) Use of 3rd Party Libraries
3) Console App Usage Instructions

-------------------------------------------------------------------------


1) TAI Exercise Instructions

TAI Coding Exercise

(Please do not redistribute)
This exercise should be completed in C# and will require a copy of Visual Studio. You can download the free Community or Visual Code edition from the link below:
https://www.visualstudio.com/

Overview
The goal of this exercise is to see how candidates approach a real-life programming scenario.

You’ll be evaluated on:
Correctness – Does the code run and produce the anticipated result.
Code Quality – Quality code construction and organization. Proper use of algorithms, design patterns, code comments, and frameworks.
Implementation Time – Was the code returned to TAI within the allotted window of time.

Requirements and Assumptions
TAI is adding a new feature to the system that reports on all insureds that have a Risk Amount exceeding $300,000.
Create an application that reads in a CSV (ClientCoveragePolicy.csv located on GitHub https://github.com/eseitz/TestFiles) and writes a result CSV that reports each insured that exceeds $300,000 in risk. Please note, that an insured may have more than one policy/coverage on the ClientCoveragePolicy.csv and that you will need to calculate the combined Risk Amount across all policy/coverages for that insured.
Risk Amount per insured = Total Face Amount across all policies – Total Cash Value across all policies.
An insured is identified by having the same ID, LastName, FirstName, Gender, and DateOfBirth.
The output fields in the result CSV should include ID, Last Name, First Name, Gender, Date of Birth, and the calculated Risk Amount. The result CSV should also be sorted by Risk Amount in descending order. Dates in the result CSV should be in the “yyyy-MM-dd” format.
Additional consideration will be made for a solution that can handle large files (> 5GB).
Data validation (handling nulls, etc.) and adequate unit tests are a plus.
The use of third-party libraries is permitted, but they must be open-source or licensed under Apache License 2.0, MIT License, or similar.  If using third-party libraries, please include an explanation for its use and the benefits gained in an accompanying document. 
Please post the exercise to a personal GitHub repository for TAI to review.

2) Use of 3rd Party Libraries
Used CsvHelper (https://joshclose.github.io/CsvHelper/) for flexibility and ease of use in converting csv lines to objects.

3) App Usage Instructions/Notes
-Source Code can be found at https://github.com/jhofferGHub/TAICodingExercise.
-User will need to provide a local complete path to Input CSV file containing Insureds and Policy Info after starting the Console App.  
-User will also need to provide a local directory to save the output results to.
-It is assumed that there will be at least some value (or empty string) for every field in the Input CSV file. 
-Required field validations will be performed.  If there are any lines in the Input CSV that contain validation errors, those lines will be skipped. 
