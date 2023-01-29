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
    public class GetAllProductsQuery:IRequest<ServiceResponse<List<ProductDTO>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductDTO>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;


            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                var dto = _mapper.Map<List<ProductDTO>>(products);
                return new ServiceResponse<List<ProductDTO>>(dto);
            }
        }
    }
}
