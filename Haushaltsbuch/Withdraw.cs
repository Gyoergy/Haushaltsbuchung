using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{    
    public class Withdraw
    {
        public List<string> ShowWithdraw(DateTime lastDay, List<DataObject> allData, string art, decimal price, string memo)
        {
            var result = new List<string>();
            foreach (var dataObject in allData)
            {
                if (dataObject.KatName == "Kassenbestand")
                {
                    var index = -1;
                    for (int i = 0; i < dataObject.DatumList.Count; i++)
                    {
                        if (dataObject.DatumList[i] <= lastDay)
                        {
                            index = i;
                        }
                    }
                    if (index == -1)
                    {
                        result.Add("Error");
                        return result;
                    }
                    var newPrice = dataObject.PreisList[index] - price;
                    result.Add(dataObject.KatName + ": " + newPrice + " EUR");

                    // insert into sortiert
                    var last = dataObject.DatumList.Count - 1;
                    dataObject.DatumList.Add(lastDay);
                    dataObject.PreisList.Add(newPrice);
                    dataObject.MemoList.Add(memo);
                    new Sorter().Sort(dataObject.DatumList, dataObject.PreisList, dataObject.MemoList, price * -1);
                }
                if (dataObject.KatName == art)
                {
                    dataObject.DatumList.Add(lastDay);
                    dataObject.PreisList.Add(price);
                    dataObject.MemoList.Add(memo);
                    new Sorter().Sort(dataObject.DatumList, dataObject.PreisList, dataObject.MemoList, 0);
                    result.Add(dataObject.KatName + ": " + price + " EUR "+ memo);
                }
            }
            return result;
        }
    }
}