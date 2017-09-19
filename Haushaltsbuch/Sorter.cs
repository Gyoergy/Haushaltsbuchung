using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{
    public class Sorter
    {
        public void Sort(List<DateTime> dateList, List<decimal> priceList, List<string> memoList, decimal price)
        {
            for (int i = dateList.Count - 1; i > 0; i--)
            {
                if (dateList[i] < dateList[i - 1])
                {
                    var dateTemp = dateList[i];
                    var priceTemp = priceList[i];
                    var memoTemp = memoList[i];

                    dateList[i] = dateList[i - 1];
                    priceList[i] = priceList[i - 1] + price;
                    memoList[i] = memoList[i - 1];

                    dateList[i - 1] = dateTemp;
                    priceList[i - 1] = priceTemp;
                    memoList[i - 1] = memoTemp;
                }
            }
        }
    }
}