using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Service;
using MediatR;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using Azure;
using BoynerCase.Repository;

namespace BoynerCase.Handlers
{
    public class GetCategoryPageHandler : IRequestHandler<GetCategoryPageQuery, IEnumerable<Category>>
    {

        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryPageHandler(ICategoryRepository _repository)
        {
            _categoryRepository = _repository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoryPageQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetPage(request.page);
        }
    }
}