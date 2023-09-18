using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository _repository)
        {
            _productRepository = _repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
            await _productRepository.GetById(request.Id);

    }
}
