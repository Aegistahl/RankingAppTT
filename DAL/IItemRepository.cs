using System;
using System.Collections.Generic;
using RankingAppTT.Models;

namespace RankingAppTT.DAL
{
    public interface IItemRepository
    {
        IEnumerable<ItemModel> GetItems();
        ItemModel GetItemByID(int Id);
        void InsertItem(ItemModel item);
        void DeleteItem(int Id);
        void UpdateItem(ItemModel item);
        void Save();
    }
}