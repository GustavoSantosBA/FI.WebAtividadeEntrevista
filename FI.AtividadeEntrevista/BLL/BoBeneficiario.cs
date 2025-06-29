using FI.AtividadeEntrevista.DML;
using FI.AtividadeEntrevista.DAL;
using System.Collections.Generic;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiário
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiário</param>
        public long Incluir(Beneficiario beneficiario)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            return dao.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um beneficiário
        /// </summary>
        public void Alterar(Beneficiario beneficiario)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            dao.Alterar(beneficiario);
        }

        /// <summary>
        /// Exclui um beneficiário pelo ID
        /// </summary>
        public void Excluir(long id)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            dao.Excluir(id);
        }

        /// <summary>
        /// Lista os beneficiários de um cliente
        /// </summary>
        public List<Beneficiario> ListarPorCliente(long idCliente)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            return dao.ListarPorCliente(idCliente);
        }

        /// <summary>
        /// Verifica se já existe CPF de beneficiário para um cliente
        /// </summary>
        public bool VerificarExistencia(string cpf, long idCliente)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            return dao.VerificarExistencia(cpf, idCliente);
        }
    }
}
