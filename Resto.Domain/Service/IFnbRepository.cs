using Resto.Domain.Entity;

namespace Resto.Domain.Service
{
    public interface IFnbRepository
    {
        Task<List<MHFnb>> GetAllFnb();
        Task<MHFnb?> GetFnbById(int id);
        Task<MHFnb?> CreateFnb(MHFnb fnb);
        Task<MHFnb?> UpdateFnb(int id, MHFnb fnb);
        Task<MHFnb?> SoftDelete(int id);
    }
}
