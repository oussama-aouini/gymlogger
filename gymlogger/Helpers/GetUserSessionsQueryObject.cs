﻿namespace gymlogger.Helpers
{
    public class GetUserSessionsQueryObject
    {
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

    }
}
