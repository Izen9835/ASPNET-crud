using Bogus;
using Microsoft.AspNetCore.Mvc;
using SB_Onboarding_1.Models;
using SB_Onboarding_1.Services;

namespace SB_Onboarding_1.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            StoresDAO store_data = new StoresDAO();

            return View(store_data.GetAllStores());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            StoresDAO stores = new StoresDAO();

            List<StoreModel> storeList = stores.SearchStores(searchTerm);
            return View("index", storeList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            StoresDAO stores = new StoresDAO();
            StoreModel foundStore = stores.GetStoreById(id);
            return View(foundStore);

        }

        public IActionResult Edit(int id)
        {
            StoresDAO stores = new StoresDAO();
            StoreModel foundStore = stores.GetStoreById(id);
            return View("EditForm", foundStore);

        }

        public IActionResult ProcessEdit(StoreModel store)
        {
            StoresDAO stores = new StoresDAO();
            stores.Update(store);
            return View("Index", stores.GetAllStores());

        }

        public IActionResult ProcessDelete(int id)
        {
            StoresDAO stores = new StoresDAO();
            StoreModel storeToDel = stores.GetStoreById(id);
            stores.Delete(storeToDel);
            return View("Index", stores.GetAllStores());
        }

        public IActionResult CreateForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(StoreModel store)
        {
            StoresDAO stores = new StoresDAO();
            stores.Insert(store);
            return View("Index", stores.GetAllStores());
        }

    }
}
