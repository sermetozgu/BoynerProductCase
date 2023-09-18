using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository _repository)
        {
            _categoryRepository = _repository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) =>
            await _categoryRepository.GetById(request.Id);

    }
}
