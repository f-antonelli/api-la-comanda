using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Repository.Interfaces;

namespace Restaurante.Repository
{
    public class PedidoRepository:IPedidoRepository
    {
        private readonly DataContext _context;
        public PedidoRepository(DataContext context) {
            _context = context;
        }

        public async Task<Pedidos> GetById(int id)
        {
            return await _context.Pedidos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async void Delete(Pedidos entity)
        {
            _context.Pedidos.Remove(entity);
        }

        public async void Edit(Pedidos entity)
        {
            _context.Pedidos.Update(entity);
            //await _context.SaveChangesAsync();
        }

        public async Task<List<Pedidos>> GetAll()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task Add(Pedidos entity) {

            await _context.Pedidos.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<List<SectorOperacionDto>> OperacionesPorSector()
        {
            var operacionesPorSector = await (from pedido in _context.Pedidos
                                              join producto in _context.Productos
                                              on pedido.ProductoId equals producto.Id
                                              group pedido by producto.Sector into g
                                              select new SectorOperacionDto
                                              {
                                                  Sector = (int)g.Key,
                                                  CantidadOperaciones = g.Sum(p => p.Cantidad)
                                              })
                                              .ToListAsync();

            return operacionesPorSector;
        }

        public async Task<List<EmpleadoSectorOperacionDto>> OperacionesPorEmpleadoYSector()
        {
            var resultado = await (from empleadoPedido in _context.EmpleadoPedidos
                                   join pedido in _context.Pedidos
                                   on empleadoPedido.PedidoId equals pedido.Id
                                   join producto in _context.Productos
                                   on pedido.ProductoId equals producto.Id
                                   select new EmpleadoSectorOperacionDto
                                   {
                                       EmpleadoId = empleadoPedido.EmpleadoId,
                                       Sector = (int)producto.Sector,
                                       CantidadOperaciones = pedido.Cantidad
                                   })
                              .ToListAsync();

            return resultado;
        }
    }
}
