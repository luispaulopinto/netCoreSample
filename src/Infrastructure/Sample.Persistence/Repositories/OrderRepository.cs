// using Sample.Application.Contracts.Persistence;
// using Sample.Domain.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace Sample.Persistence.Repositories
// {
//     public class OrderRepository : BaseRepository<Order>, IOrderRepository
//     {
//         public OrderRepository(SampleDbContext dbContext) : base(dbContext)
//         {
//         }

//         public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
//         {
//             return await _dbContext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
//                 .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
//         }

//         public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
//         {
//             return await _dbContext.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
//         }
//     }
// }
