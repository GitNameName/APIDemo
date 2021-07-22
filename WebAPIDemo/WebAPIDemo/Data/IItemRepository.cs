using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Data
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> Search(string name);
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int id);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task DeleteItem(int id);
    }
}
