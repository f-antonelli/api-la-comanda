//using Restaurante.Entities;
//using Restaurante.Repository;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Restaurante.Services
//{
//    public class PedidosService
//    {
//        private readonly ComandaRepository _comandaRepository;

//        public PedidosService(ComandaRepository comandaRepository)
//        {
//            _comandaRepository = comandaRepository;
//        }

//        public async Task<Productos> GetProductoById(int id)
//        {
//            return await _comandaRepository.GetById(id);
//        }

//        public async Task<IEnumerable<Productos>> GetAllProductos()
//        {
//            return await _comandaRepository.GetAll();
//        }

//        public async Task AddComanda(Comandas comanda)
//        {
//            await _comandaRepository.Add(comanda);
//        }

//        public async Task UpdateComanda(Comandas comanda)
//        {
//            await _comandaRepository.Edit(comanda);
//        }

//        public async Task DeleteProducto(Productos producto)
//        {
//            await _comandaRepository.Delete(producto);
//        }

//        public Task<Productos> MasVendido()
//        {
//            // Lógica de negocio para obtener el producto más vendido
//            throw new NotImplementedException();
//        }

//        public Task<Productos> MenosVendido()
//        {
//            // Lógica de negocio para obtener el producto menos vendido
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<Comandas>> EntregadoFueraDeTiempo()
//        {
//            // Lógica de negocio para obtener pedidos entregados fuera de tiempo
//            throw new NotImplementedException();
//        }
//    }
//}
