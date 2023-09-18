using BoynerCase.Models;
using BoynerCase.Repository;
using MediatR;

namespace BoynerCase.Service
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

    public record GetProductsPageQuery(int page) : IRequest<IEnumerable<Product>>;

    public record GetCategoryProductsQuery(int categoryId,int page) : IRequest<IEnumerable<Product>>;

    public record AddProductCommand(Product Product) : IRequest<Product>;

    public record UpdateProductCommand(int Id, Product Product) : IRequest<Product>;

    public record GetProductByIdQuery(int Id) : IRequest<Product>;

    public record DeleteProductCommand(int Id) : IRequest<Product>;
}
