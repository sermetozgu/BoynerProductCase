using BoynerCase.Models;
using BoynerCase.Repository;
using MediatR;

namespace BoynerCase.Service
{
    public record GetCategoryQuery() : IRequest<IEnumerable<Category>>;

    public record GetCategoryPageQuery(int page) : IRequest<IEnumerable<Category>>;

    public record AddCategoryCommand(Category Category) : IRequest<Category>;

    public record UpdateCategoryCommand(int Id, Category Category) : IRequest<Category>;

    public record GetCategoryByIdQuery(int Id) : IRequest<Category>;

    public record DeleteCategoryCommand(int Id) : IRequest<Category>;
}

