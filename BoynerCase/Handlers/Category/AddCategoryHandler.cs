
using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;

namespace BoynerCase.Handlers
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Category>
    {

        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryHandler(ICategoryRepository _repository)
        {
            _categoryRepository = _repository;
        }


        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            _categoryRepository.Create(request.Category);

            return request.Category;
        }
    }
}
