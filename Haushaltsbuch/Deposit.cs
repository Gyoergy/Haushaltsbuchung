using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{
    public class Deposit
    {
        public string ShowDeposit(DateTime lastDay, List<DataObject> allData, decimal price, string memo)
        {
            var result = "";
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
                    var newPrice = price;
                    if (index > -1)
                    {
                        newPrice = dataObject.PreisList[index] + price;
                    }
                    result = dataObject.KatName + ": " + newPrice + " EUR";

                    // insert into sortiert
                    var last = dataObject.DatumList.Count - 1;
                    dataObject.DatumList.Add(lastDay);
                    dataObject.PreisList.Add(newPrice);
                    dataObject.MemoList.Add(memo);
                    new Sorter().Sort(dataObject.DatumList, dataObject.PreisList, dataObject.MemoList, price);
                }
                if (dataObject.KatName == "Einzahlung")
                {
                    dataObject.DatumList.Add(lastDay);
                    dataObject.PreisList.Add(price);
                    dataObject.MemoList.Add(memo);
                    new Sorter().Sort(dataObject.DatumList, dataObject.PreisList, dataObject.MemoList, 0);
                }
            }
            return result;
        }
    }
}