﻿namespace ElectronicShop.Infrastructure
{
    public interface IDataService<T>
    {
        public string FileName { get; set; }
        void WriteJson(T data);
    }
}
