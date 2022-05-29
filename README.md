# product-registry-system
Hello and welcome to this REST API in .Net Core that supports querying dresses from a registry system of a well-known clothing store


#### System requirements

- Target framework: .Net 5.0

#### What was used while building this API?
Regarding technical knowledge used when developing this API, you can find some of them below:
- Dependency injection
- Repository pattern
- Multi-layer architecture
- Single responsability principle applied and others from the SOLID principles

___


Please read the recommendations below so that you can access to it and test it

#### ⚠️ Installation steps
1. Download the source code from this repository
2. Run <code>add-migration InitialMigration</code> command in the VS PackageManagerConsole to get the database building
    - Besides creating the database instance, this command seeds product's data
3. Set *ProductRegistrySystem.Api* as the startup project by right clicking over the project
4. Clean and then rebuild the solution to make sure it builds successfully and the Nuget packages are correctly restored
5. After this steps you'll be able to build the API locally, yippee! :)

___

#### API usage
This API supports the following operations:
 | HttpOperation | Uri | Description |
 | ------------- | -------- | ----- | 
 | POST | api/products | Creates a new product |
 | PUT | api/products/{productId} | Updates a product's information |
 | GET | api/products/{productId} | Retrieves a product's information |
 
 You'll find the information regarding payloads and datatypes in the API documentation, which you'll see as soon you build it locally
 
 
#### :bulb: The Discount API
The discount value for each product is retrieved from an external source created in *mockAPI*. If you want to check out the Discount Api from where the product's discount were retrieve feel free to acces by clicking [here](https://62903dcb27f4ba1c65b5e172.mockapi.io/api/discounts/products/)
