using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Service;
using MediatR;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using BoynerCase.Repository;

namespace BoynerCase.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {

        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository _repository)
        {
            _productRepository = _repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken) => _productRepository.GetAll();
    }
}
