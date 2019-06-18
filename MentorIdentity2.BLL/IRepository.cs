using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.BLL
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetUserItemList(string userId);
        T GetUserItem(int itemId, string userId);
        void CreateUserItem(T userItem, string userId);
        void UpdateUserId(T userItem, string userId);
        void DeleteUserId(int itemId, string userId);
        void Save();
    }
}
