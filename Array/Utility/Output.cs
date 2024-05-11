using System;

namespace Skillup.Array.Utility
{
    /// <summary>
    /// for all methods which is used for print.
    /// </summary>
    public class Output
    {
        /// <summary>
        /// to print the message with arguments and on another line.
        /// </summary>
        /// <param name="Message"></param>
        public static void WriteLine(object Message = null)
        {
            Console.WriteLine(Message);
        }

        /// <summary>
        /// for print the message but on same line.
        /// </summary>
        /// <param name="Message"></param>
        public static void Write(object Message = null)
        {
            Console.Write(Message);
        }

        #region Print Program Title
        /// <summary>
        /// to print the program title.
        /// </summary>
        public static void PrintTitle()
        {
            WriteLine(Constant.DASH_LINE);
            WriteLine(Constant.PROGRAM_NAME);
            WriteLine(Constant.DASH_LINE);
        }
        #endregion       

        #region Print Array.
        /// <summary>
        /// to print array.
        /// </summary>
        /// <param name="naarArray"></param>
        /// <param name="strMesaage"></param>
        public static void PrintArray(int[,] naarArray, string strMesaage)
        {
            WriteLine(strMesaage);
            WriteLine(string.Format(Constant.PRINT_ARRAY_COLUMN, SortingColumn.X, SortingColumn.Y));
            WriteLine(Constant.SHORT_DASH_LINE);

            for (int nRow = 0; nRow < naarArray.GetLength(0); nRow++)
            {
                for (int nColumn = 0; nColumn < Constant.ARRAY_COLUMN_COUNT; nColumn++)
                {
                    Write("\t" + naarArray[nRow, nColumn]);
                }
                WriteLine();
            }
        }
        #endregion
    }
}
