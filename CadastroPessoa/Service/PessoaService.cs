using CadastroPessoa.Database;
using CadastroPessoa.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CadastroPessoa.Service
{
    //Camada responsável pela regra de negócios
    public class PessoaService : DbContext
    {
        private BancoOficialWebPicContext _conexaoBanco;
        public PessoaService(BancoOficialWebPicContext conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
        }

        public List<Pessoa> ListarPessoa()
        {
            List<Pessoa> listaPessoa = _conexaoBanco.Pessoa.ToList();

            return listaPessoa;
        }
        public Pessoa SalvarPessoa(Pessoa CriarPessoa)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = CriarPessoa.Nome;
            pessoa.CPF = CriarPessoa.CPF;
            pessoa.Sexo = CriarPessoa.Sexo;
            pessoa.Cidade = CriarPessoa.Cidade;
            pessoa.Idade = CriarPessoa.Idade;
            pessoa.Estado = CriarPessoa.Estado;

            _conexaoBanco.Pessoa.Add(pessoa);
            _conexaoBanco.SaveChanges();
            return pessoa;
        }
        public void EditarPessoa(Pessoa pessoa)
        {
            _conexaoBanco.Pessoa.Update(pessoa);
            _conexaoBanco.SaveChanges();
        }
        public void DeletarPessoa(int id)
        {
            var obj = _conexaoBanco.Pessoa.Find(id);
            _conexaoBanco.Pessoa.Remove(obj);
            _conexaoBanco.SaveChanges();
        }

        public Pessoa BuscaPorId(int id)
        {
            return _conexaoBanco.Pessoa.FirstOrDefault(obj => obj.Id == id);
        }
    }
}
