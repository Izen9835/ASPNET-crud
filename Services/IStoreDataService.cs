using SB_Onboarding_1.Models;

namespace SB_Onboarding_1.Services
{
    public interface IStoreDataService
    {
        List<StoreModel> GetAllStores();

        List<StoreModel> SearchStores(string searchTerm);

        StoreModel GetStoreById(int id);

        int Insert(StoreModel store);

        int Delete(StoreModel store);

        int Update(StoreModel store);
    }
}
