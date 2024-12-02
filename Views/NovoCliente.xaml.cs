using CadastroClientes.Models;

namespace CadastroClientes.Views;

public partial class NovoCliente : ContentPage
{
	public NovoCliente()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Cliente p = new Cliente
			{
				Name = txt_nome.Text,
				Lastname = txt_sobrenome.Text,
				Age = Convert.ToInt32(txt_idade.Text),
				Address = txt_endereco.Text,
			};
			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Cliente Salvo", "OK");
            MessagingCenter.Send(this, "AtualizarLista");
            await Navigation.PopAsync();
        } 
		catch (Exception ex)
		{
			await DisplayAlert("Atenção", ex.Message, "OK");
		}
    }
}