using CadastroClientes.Models;
using System.Threading.Tasks;

namespace CadastroClientes.ViewModels
{
    public class EditarClienteViewModel
    {
        public Cliente Cliente { get; set; }

        public EditarClienteViewModel(Cliente cliente)
        {
            Cliente = cliente;
        }

        // Método para salvar as alterações do cliente
        public async Task SalvarClienteAsync()
        {
            try
            {
                // Verifique se o cliente não é nulo
                if (Cliente == null)
                    throw new InvalidOperationException("Cliente não encontrado.");

                // Atualize o cliente no banco de dados
                await App.Db.Update(Cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar cliente: " + ex.Message);
            }
        }
    }
}
