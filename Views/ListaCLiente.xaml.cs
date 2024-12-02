using System.Collections.ObjectModel;
using CadastroClientes.Models;

namespace CadastroClientes.Views;

public partial class ListaCLiente : ContentPage
{
    ObservableCollection<Cliente> lista = new ObservableCollection<Cliente>();
    public ListaCLiente()
    {
        InitializeComponent();

        lst_clientes.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();
            List<Cliente> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoCliente());

        }
        catch (Exception ex)
        {
            DisplayAlert("Atenção", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Cliente> tmp = await App.Db.Search(q);

            tmp.ForEach(i => lista.Add(i));
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

            Cliente p = selecionado.BindingContext as Cliente;

            bool confirm = await DisplayAlert("Tem Certeza?", $"Remover {p.Name}?", "Sim", "Não");
            if (confirm)
            {
                await App.Db.Delete(p.Id);
                lista.Remove(p);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }

    private void lst_clientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Cliente p = e.SelectedItem as Cliente;
            Navigation.PushAsync(new Views.EditarCliente
            {
                BindingContext = p,
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Atenção", ex.Message, "OK");
        }
    }
}