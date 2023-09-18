using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;

namespace BoynerCase.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {

        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository _repository)
        {
            _productRepository = _repository;
        }


        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {


            Product product = await _productRepository.Update(request.Id, request.Product);


            return product;
        }
    }
}
