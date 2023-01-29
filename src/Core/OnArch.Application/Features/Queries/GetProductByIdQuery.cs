using AutoMapper;
using MediatR;
using OnArch.Application.Abstraction.Repository;
using OnArch.Application.DTOs;
using OnArch.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnArch.Application.Features.Queries
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<GetProductByIdDTO>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdDTO>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<GetProductByIdDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                var dto = _mapper.Map<GetProductByIdDTO>(product);

                return new ServiceResponse<GetProductByIdDTO>(dto);
            }
        }
    }
}

