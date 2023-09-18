using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Service;
using MediatR;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using BoynerCase.Repository;

namespace BoynerCase.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, IEnumerable<Category>>
    {

        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryHandler(ICategoryRepository _repository)
        {
            _categoryRepository = _repository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoryQuery request,
            CancellationToken cancellationToken) =>  _categoryRepository.GetAll();
    }
}

