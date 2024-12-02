using CadastroClientes.DataBase;

namespace CadastroClientes
{
    public partial class App : Application
    {
        static SQLiteDataBase _db;

        public static SQLiteDataBase Db
        { 
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine
                    (
                        Environment.GetFolderPath (
                            Environment.SpecialFolder.LocalApplicationData),
                            "banco_sqlite_clientes.db3"
                    );
                    _db = new SQLiteDataBase(path);
                }
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaCLiente());
        }
    }
}
