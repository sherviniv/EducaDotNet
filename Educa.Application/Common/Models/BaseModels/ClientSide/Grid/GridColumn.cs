using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels.ClientSide.Grid
{
    public class GridColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Orderable { get; set; }
        public bool Searchable { get; set; }
        public GridSearch Search { get; set; }
    }

    public class GridSearch
    {
        public bool Regex { get; set; }
        public string Value { get; set; }
    }

    public class DataOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
}
