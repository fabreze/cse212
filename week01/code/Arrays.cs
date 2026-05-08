using System.Data;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        List<double> dynamicArray = new(); // Create an empty dynamic array
        for (int i = 1; i <= length; i++) // Starting at 1, multiply i by the number to get the multiples of it and add it to the list
        {
            double multiple = number * i;
            dynamicArray.Add(multiple);
        }

        double[] results = dynamicArray.ToArray();//convert the list to a fixed array
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Create an new empty list
        List<int> results = new();

        //Check if the amount is equal to the size of the list or zero
        if (data.Count == amount || amount == 0)
        {
            return; //Stop execution as no changes need to be made
        }
        else
        {
            //Create an integer that is the index from where the list will be sliced
            int index = data.Count - amount;
            //Create an array from the first half of the list
            List<int> firstHalf = data.GetRange(0, index);
            //Create an array from the second half of the list
            List<int> secondHalf = data.GetRange(index, amount);

            //Clear the data list
            data.Clear();

            //Add both ranges
            data.AddRange(secondHalf);
            data.AddRange(firstHalf);
        }
    }
}
