namespace CatalogApi.Models.Products.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, List<string> Category,string ImageFile):ICommand<CreateProductResult>;

public record CreateProductResult(Guid ID);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Business Logic to create a product
        // Save to database
        // Return the ID of the created product
        var product = new Product
        {
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            Category = command.Category,
            ImageFile = command.ImageFile
        };
        // Save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        // Return the ID of the created product
        return new CreateProductResult(product.Id);
    }
}
