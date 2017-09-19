using System;
using System.Collections.Generic;

namespace Haushaltsbuch
{
    public class ExistingKat
    {
        public bool Exists(List<DataObject> allData, string art)
        {
            foreach (var dataObject in allData)
            {  
                if (dataObject.KatName == art)
                {
                    return true;
                }
            }
            return false;
        }
    }
}