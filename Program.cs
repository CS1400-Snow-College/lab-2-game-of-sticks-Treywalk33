//[X]Explain the rules of the game of sticks: players will take turns choosing at least 1 and no more than 3 of the remaining sticks until the sticks are gone.  The player that takes the last stick loses.
//[X]Set the number of sticks left to 20.
//[X]Set the maximum number of sticks that can be taken to be equal to 3.
//[X]If the number of sticks left is less than 3, then set the maximum number of sticks that can be taken to be equal to the number of sticks left.
//[X]Ask the current player to choose a number of sticks between 1 and the maximum number of sticks that can be taken on this turn.
//[X]If the number of sticks chosen is not in the allowed range, print an error message and then go back to step 6; otherwise go on to step 8.
//[X]Decrease the number of sticks by the number of sticks chosen.
//[X]If the current player is player 1, set current player to be player 2; otherwise set current player to be player 1.
//[X]If the number of sticks left is equal to 0, then print that the current player won; otherwise, go back to step 4.


using System;

class Program
{
    static void Main(string[] args)
    {
        int totalSticks = 20; //set the number of sticks
        int currentPlayer = 1; //start with player 1
        int maxSticksToTake = 3; //maximum sticks that can be taken

        Console.WriteLine("Game of Sticks: Players take turns to take sticks. The player who takes the last stick loses.");

        while (totalSticks > 0)
        {
            //determine the maximum number of sticks that can be taken
            if (totalSticks < maxSticksToTake)
            {
                maxSticksToTake = totalSticks; //set to the remaining sticks
            }

            //ask the current player to choose the number of sticks
            Console.WriteLine($"Player {currentPlayer}, there are {totalSticks} sticks left. You can take 1 to {maxSticksToTake} sticks.");
            int sticksChosen = GetValidSticksChosen(maxSticksToTake);

            //decrease the number of sticks
            totalSticks -= sticksChosen;

            //check if the current player has lost
            if (totalSticks == 0)
            {
                Console.WriteLine($"Player {currentPlayer} took the last stick and lost the game!");
                break; //end the game
            }

            //switch players
            currentPlayer = (currentPlayer == 1) ? 2 : 1; //toggle between player 1 and player 2
        }
    }

    static int GetValidSticksChosen(int maxSticks)
    {
        int sticks;
        while (true)
        {
            //get user input
            string input = Console.ReadLine();

            //try to parse the input
            if (int.TryParse(input, out sticks))
            {
                //validate the range of chosen sticks
                if (sticks >= 1 && sticks <= maxSticks)
                {
                    return sticks; // Valid input
                }
            }
            //if input is invalid, print error message and prompt again
            Console.WriteLine($"Invalid input. Please choose a number between 1 and {maxSticks}.");
        }
    }
}