using Microsoft.AspNetCore.Mvc;
using WebApplication2.models;
using WebApplication2.DTOs;

namespace WebApplication2.Controllers
{
    [Route("Fornecedor")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        SalvarTXT salvartxt;
        ValidaCNPJ validaCNPJ = new ValidaCNPJ(); 

        public FornecedoresController()
        {
            string caminhoArquivo = "C:/Users/paulo/source/repos/WebApplication2/WebApplication2/teste.txt";
            salvartxt = new SalvarTXT(caminhoArquivo);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> Listar()
        {
            return Ok(salvartxt.Fornecedores);
        }

        [HttpGet("Buscar pelo nome fantasia")]
        public ActionResult<FornecedorDTOs> BuscarPorNome(string NomeFantasia)
        {
            var fornecedor = salvartxt.Fornecedores.FirstOrDefault(f => f.NomeFantasia == NomeFantasia);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

            [HttpGet("Buscar pelo CNPJ")]

        public ActionResult<Fornecedor> Buscar(string CNPJ)
        {
            var fornecedor = salvartxt.Fornecedores.FirstOrDefault(f => f.CNPJ == CNPJ);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost("Criar")]
        public ActionResult Criar([FromBody] FornecedorDTOs fornecedordtos)
        {
       
           if (!ValidarFornecedor(fornecedordtos))
           {
                return BadRequest("CNPJ inválido.");
           }

            salvartxt.Fornecedores.Add(fornecedordtos);
            salvartxt.SalvarFornecedores();
            return CreatedAtAction(nameof(Buscar), new { cnpj = fornecedordtos.CNPJ }, fornecedordtos);
        }

        [HttpPut("Atualizar")]
        public ActionResult Atualizar(string NomeFantasia, [FromBody] FornecedorDTOs fornecedorAtualizado)
        {
            var fornecedor = salvartxt.Fornecedores.FirstOrDefault(f => f.NomeFantasia == NomeFantasia);
            if (fornecedor == null)
            {
                return NotFound();
            }

            salvartxt.Fornecedores.Remove(fornecedor);
            salvartxt.Fornecedores.Add(fornecedorAtualizado);
            salvartxt.SalvarFornecedores();
            return NoContent();
        }

        [HttpDelete("Excluir pelo nome fantasia")]
        public ActionResult ExcluirPorNome(string NomeFantasia)
        {
            var fornecedor = salvartxt.Fornecedores.FirstOrDefault(f => f.NomeFantasia == NomeFantasia);
            if (fornecedor == null)
            {
                return NotFound();
            }

            salvartxt.Fornecedores.Remove(fornecedor);
            salvartxt.SalvarFornecedores();
            return NoContent();
        }

        [HttpDelete("Excluir pelo CNPJ")]
        public ActionResult Excluir(string cnpj)
        {
            var fornecedor = salvartxt.Fornecedores.FirstOrDefault(f => f.CNPJ == cnpj);
            if (fornecedor == null)
            {
                return NotFound();
            }

            salvartxt.Fornecedores.Remove(fornecedor);
            salvartxt.SalvarFornecedores();
            return NoContent();
        }

        private bool ValidarFornecedor(FornecedorDTOs fornecedordtos)
        {
            return validaCNPJ.ValidarCNPJ(fornecedordtos.CNPJ); 
        }
    }
}
