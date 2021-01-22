using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.WebApi.Context;
using CQRS.WebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebApi.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();

                return productList?.AsReadOnly();
            }
        }
    }
}
