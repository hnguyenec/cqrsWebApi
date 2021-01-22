using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.WebApi.Context;
using CQRS.WebApi.Models;
using MediatR;

namespace CQRS.WebApi.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        // the id of the product we need to fetch.
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationContext _context;

            public GetProductByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                return product;
            }
        }
    }
}
