using DotNetCore6.Data;
using System.Threading.Tasks;
using DotNetCore6.Models.Enums;

namespace DotNetCore6.Data.UnitofWork
{
    public interface IUnitOfWork
    {
        Entities context { get; }
        int UserID { set; get; }
        Language Language { set; get; }

        void Rollback();
        bool Save(bool isPartial = false);
        Task<bool> SaveAsync(bool isPartial = false);
        bool SavePartial();
        Task<bool> SavePartialAsync();
    }
}
