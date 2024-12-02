using SQLite;

namespace CadastroClientes.Models
{
    public class Cliente
    {
        string _name;
        string _lastname;
        int _age;
        string _address;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                if(value == null)
                {
                    throw new Exception("Por favor, preencha o nome");
                }

                _name = value;
            }
        }
        public string Lastname
        {
            get => _lastname;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o sobrenome");
                }

                _lastname = value;
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a idade");
                }

                _age = value;
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha o endereço");
                }

                _address = value;
            }
        }
    }

}
