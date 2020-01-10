# Assumptions

** Assumptions for this code **

The following assumptions have been made for this code:
- This Library will be used by another Library, which will be making a sequence of calls to my Library (method 'Bowl(int)'). 
- The sequence's length is un-known upfront, and can be changed on the fly. 
- The Bowl(int) method accepts a single integer at the time.
- The main focus class in this Library (TenPinsGame.cs) has two constructors for different scenarios: providing input data at the time of new game creation and and also if using GameParser.cs separatelly. This allows sending the full game at once or entering a Kicked Pins counts one-by-one (i.e. from console).
- Some methods could be re-used in other games, thus made as virtual.
- Only Bowl(int) method is available for public use, all other methods have either private or internal access modifiers (thus hiddne from the outside public). 

