using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;

namespace BoynerCase.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {

        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository _repository)
        {
            _productRepository = _repository;
        }


        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.Create(request.Product);

            return request.Product;
        }
    }
}
