﻿using ETicaretWebApp.Models;

namespace ETicaretWebApp.ViewModels
{
    public class IndexProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalClubs { get; set; }
        public bool HasPreviousPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;
    }
}
