using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAgregator.API.ResourceParameters
{
    public class UsersResourceParameters
    {
        const int maxPageSize = 20;
        public string Email { get; set; }
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize { get; set; } = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
