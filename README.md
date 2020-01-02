# DeveloperEvaluationProject-2
Hdcp score

##

Please create a library in either C# or JavaScript to score a game of Ten-Pin Bowling.

**Input:** A series of calls to a Bowl(int) method passing an integer indicating the number of pins knocked down by a bowl in a game

**Output:** integer current score of the game, only the fully resolved frames are included in the score


**---**

**The scoring rules**

Each game, or "line" of bowling, includes ten turns, or "frames" for the bowler.

In each frame, the bowler gets up to two tries to knock down all ten pins.

If the first ball in a frame knocks down all ten pins, this is called a "strike". The frame is over. The score

for the frame is ten plus the total of the pins knocked down in the next two balls.

If the second ball in a frame knocks down all ten pins, this is called a "spare". The frame is over. The score for the frame is ten plus the number of pins knocked down in the next ball.

If, after both balls, there is still at least one of the ten pins standing the score for that frame is simply
the total number of pins knocked down in those two balls.

If you get a spare in the last (10th) frame you get one more bonus ball. If you get a strike in the last (10th) frame you get two more bonus balls.

These bonus throws are taken as part of the same turn. If a bonus ball knocks down all the pins, the process does not repeat. The bonus balls are only used to calculate the score of the final frame.

The game score is the total of all frame scores.

--------------------------------------------------------------------------------

**Examples**

n indicates the integer value passed to the Bowl(int) method

n, n, n a series of calls to the Bowl method

------------------------------

First Frame Incomplete

Input: 1

Score: 0

-------------------------------

First Frame Compete

Input: 1, 1

Score: 2

-------------------------------

Second Frame Incomplete

Input: 1, 1, 5

Score: 2

--------------------------------

Two Strikes

Input: 10, 10

Score: 0

--------------------------------


Three Strikes

Input: 10, 10, 10

Score: 30

--------------------------------


Three Strikes and a miss

Input: 10, 10, 10, 0

Score: 50

--------------------------------


Complete game

Input: 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1

Score == 167

--------------------------------


For additional illustration see https://bowlinggenius.com/ this calculator updates the “Hdcp score” using the same rules we would like to use in this library.
