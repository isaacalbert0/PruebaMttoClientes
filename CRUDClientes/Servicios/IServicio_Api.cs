using CRUDClientes.Models;
namespace CRUDClientes.Servicios
{
    public interface IServicio_Api
    {
        Task<List<Clientes>> Lista();
        Task<Clientes> Obtener(string Identificacion);
        Task<bool> Guardar(Clientes objeto);
        Task<bool> Editar(Clientes objeto);
        Task<bool> Eliminar(string Identificacion);

    }
}
