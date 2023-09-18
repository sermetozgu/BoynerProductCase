using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;

namespace BoynerCase.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {

        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository _repository)
        {
            _categoryRepository = _repository;
        }


        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.Delete(request.Id);
            return category;
        }
    }
}
