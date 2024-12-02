using System.Collections.ObjectModel;
using System.Windows.Input;
using CadastroClientes.Models;
using CadastroClientes.Views;

namespace CadastroClientes.ViewModels
{
    public class ListaClienteViewModel : BindableObject
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new ObservableCollection<Cliente>();

        public ICommand BuscarCommand { get; }
        public ICommand EditarCommand { get; }

        public ListaClienteViewModel()
        {
            BuscarCommand = new Command<string>(async (query) => await BuscarClientes(query));
            EditarCommand = new Command<Cliente>(async (cliente) => await EditarCliente(cliente));

            CarregarClientes();
        }

        public async void CarregarClientes()
        { 
            try
            {
                var clientes = await App.Db.GetAll();
                Clientes.Clear();
                foreach (var cliente in clientes)
                {
                    Clientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async Task BuscarClientes(string query)
        {
            try
            {
                var clientes = await App.Db.Search(query);
                Clientes.Clear();
                foreach (var cliente in clientes)
                {
                    Clientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async Task EditarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                // Verificar os dados do cliente antes de passar para a próxima tela
                Console.WriteLine($"Cliente: {cliente.Name}, {cliente.Lastname}, {cliente.Age}, {cliente.Address}");

                await App.Current.MainPage.Navigation.PushAsync(new EditarCliente(cliente));
            }
        }

    }
}
