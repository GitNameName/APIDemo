using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public class ItemRepository : IItemRepository
    {
        readonly AppDbContext _db;
        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Item> AddItem(Item item)
        {
            var result = await _db.Items.AddAsync(item);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteItem(int id)
        {
            var result = await _db.Items.FirstOrDefaultAsync(i => i.ItemID == id);
            if(result!=null)
            {
                _db.Items.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Item> GetItem(int id)
        {
            return await _db.Items
                .Include(i => i.ItemGroup)
                .FirstOrDefaultAsync(i => i.ItemID == id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _db.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> Search(string name)
        {
            IQueryable<Item> q = _db.Items;

            if(!string.IsNullOrEmpty(name))
            {
                q = q.Where(i => i.Name.Contains(name));
            }

            return await q.ToListAsync();
        }

        public async Task<Item> UpdateItem(Item item)
        {
            var result = _db.Items.FirstOrDefault(i => i.ItemID == item.ItemID);
            if(result!=null)
            {
                result.GroupID = item.GroupID;
                result.ItemGroup = item.ItemGroup;
                result.Name = item.Name;
                result.Description = item.Description;

                _db.Items.Update(result);
                await _db.SaveChangesAsync();
            }

            return result;
        }
    }
}
