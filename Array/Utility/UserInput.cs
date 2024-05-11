using System;

namespace Skillup.Array.Utility
{
    /// <summary>
    /// used for to get all input from user.
    /// </summary>
    public class UserInput
    {
        #region Get Row Count
        /// <summary>
        /// to get array row count from user.
        /// </summary>
        /// <param name="strDisplayMsg"></param>
        /// <param name="strErrorMsg"></param>
        /// <returns></returns>
        public static int GetRowCount(string strDisplayMsg, string strErrorMsg)
        {
            int nRowCount = 0;
            bool bInputStatus = false;
            while (bInputStatus == false)
            {
                Output.Write(strDisplayMsg);
                string strGetRowSize = GetString();
                bInputStatus = int.TryParse(strGetRowSize, out nRowCount);

                //validation for out of the range input.
                if (bInputStatus == false)
                {
                    Output.WriteLine(strErrorMsg);
                }
                else if (nRowCount < Constant.MINIMUM_ARRAY_INPUT_RANGE || nRowCount > Constant.MAXIMUM_ARRAY_INPUT_RANGE)
                {
                    Output.WriteLine(strErrorMsg);
                    bInputStatus = false;
                }
            }
            return nRowCount;
        }
        #endregion

        #region Get Array Elements
        /// <summary>
        /// to get the arary elements from the user.
        /// </summary>
        /// <param name="narrMainArray"></param>
        /// <param name="nRowCount"></param>
        /// <param name="strDisplayMsg"></param>
        /// <param name="strErrorMsg"></param>
        /// <returns></returns>
        public static int[,] GetArrayElements(int nRowCount, string strDisplayMsg, string strErrorMsg)
        {
            int[,] narrMainArray = new int[nRowCount, Constant.ARRAY_COLUMN_COUNT];
            for (int nRow = 0; nRow < nRowCount; nRow++)
            {
                for (int nColumn = 0; nColumn < Constant.ARRAY_COLUMN_COUNT; nColumn++)
                {
                    bool bInputStatus = false;
                    while (bInputStatus == false)
                    {
                        Output.Write(string.Format(strDisplayMsg, nRow, nColumn));
                        bInputStatus = int.TryParse(GetString(), out narrMainArray[nRow, nColumn]);
                        if (bInputStatus == false)
                        {
                            Console.WriteLine(string.Format(Constant.ERROR_MSG_COMMON, strErrorMsg));
                        }
                    }
                }
                Output.WriteLine();
            }
            return narrMainArray;
        }
        #endregion

        #region Get Sorting Column
        /// <summary>
        /// to get sorting column from the user.
        /// </summary>
        /// <param name="strDisplayMsg"></param>
        /// <param name="strErrorMsg"></param>
        /// <returns></returns>
        public static SortingColumn GetSortingColumn(string strDisplayMsg, string strErrorMsg)
        {
            while (true)
            {
                Output.Write(string.Format(strDisplayMsg, Constant.MSG_SORTING_FIRST_COLUMN, Constant.MSG_SORTING_SECOND_COLUMN));
                string strSortingColumn = GetString();

                SortingColumn sortingColumn;
                //to return the sorting column from enum class else display appropriate error message.
                if (Enum.TryParse(strSortingColumn, true, out sortingColumn))
                {
                    return sortingColumn;                   
                }
                else
                {
                    Output.WriteLine(string.Format(Constant.ERROR_MSG_COMMON, strErrorMsg));
                }
            }
        }
        #endregion

        #region Get Sorting Order
        /// <summary>
        /// to get sorting order from user.
        /// </summary>
        /// <param name="strDisplayMsg"></param>
        /// <param name="strErrorMsg"></param>
        /// <returns></returns>
        public static SortingOrder GetSortingOrder(string strDisplayMsg, string strErrorMsg)
        {
            bool bInputStatus = false;
            int nSortingOrder = 0;
            while (bInputStatus == false)
            {
                Output.Write(strDisplayMsg);
                string strGetSortingOrder = GetString();
                bInputStatus = int.TryParse(strGetSortingOrder, out nSortingOrder);

                //to return the sorting order from eunm class else display appropriate error message.
                if (nSortingOrder == (int)SortingOrder.Ascending)
                {
                    return SortingOrder.Ascending;
                }
                else if (nSortingOrder == (int)SortingOrder.Descending)
                {
                    return SortingOrder.Descending;
                }
                else if (bInputStatus == false || nSortingOrder < Constant.POSITIVE_MINIMUM_RANGE)
                {
                    Output.WriteLine(string.Format(Constant.ERROR_MSG_COMMON, strErrorMsg));
                    bInputStatus = false;
                }
                else if (nSortingOrder < (int)SortingOrder.Ascending || nSortingOrder > (int)SortingOrder.Descending)
                {
                    Output.WriteLine(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_SORTING_ORDER_RANGE));
                    bInputStatus = false;
                }
            }
            return (SortingOrder)nSortingOrder;
        }
        #endregion

        /// <summary>
        /// to get string as an input from user.
        /// </summary>
        /// <returns></returns>
        private static string GetString()
        {
            return Console.ReadLine();
        }
    }
}