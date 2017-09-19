using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{
    public class Overview
    {
        public List<string> ShowOverview(DateTime lastDay, List<DataObject> allData)
        {
            var result = new List<string>();

            var firstDayThisMonth = new DateTime(lastDay.Year, lastDay.Month, 1);

            foreach (var dataObject in allData)
            {              
                var resultLine = "";
                if (dataObject.KatName == "Kassenbestand")
                {
                    for (int i = 0; i < dataObject.DatumList.Count; i++)
                    {
                        if (dataObject.DatumList[i] <= lastDay)
                        {
                            resultLine = dataObject.KatName + ": " + dataObject.PreisList[i] + " EUR";
                        }
                    }
                    result.Add(resultLine);
                }
                else
                {
                    for (int i = 0; i < dataObject.DatumList.Count; i++)
                    {
                        if ((dataObject.DatumList[i] > firstDayThisMonth) && (dataObject.DatumList[i] <= lastDay))
                        {
                            resultLine = dataObject.KatName + ": " + dataObject.PreisList[i] + " EUR " + dataObject.MemoList[i];
                            result.Add(resultLine);
                        }
                    }
                }
            }
            return result;
        }
    }
}