using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{
    public class DataCreator
    {
        public List<DataObject> AllData;
        public void LinesIntoData(List<string> lines)
        {
            AllData = new List<DataObject>();
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                if (AllData.Count > 0)
                {
                    var index = 0;
                    var found = false;
                    while ((!found) && (index < AllData.Count))
                    {
                        if (AllData[index].KatName == words[0])
                        {
                            found = true;
                        }
                        else
                        {
                            index = index + 1;
                        }
                    }
                    if (found)
                    {
                        AddNewDetail(index, words);
                    }
                    else
                    {
                        AddNewData(words);
                    }

                }
                else
                {
                    AddNewData(words);
                }
            }
        }

        public void AddNewDetail(int index, string[] words)
        {
            AllData[index].DatumList.Add(DateTime.Parse(words[1]));
            AllData[index].PreisList.Add(Convert.ToDecimal(words[2]));
            AllData[index].MemoList.Add(words.Length > 3 ? words[3] : "");
        }

        public void AddNewData(string[] words)
        {
            AllData.Add(new DataObject(words[0], new List<DateTime>(), new List<decimal>(), new List<string>()));
            AddNewDetail(AllData.Count - 1, words);
        }
    }
}