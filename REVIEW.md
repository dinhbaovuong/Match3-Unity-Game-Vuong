Review on project:
- Advantage: Give enough function to a simple match 3 game.
- Disadvantage:
  + The code structure is hard to read and distinguish funtions.
  + Classes have too many relationshit with each other which make it more complicated to modify.
  + Combine so many functions into a class.
  + There are still bugs.
  + ...
- Some suggestions:
  + Build the game board structure into 3 classes: Board, Cell, Item (all are monobehavior) and attach to game objects, each only handle variables and functions within that class.
  + Create some class to implement specific job like Hint to get and show hint, MatchInfo to handle match info and get point, TouchMananger to handle touch input,...
