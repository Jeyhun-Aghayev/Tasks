using AdoGenericServices.Services;
using GenericAdo.Models;
using GenericAdo.Services;
ConfigurationService.Configure();
Service<Category> catService = new Service<Category>();
Service<Shipper> shipService = new Service<Shipper>();

await catService.Add(new Category { CategoryName = "New Category", Description = "description" });
//shipService.Add(new Shipper { CompanyName = "New Shipper"});
