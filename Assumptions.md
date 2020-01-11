# Assumptions

**Assumptions for this code**

The following assumptions have been made for this code:
- This Library will be used by another Library, which will be making a sequence of calls to my Library (method 'Bowl(int)'). 
- The sequence's length is un-known upfront, and can be changed on the fly. 
- The Bowl(int) method accepts a single integer at a time.
- The main-focus class in this Library (TenPinsGame.cs) has two constructors for different scenarios: providing input data at the time of new game creation and also if using Parser separatelly (a 3rd party parser can be used here as well, as long as it will output the integer or List of integers). This allows sending the full game input at once or entering a Kicked Pins counts one-by-one (i.e. from a console).
- To use a built-in GameParser - it's expected that each throw (kicked-pins count), in the game-input string, are separated with a "," (comma).
- Some methods could be re-used in other games, thus made as virtual.
- Only Bowl(int) method is available for public use, all other methods have either private or internal access modifiers (thus hidden from the outside public). 