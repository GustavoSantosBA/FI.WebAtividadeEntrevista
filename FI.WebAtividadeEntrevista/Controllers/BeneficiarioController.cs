using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        private readonly BoBeneficiario _bo = new BoBeneficiario();

        [HttpPost]
        public JsonResult Incluir(Beneficiario model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                var erros = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();
                return Json(string.Join(Environment.NewLine, erros));
            }

            // Verifica se já existe CPF para o cliente
            if (_bo.VerificarExistencia(model.CPF, model.IdCliente))
            {
                Response.StatusCode = 400;
                return Json("Já existe um beneficiário com este CPF para este cliente");
            }

            model.Id = _bo.Incluir(model);
            return Json("Beneficiário cadastrado com sucesso");
        }

        [HttpPost]
        public JsonResult Alterar(Beneficiario model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                var erros = (from item in ModelState.Values
                             from error in item.Errors
                             select error.ErrorMessage).ToList();
                return Json(string.Join(Environment.NewLine, erros));
            }

            _bo.Alterar(model);
            return Json("Beneficiário alterado com sucesso");
        }

        [HttpPost]
        public JsonResult Excluir(long id)
        {
            _bo.Excluir(id);
            return Json("Beneficiário excluído com sucesso");
        }

        [HttpGet]
        public JsonResult Listar(long idCliente)
        {
            try
            {
                if (idCliente <= 0)
                {
                    return Json(new List<Beneficiario>(), JsonRequestBehavior.AllowGet);
                }

                var lista = _bo.ListarPorCliente(idCliente);
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json($"Erro ao listar beneficiários: {ex.Message}", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
