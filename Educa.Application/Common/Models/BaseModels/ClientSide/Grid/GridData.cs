using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels.ClientSide.Grid
{
    public class GridData<T> 
    {
        public int Draw { get; set; }
        //Total Records 
        public int recordsTotal { get; set; }
        //Totla Records Count After Filtered
        public int recordsFiltered { get; set; }
        //ReturnedData
        public IList<T> Data { get; set; }

    }
}
