using System;
using Microsoft.EntityFrameworkCore;
using RankingAppTT.Models;

namespace RankingAppTT.Data
{
	public class DataContext : DbContext
	{
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}


		public DbSet<ItemModel> ItemModels => Set<ItemModel>();

	}
}