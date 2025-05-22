using Bogus;
using Microsoft.AspNetCore.Mvc;
using SB_Onboarding_1.Models;
using SB_Onboarding_1.Services;

namespace SB_Onboarding_1.Controllers
{
    public class StoreController : Controller
    {
        /*
        private readonly IConfiguration config;

        public StoreController()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // needed for console/test app
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // no need to intialise a new DAO everytime
        // additionally, this service now accesses appsettings.json by default, somehow

        public IActionResult ProcessCreate(StoreModel store)
        {
            StoresDAO stores = new StoresDAO(config);
            stores.Insert(store);
            return View("Index", stores.GetAllStores());
        }
        */

        private readonly IStoreDataService _storesDAO;
        public StoreController(IStoreDataService storeService)
        {
            _storesDAO = storeService;
        }
        public IActionResult Index()
        {
            return View(_storesDAO.GetAllStores());
        }

        public IActionResult SearchResults(string searchTerm)
        { 
            List<StoreModel> storeList = _storesDAO.SearchStores(searchTerm);
            return View("index", storeList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            StoreModel foundStore = _storesDAO.GetStoreById(id);
            return View(foundStore);

        }

        public IActionResult Edit(int id)
        {
            StoreModel foundStore = _storesDAO.GetStoreById(id);
            return View("EditForm", foundStore);

        }

        public IActionResult ProcessEdit(StoreModel store)
        {
            _storesDAO.Update(store);

            Console.WriteLine(store.Id);
            Console.WriteLine(store.Name);
            Console.WriteLine(store.Address);
            Console.WriteLine(store.Revenue);
            Console.WriteLine(store.Description);

            return View("Index", _storesDAO.GetAllStores());

        }

        public IActionResult ProcessDelete(int id)
        {
            StoreModel storeToDel = _storesDAO.GetStoreById(id);
            _storesDAO.Delete(storeToDel);
            return View("Index", _storesDAO.GetAllStores());
        }

        public IActionResult CreateForm()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ProcessCreate(StoreModel store)
        {
            if (!ModelState.IsValid)
                return View("CreateForm", store);

            _storesDAO.Insert(store);
            return View("Index", _storesDAO.GetAllStores());
        }

    }
}
