using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{
    public class DataObject
    {
        public string KatName { get; set; }
        public List<DateTime> DatumList { get; set; }
        public List<decimal> PreisList { get; set; }
        public List<string> MemoList { get; set; }
        public DataObject(string katname, List<DateTime> datumlist, List<decimal> preislist, List<string> memolist)
        {
            KatName = katname;
            DatumList = datumlist;
            PreisList = preislist;
            MemoList = memolist;
        }
    }
}