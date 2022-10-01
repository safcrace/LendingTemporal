using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }        

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetLastItemAsyn(T entity)
        {
            return await _dbContext.Set<T>().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        //public async Task<IReadOnlyList<object>> ListAllAsyncByPrestamoId(int id)
        //{
        //    return await _dbContext.PlanPagos.Join(_dbContext.DetallePlanPagos,
        //                                           plan => plan.Id,
        //                                           detalle => detalle.PlanPagoId,
        //                                           (plan, detalle) => new
        //                                           {
        //                                               planId = plan.Id,
        //                                               detalle.Mes,
        //                                               detalle.CuotaCapital,
        //                                               detalle.CuotaIntereses,
        //                                               detalle.CuotaGastosAdministrativos,
        //                                               detalle.CuotaIva,
        //                                               detalle.TotalCuota,
        //                                               detalle.Saldo,
        //                                               detalle.FechaPago,
        //                                               detalle.Aplicado
        //                                           }).Where(p => p.planId == id).ToListAsync();
        //}

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}