using BonusSystem.Models.DTOs.Stores;

namespace BonusSystem.Core.Services
{
    public interface IStoreService
    {
        StoreResponseDto CreateStore(StoreDto request);
        StoreResponseDto GetStoreById(Guid id);
        List<StoreResponseDto> GetAllStores();
        StoreResponseDto UpdateStore(Guid id, StoreDto request);
        void DeleteStore(Guid id);
    }
}
