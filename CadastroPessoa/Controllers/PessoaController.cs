using CadastroPessoa.Database;
using CadastroPessoa.Models;
using CadastroPessoa.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Controllers
{
    public class PessoaController : Controller
    {
        private readonly PessoaService _pessoaService;

        public PessoaController(PessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public JsonResult Listar()
        {
            List<Pessoa> listaPessoa = new List<Pessoa>();
            listaPessoa = _pessoaService.ListarPessoa();
            return Json(listaPessoa);
        }

        [HttpPost]
        public Pessoa Salvar([FromBody]Pessoa CriarPessoa)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = CriarPessoa.Nome;
            pessoa.CPF = CriarPessoa.CPF;
            pessoa.Sexo = CriarPessoa.Sexo;
            pessoa.Cidade = CriarPessoa.Cidade;
            pessoa.Idade = CriarPessoa.Idade;
            pessoa.Estado = CriarPessoa.Estado;

            pessoa = _pessoaService.SalvarPessoa(pessoa);
            return pessoa;
        }

        [HttpPut]
        public Pessoa Editar([FromBody] Pessoa pessoa)
        {
            _pessoaService.EditarPessoa(pessoa);
            return pessoa;
        }
        [HttpDelete]
        public string Deletar(int id)
        {
            _pessoaService.DeletarPessoa(id);
            return "Ok";
        }

        [HttpGet]
        public Pessoa PreencherEdicao(int id)
        {
            Pessoa pessoaParaEditar = new Pessoa();
            pessoaParaEditar = _pessoaService.BuscaPorId(id);
            return pessoaParaEditar;
        }
    }
}
