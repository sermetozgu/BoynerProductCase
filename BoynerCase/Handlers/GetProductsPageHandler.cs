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
    public class GetProductsPageHandler : IRequestHandler<GetProductsPageQuery, IEnumerable<Product>>
    {

        private readonly IProductRepository _productRepository;

        public GetProductsPageHandler(IProductRepository _repository)
        {
            _productRepository = _repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsPageQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetPage(request.page);
        }
    }
}
