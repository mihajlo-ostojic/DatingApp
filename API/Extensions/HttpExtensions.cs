using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPagginationHeader(this HttpResponse response, int currentPage,
             int itemsPerPage, int totalItems,int totalPages)
        {
            var pagginationHeader = new PaginationHeader(currentPage,itemsPerPage,totalItems,totalPages);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(pagginationHeader,options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            
        }
    }
}