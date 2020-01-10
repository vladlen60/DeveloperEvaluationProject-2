# Assumptions

** Assumptions for this code **

The following assumptions have been made for this code:
- This Library will be used by another Library, which will be making a sequence of calls to my Library (method 'Bowl(int)'). 
- The sequence's length is un-known upfront, and can be changed on the fly. 
- The Bowl(int) method accepts a single integer at the time.
- Main class in this Library (TenPinsGame.cs) has two constructors for different scenarios: providing input data at the time of instantiation and and also if using GameParser.cs separatelly.
