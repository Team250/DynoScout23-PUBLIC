using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Falcon_Scouting_Software_2014
{
    public static class GlobalMethods
    {
        //Methods that increases a value in an array by a specified value
        public static void increase(int[] arrayToIncrement, int arrayIndex, int amountToIncreaseBy)
        {
            arrayToIncrement[arrayIndex] = (arrayToIncrement[arrayIndex] + amountToIncreaseBy);
        }

        public static void increase(int[,] arrayToIncrement, int arrayFirstIndex, int arraySecondIndex, int amountToIncreaseBy)
        {
            arrayToIncrement[arrayFirstIndex, arraySecondIndex] = (arrayToIncrement[arrayFirstIndex, arraySecondIndex] + amountToIncreaseBy);
        }

        public static void increase(int[] arrayToIncrement, int[] displayToIncriment, int arrayIndex, int amountToIncreaseBy)
        {
            increase(arrayToIncrement, arrayIndex, amountToIncreaseBy);
            displayToIncriment[arrayIndex] = arrayToIncrement[arrayIndex];
        }

        public static void increase(int[,] arrayToIncrement, int[,] displayToIncriment, int arrayFirstIndex, int arraySecondIndex, int amountToIncreaseBy)
        {
            increase(arrayToIncrement, arrayFirstIndex, arraySecondIndex, amountToIncreaseBy);
            displayToIncriment[arrayFirstIndex, arraySecondIndex] = arrayToIncrement[arrayFirstIndex, arraySecondIndex];
        }

        //Methods that decreases a value in an array by a specified value
        public static void decrease(int[] arrayToDecrement, int arrayIndex, int amountToDecreaseBy)
        {
            arrayToDecrement[arrayIndex] = arrayToDecrement[arrayIndex] - amountToDecreaseBy;

            // Prevent values from going below 0
            if (arrayToDecrement[arrayIndex] < 0)
            {
                arrayToDecrement[arrayIndex] = 0;
            }
        }

        public static void decrease(int[,] arrayToDecrement, int arrayFirstIndex, int arraySecondIndex, int amountToDecreaseBy)
        {
            arrayToDecrement[arrayFirstIndex, arraySecondIndex] = arrayToDecrement[arrayFirstIndex, arraySecondIndex] - amountToDecreaseBy;

            // Prevent values from going below 0
            if (arrayToDecrement[arrayFirstIndex, arraySecondIndex] < 0)
            {
                arrayToDecrement[arrayFirstIndex, arraySecondIndex] = 0;
            }
        }

        public static void decrease(int[] arrayToDecrement, int[] displayToDecrement, int arrayIndex, int amountToDecreaseBy)
        {
            decrease(arrayToDecrement, arrayIndex, amountToDecreaseBy);
            displayToDecrement[arrayIndex] = arrayToDecrement[arrayIndex];
        }

        public static void decrease(int[,] arrayToDecrement, int[,] displayToDecrement, int arrayFirstIndex, int arraySecondIndex, int amountToDecreaseBy)
        {
            decrease(arrayToDecrement, arrayFirstIndex, arraySecondIndex, amountToDecreaseBy);
            displayToDecrement[arrayFirstIndex, arraySecondIndex] = arrayToDecrement[arrayFirstIndex, arraySecondIndex];
        }

        //getScoreZone that makes sure no counters can go below zero
        public static void neverNegative(int[] array, int index)
        {
            if (array[index] < 0)
            {
                array[index] = 0;
            }
        }
    }
}
