using Bogus;
using SB_Onboarding_1.Models;

namespace SB_Onboarding_1.Services
{
    public class HardCodedSampleDataRepo : IStoreDataService
    {
        static List<StoreModel> storeList = new List<StoreModel>();
        public int Delete(StoreModel store)
        {
            throw new NotImplementedException();
        }

        public List<StoreModel> GetAllStores()
        {

            if (storeList.Count != 0) return storeList;

            storeList.Add(new StoreModel { Id = 1, Name = "Mcdonald", Address = "Bedok South Rd", Revenue = 12.0m, Description = "hellothere" });
            storeList.Add(new StoreModel { Id = 2, Name = "Starbuck", Address = "Tampines Rd", Revenue = 12.23423m, Description = "hellothere" });
            storeList.Add(new StoreModel { Id = 3, Name = "Kurger Bing", Address = "Ang Mo Kio Ave", Revenue = 12234.0m, Description = "hellothere" });
            storeList.Add(new StoreModel { Id = 4, Name = "Cool Spot", Address = "Kent Ridge Drive", Revenue = 1255.0m, Description = "hellothere" });

            for (int i = 0; i < 100; i++)
            {
                storeList.Add(new Faker<StoreModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Address, f => f.Address.StreetAddress())
                    .RuleFor(p => p.Revenue, f => f.Random.Decimal(100))
                    .RuleFor(p => p.Description, f => f.Rant.Review())
                );
            }

            return storeList;
        }

        public StoreModel GetStoreById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(StoreModel store)
        {
            throw new NotImplementedException();
        }

        public List<StoreModel> SearchStores(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(StoreModel store)
        {
            throw new NotImplementedException();
        }
    }
}
