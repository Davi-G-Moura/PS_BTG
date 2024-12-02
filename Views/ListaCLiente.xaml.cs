using CadastroClientes.Models;
using CadastroClientes.ViewModels;

namespace CadastroClientes.Views;

public partial class ListaCLiente : ContentPage
{
    public ListaCLiente()
    {
        InitializeComponent();
        BindingContext = new ListaClienteViewModel();
        MessagingCenter.Subscribe<EditarCliente>(this, "AtualizarLista", (sender) =>
        {
            AtualizarListaClientes();
        });
        MessagingCenter.Subscribe<NovoCliente>(this, "AtualizarLista", (sender) =>
        {
            AtualizarListaClientes();
        });
    }

    private void AtualizarListaClientes()
    {
        var viewModel = (ListaClienteViewModel)BindingContext;
        viewModel.CarregarClientes();
    }

    private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        var viewModel = (ListaClienteViewModel)BindingContext;
        viewModel.BuscarCommand.Execute(e.NewTextValue);
    }

    private async void lst_clientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Cliente cliente)
        {
            var viewModel = (ListaClienteViewModel)BindingContext;
            viewModel.EditarCommand.Execute(cliente);
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Views.NovoCliente());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = sender as MenuItem;

            Cliente cliente = selecionado.BindingContext as Cliente;

            bool confirm = await DisplayAlert("Tem Certeza?", $"Remover {cliente.Name}?", "Sim", "Não");

            if (confirm)
            {
                await App.Db.Delete(cliente.Id);

                var viewModel = (ListaClienteViewModel)BindingContext;
                viewModel.Clientes.Remove(cliente);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }
}
