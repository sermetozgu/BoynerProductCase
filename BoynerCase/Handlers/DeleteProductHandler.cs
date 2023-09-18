using AutoMapper;
using BoynerCase.Models;
using BoynerCase.Repository;
using BoynerCase.Service;
using MediatR;

namespace BoynerCase.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {

        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository _repository)
        {
            _productRepository = _repository;
        }


        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.Delete(request.Id);
            return product;
        }
    }
}
