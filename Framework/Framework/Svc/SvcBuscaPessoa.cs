using BlazorTask.Framework;
using Blazored.LocalStorage;

namespace Framework.Svc
{
    public class SvcBuscaPessoa
    {
        private readonly ILocalStorageService _localStorage;
        private const string CacheKey = "ListaPessoas";

        public SvcBuscaPessoa(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            var pessoas = await _localStorage.GetItemAsync<List<Pessoa>>(CacheKey);
            if (pessoas == null)
            {
                await _localStorage.SetItemAsync(CacheKey, pessoas);
                Console.WriteLine($"Lista carregada do LocalStorage.{pessoas}");
            }

            return pessoas;
        }

        public async Task AddPessoa(Pessoa novaPessoa)
        {
            var pessoas = await GetPessoas();

            // Verifica se a lista está vazia antes de tentar pegar o valor máximo do ID
            if (pessoas.Any())
            {
                // Define o novo ID como o maior ID atual + 1
                novaPessoa.Id = pessoas.Max(p => p.Id) + 1;
            } else
            {
                // Se a lista estiver vazia, o ID inicial será 1
                novaPessoa.Id = 1;
            }

            // Adiciona a nova pessoa à lista
            pessoas.Add(novaPessoa);

            // Atualiza o cache com a nova lista
            await _localStorage.SetItemAsync(CacheKey, pessoas);
        }


        public async Task DeletePessoa(int id)
        {
            var pessoas = await _localStorage.GetItemAsync<List<Pessoa>>(CacheKey); //carrega a lista do cache

            if (pessoas != null)
            {
                var pessoaASerRemovida = pessoas.FirstOrDefault(x => x.Id == id);
                if (pessoaASerRemovida != null)
                {
                    pessoas.Remove(pessoaASerRemovida);

                    await _localStorage.SetItemAsync(CacheKey, pessoas);

                    Console.WriteLine($"Pessoa com ID {id} removida com sucesso.");
                } else
                {
                    Console.WriteLine($"Pessoa com ID {id} não encontrada.");
                }
            }
        }










        //public List<Pessoa> pessoas = new List<Pessoa>
        //{
        //    new Pessoa { Nome = "João Silva", CpfCnpj = "11122233344", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Maria Oliveira", CpfCnpj = "55566677788", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa ABC", CpfCnpj = "12345678000199", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Carlos Souza", CpfCnpj = "12345678900", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa XYZ", CpfCnpj = "98765432000110", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Ana Paula", CpfCnpj = "22233344455", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Pedro Santos", CpfCnpj = "66677788899", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa Tech", CpfCnpj = "01234567000123", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Clara Lima", CpfCnpj = "23456789012", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Eduardo Souza", CpfCnpj = "34567890123", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa Alpha", CpfCnpj = "11222333000144", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Roberto Carlos", CpfCnpj = "12378945600", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Patricia Lima", CpfCnpj = "45678912388", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa Beta", CpfCnpj = "55666777000199", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Fernanda Costa", CpfCnpj = "56789012345", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Marcos Vinicius", CpfCnpj = "67890123456", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa Gamma", CpfCnpj = "77888999000111", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Sofia Alves", CpfCnpj = "78901234567", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Lucas Mendes", CpfCnpj = "89012345678", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa Omega", CpfCnpj = "99111222000133", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Gabriela Dias", CpfCnpj = "90123456789", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Ricardo Ferreira", CpfCnpj = "01234567890", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Empresa Sigma", CpfCnpj = "88999000000122", Tipo = "Juridica" },
        //    new Pessoa { Nome = "Juliana Souza", CpfCnpj = "12345678901", Tipo = "Fisica" },
        //    new Pessoa { Nome = "Thiago Lima", CpfCnpj = "23456789012", Tipo = "Fisica" }
        //};
    }

}
