using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels.ClientSide.Grid
{
    //Sent Parameters to controller
    public class GridQuery
    {
        public List<GridColumn> Columns { get; set; }
        public int Draw { get; set; }
        public int Length { get; set; }
        public List<DataOrder> Order { get; set; }
        public GridSearch Search { get; set; }
        public int Start { get; set; }
    }
}
