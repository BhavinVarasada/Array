using Skillup.Array.Utility;
using System;

namespace Skillup.Array
{
    /// <summary>
    /// Used for program execution logic.
    /// </summary>
    public class Execution
    {
        /// <summary>
        /// method call to get row count, sorting column, array elements, 
        /// sort the array and print the sorted array.
        /// </summary>
        public void Start()
        {
            try
            {               
                Output.PrintTitle();
                
                string strUserDisplayMsg = string.Format(Constant.MSG_USER_DISPLAY, Constant.MINIMUM_ARRAY_INPUT_RANGE, Constant.MAXIMUM_ARRAY_INPUT_RANGE);
                string strCommonErrorMsg = string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_ARRAY_SIZE);

                //method call to get array size from user.
                int nRowCount = UserInput.GetRowCount(strUserDisplayMsg, strCommonErrorMsg);

                //method call to get array element from the user.
                int[,] narrMainArray = UserInput.GetArrayElements(nRowCount, Constant.MSG_ENTER_ARRAY_ELEMENT, Constant.ERROR_MSG_ARRAY_ELEMENTS);

                //To print the array which is entered by user.
                Output.PrintArray(narrMainArray, Constant.MSG_ENTERED_ARRAY);

                //To get the sorting Column from the user.
                SortingColumn SortingColumnName = UserInput.GetSortingColumn(Constant.MSG_SORTING_ARRAY_COLUMN, Constant.ERROR_MSG_SORTING_COLUMN);

                //To get the sorting order from the user.
                SortingOrder SortingOrderNumber = UserInput.GetSortingOrder(Constant.MSG_ENTER_SORTING_ORDER, Constant.ERROR_MSG_SORTING_ORDER);

                //method call to sort the given array.
                SortingArray objSortingArray = new SortingArray();
                int[,] narrSortedArray = objSortingArray.SortArray(narrMainArray, SortingColumnName, SortingOrderNumber);

                //to print the final sorted array.
                Output.PrintArray(narrSortedArray, Constant.MSG_FOR_SORTED_ARRAY);
            }
            //exception handling for any unexpected and unknown errors.
            catch (Exception ex)
            {
                Console.Write(Constant.ERROR_MSG_UNEXPECTED);
                Console.WriteLine(string.Format(Constant.ERROR_MSG_DETAIL, ex.Message));
                Console.WriteLine(string.Format(Constant.ERROR_MSG_STACKTRACE, ex.StackTrace));
            }
        }
    }
}
