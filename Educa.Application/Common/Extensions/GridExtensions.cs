using Educa.Application.Common.Models.BaseModels.ClientSide.Grid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Application.Common.Extensions
{
    public static class GridExtensions
    {

        public static async Task<GridData<TResult>> ConvertToPaged<TResult>(this IQueryable<TResult> query, GridQuery queryInfo)
        {
            int totalRecords = query.Count();
            if(queryInfo.Order.Count != 0)
              query = query.OrderBy(queryInfo.Columns[queryInfo.Order[0].Column].Data + " " + queryInfo.Order[0].Dir);

            query = query.ParseFilters(queryInfo);

            var list = await query.Skip(queryInfo.Start)
                        .Take(queryInfo.Length)
                        .ToListAsync();

            return new GridData<TResult>()
            {
                Data = list,
                Draw = queryInfo.Draw,
                recordsTotal = totalRecords,
                recordsFiltered = query.Count()
            };
        }


        private static IQueryable<TResult> ParseFilters<TResult>(this IQueryable<TResult> query, GridQuery queryInfo)
        {
            foreach (var col in queryInfo.Columns)
            {
                if (!string.IsNullOrEmpty(col.Search.Value))
                    query = query.Where($"{col.Data}.Contains(\"{col.Search.Value}\")");

            }
            return query;
        }
    }

}

