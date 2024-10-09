using MediatR;
using QueryService.Database.Entities;

namespace QueryService.Services.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}
