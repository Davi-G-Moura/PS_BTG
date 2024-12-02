using CadastroClientes.Models;

namespace CadastroClientes.Views;

public partial class EditarCliente : ContentPage
{
	public EditarCliente()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Cliente cliente_anexado = BindingContext as Cliente;

            Cliente p = new Cliente
            {
                Id = cliente_anexado.Id,
                Name = txt_nome.Text,
                Lastname = txt_sobrenome.Text,
                Age = Convert.ToInt32(txt_idade.Text),
                Address = txt_endereco.Text,
            };
            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", "Cliente Atualizado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Atenção", ex.Message, "OK");
        }
    }
}