using WebApplication2.DTOs;
namespace WebApplication2.models
{
    public class SalvarTXT
    {
       
        public List<FornecedorDTOs> Fornecedores = new List<FornecedorDTOs>();
        string caminhoArquivo;
        public SalvarTXT(string caminhoarquivo)
        {
            this.caminhoArquivo = caminhoarquivo;
            Fornecedores = CarregarFornecedores();
        }

        public List<FornecedorDTOs> CarregarFornecedores()
        {
            var fornecedores = new List<FornecedorDTOs>();

            if (File.Exists(caminhoArquivo))
            {
                var linha1 = File.ReadAllLines(caminhoArquivo);
                foreach (var linha2 in linha1)
                {
                    var campos = linha2.Split('|');
                    if (campos.Length == 9)
                    {
                        fornecedores.Add(new FornecedorDTOs
                        {
                            NomeFantasia = campos[0],
                            RazaoSocial = campos[1],
                            CNPJ = campos[2],
                            Endereco = campos[3],
                            Cidade = campos[4],
                            Estado = campos[5],
                            Telefone = campos[6],
                            Email = campos[7],
                            Responsavel = campos[8]
                        });
                    }
                }
            }

            return fornecedores;
        }

        public void SalvarFornecedores()
        {
            var linha1 = Fornecedores.Select(f =>
                $"{f.NomeFantasia}|{f.RazaoSocial}|{f.CNPJ}|{f.Endereco}|{f.Cidade}|{f.Estado}|{f.Telefone}|{f.Email}|{f.Responsavel}");
            File.WriteAllLines(caminhoArquivo, linha1);
        }
    }
}