using CadastroClientes.Models;
using CadastroClientes.ViewModels;

namespace CadastroClientes.Views;

public partial class EditarCliente : ContentPage
{
    public EditarCliente(Cliente cliente)
    {
        InitializeComponent();

        // Criando o ViewModel e passando o Cliente para ele
        var viewModel = new EditarClienteViewModel(cliente);

        // Definindo o BindingContext para o ViewModel
        BindingContext = viewModel;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            var viewModel = (EditarClienteViewModel)BindingContext;
            await viewModel.SalvarClienteAsync();
            await DisplayAlert("Sucesso!", "Cliente Atualizado", "OK");
            MessagingCenter.Send(this, "AtualizarLista");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }
}
