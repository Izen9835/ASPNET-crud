# ASP.NET CRUD Demo Application

## Highly recommend [this C# Web Dev playlist](https://www.youtube.com/watch?v=m8IuIoAlciM&list=PLhPyEFL5u-i2ShGqmuP3uDdSy06hzBzdo) by Shad Sluiter
this repo is 90% attributed to the help of the above course. it had clear explanations, eununciations, and instructions

 Active Server Pages Network Enabled Technologies (ASP.NET) web application  
 Create, Read, Update, Delete (CRUD) (in relation to SQL database)  
 SQL server hosted on MS SQL  
 Uses Model-View-Controller (MVC) Design framework


 ## Rough Development Steps
 ### 1. Creation of SQL Table
 ```sql
CREATE TABLE [dbo].[MockStores] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Name]        NCHAR (10)   NULL,
    [Address]     NCHAR (100)  NULL,
    [Revenue]     MONEY        NULL,
    [Description] NCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```
This script was created using the SQL table editor in Visual Studio 2022, but you can just copy paste the above code.
Use [Mockaroo](https://www.mockaroo.com) to create mock data based on above table format.

### 2. Configure Data Access Object (DAO) (in [services folder](https://github.com/Izen9835/ASPNET-crud/tree/master/Services))
```C#
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
```
Above is the overall structure of the DAO interface. Inside each method, we call SQL scripts on the server to achieve the desired result.
Uses SQL Parameters to pass inputs from user interface

### 3. Model (in [StoreModel.cs](https://github.com/Izen9835/ASPNET-crud/blob/master/Models/StoreModel.cs))
```C#
public class StoreModel
{
    [DisplayName("id")]
    public int Id { get; set; }

    [DisplayName("Name")]
    public string Name { get; set; }

    [DisplayName("Location")]
    public string Address { get; set; }

    [DisplayName("Annual Revenue")]
    [DataType(DataType.Currency)]
    public decimal Revenue { get; set; }

    [DisplayName("Top Reviews")]
    public required string Description { get; set; }
}
```

### 4. Controller (in [StoreController.cs](https://github.com/Izen9835/ASPNET-crud/blob/master/Controllers/StoreController.cs))
Example function in StoreController.cs
```C#
public IActionResult ProcessDelete(int id)
{
    StoresDAO stores = new StoresDAO();
    StoreModel storeToDel = stores.GetStoreById(id);
    stores.Delete(storeToDel);
    return View("Index", stores.GetAllStores());
}
```
The controller essentially calls the DAO methods, and finally calls the View model to render the desired screen

### 5. View (in [View/Store](https://github.com/Izen9835/ASPNET-crud/tree/master/Views/Store))
Razor files (which essentially embed C# commands into html and css files), which were 95% created by Visual Studio shortcuts.  
After configuring Controller, rightclick on methods that return ```IActionResult``` then press ```Add View```.  


### 6. Dependency Injection (DI)
```C#
builder.Services.AddScoped<IStoreDataService, StoresDAO>();
```
Added this line in Program.cs, which basically allows classes to use our DAO service
In this example, the ```interface``` is IStoreDataService and the class is ```StoresDAO```
So, in StoresController.cs instead of needing to initialise a new StoresDAO object and even getting the config for it
```C#
StoresDAO stores = new StoresDAO(config);
stores.Insert(store);
```
we instead just use the DI to call a storesDAO object which already has the config (from appsettings.json) by default

Btw, it is good practice to put the SQL connection string in appsettings.json and then retrieving it, instead of keying it directly into the code.


### 7. Client-Side Validation and Regular Expressions (Regex)
```C#
[Required(ErrorMessage = "Revenue is required.")]
[Range(0.01, 12.00, ErrorMessage = "Price must be between 0.01 and 10000.")]
public decimal Revenue { get; set; }
```
Use the Model in the MVC model to set validation expressions.
Then, in the View, 
```C#
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.5/jquery.validate.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.12/jquery.validate.unobtrusive.min.js"></script>
```
These lines register Javascript libraries in the webpage, which simply tells the page to do validation.
Validation expressions are referenced via ```asp-validation-for```, e.g.
```C#
<span asp-validation-for="Description" class="text-danger"></span>
```

### 8. Server-Sider Validation
```C#
[HttpPost]
public IActionResult ProcessCreate(StoreModel store)
{
    if (!ModelState.IsValid)
        return View("CreateForm", store);

    _storesDAO.Insert(store);
    return View("Index", _storesDAO.GetAllStores());
}
```
Basically you return the same page with the half-keyed in information. Upon doing so, the validation errors will also appear.
So if you POST a page with erroneous values, it will simply trigger the same validation errors (as if they were client-side checks)
To double check that this is working properly, add this to Program.cs
```C#
builder.Services.AddRazorPages()
    .AddViewOptions(options =>
    {
        options.HtmlHelperOptions.ClientValidationEnabled = false;
    });
```
and add a breakpoint at ```if (!ModelState.IsValid)``` to verify that the check is being done as intended.




## Highly recommend [this C# Web Dev playlist](https://www.youtube.com/watch?v=m8IuIoAlciM&list=PLhPyEFL5u-i2ShGqmuP3uDdSy06hzBzdo) by Shad Sluiter

