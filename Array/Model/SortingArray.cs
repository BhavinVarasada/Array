using Skillup.Array.Utility;

namespace Skillup.Array
{
    /// <summary>
    /// for all calculation related to sorting the given array.
    /// </summary>
    public class SortingArray
    {
        #region Sorting the given Array.
        /// <summary>
        /// It will call another method for swap the rows.
        /// </summary>
        /// <param name="narrMainArray"></param>
        /// <param name="SortingColumnName"></param>
        /// <param name="SortingOrderNumber"></param>
        /// <returns></returns>
        public int[,] SortArray(int[,] narrMainArray, SortingColumn SortingColumnName, SortingOrder SortingOrderNumber)
        {
            int[,] narrSortedArray = narrMainArray;
            int nSortingColumn = (int)SortingColumnName;
            int nRowCount = narrMainArray.GetLength(0);

            //bubble sort to sorting the given array.
            for (int nRow = 0; nRow < nRowCount; nRow++)
            {
                for (int nColumn = 0; nColumn < (nRowCount - 1); nColumn++)
                {
                    if (SortingOrderNumber == SortingOrder.Ascending && (narrSortedArray[nColumn, nSortingColumn] > narrSortedArray[nColumn + 1, nSortingColumn])
                        || SortingOrderNumber == SortingOrder.Descending && (narrSortedArray[nColumn, nSortingColumn] < narrSortedArray[nColumn + 1, nSortingColumn]))
                    {
                        //method calling for swaping and re-order the another column.
                        SwapRows(narrSortedArray, nColumn);
                    }
                }
            }
            return narrSortedArray;
        }
        /// <summary>
        /// to swap the rows and re-order the another column.
        /// </summary>
        /// <param name="narrSortedArray"></param>
        /// <param name="j"></param>
        private void SwapRows(int[,] narrSortedArray, int nColumn)
        {
            for (int k = 0; k < Constant.ARRAY_COLUMN_COUNT; k++)
            {
                int nTemp = narrSortedArray[nColumn, k];
                narrSortedArray[nColumn, k] = narrSortedArray[nColumn + 1, k];
                narrSortedArray[nColumn + 1, k] = nTemp;
            }        
        }
        #endregion
    }
}
