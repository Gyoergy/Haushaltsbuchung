using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Haushaltsbuch
{
    public class DataToList
    {
        public List<string> CreateList(List<DataObject> allData)
        {
            var result = new List<string>();

            foreach (var dataObject in allData)
            {
                for (int i = 0; i < dataObject.DatumList.Count; i++)
                {
                    result.Add(dataObject.KatName+" "+dataObject.DatumList[i].ToShortDateString()+" "+dataObject.PreisList[i]+" "+ dataObject.MemoList[i]);
                }
            }
            return result;
        }

    }
}