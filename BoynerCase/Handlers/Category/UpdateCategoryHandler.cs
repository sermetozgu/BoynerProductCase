using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;

namespace BoynerCase.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {

        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository _repository)
        {
            _categoryRepository = _repository;
        }


        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.Update(request.Id, request.Category);
            return category;
        }
    }
}
