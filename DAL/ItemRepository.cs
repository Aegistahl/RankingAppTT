using System;
using System.Collections.Generic;
using System.Linq;
using RankingAppTT.Data;
using RankingAppTT.Models;
using Microsoft.EntityFrameworkCore;

namespace RankingAppTT.DAL
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ItemModel> GetItems()
        {
            return _context.ItemModels.ToList();
        }

        public ItemModel GetItemByID(int id)
        {
            var itemInDB = _context.ItemModels.Find(id);
            return itemInDB;
        }

        public void InsertItem(ItemModel item)
        {
            _context.ItemModels.Add(item);
        }

        public void DeleteItem(int ItemId)
        {
            ItemModel item = _context.ItemModels.Find(ItemId);
            _context.ItemModels.Remove(item);
        }

        public void UpdateItem(ItemModel item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}