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
    public class UpdateProductCommand:IRequest<ServiceResponse<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Stock { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<bool>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request.Id);
                if (product == null)
                    return new ServiceResponse<bool>();

                _mapper.Map(request, product);

                await _productRepository.UpdateAsync(product);

                return new ServiceResponse<bool>();
            }
        }
    }
}
