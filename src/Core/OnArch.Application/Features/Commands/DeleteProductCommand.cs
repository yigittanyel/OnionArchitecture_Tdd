using AutoMapper;
using MediatR;
using OnArch.Application.Abstraction.Repository;
using OnArch.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Application.Features.Commands
{
    public class DeleteProductCommand : IRequest<ServiceResponse<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request.Id);
            if (product == null)
                return new ServiceResponse<bool>();

            _mapper.Map(request, product);

            await _productRepository.DeleteAsync(product.Id);

            return new ServiceResponse<bool>();
        }
    }
}
