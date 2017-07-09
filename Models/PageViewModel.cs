using System;

namespace GuestBookApp.Models
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }         //Текущая страница
        public int TotalPages { get; private set; }        //общее количество страниц
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }

    }
}
