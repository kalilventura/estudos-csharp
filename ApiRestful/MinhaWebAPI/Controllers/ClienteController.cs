using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaWebAPI.Util;
using System.Data;
using MinhaWebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace MinhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {        
        Autenticacao AutenticacaoServico;

        public ClienteController(IHttpContextAccessor context)
        {            
            AutenticacaoServico = new Autenticacao(context);
        }
   
        [HttpGet]
        [Route("listagem")]        
        public List<ClienteModel> Listagem()
        {            
            return new ClienteModel().Listagem();
        }
  
        [HttpGet]
        [Route("cliente/{id}")]
        public ClienteModel RetornarCliente(int id)
        {
            return new ClienteModel().RetornarCliente(id);
        }

        [HttpPost]        
        [Route("registrarcliente")]
        public ReturnAllServices RegistrarCliente([FromBody]ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente: " + ex.Message;
            }

            return retorno;
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody]ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Id = id;
                dados.AtualizarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar um cliente: " + ex.Message;
            }

            return retorno;
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente excluído com sucesso!";
                AutenticacaoServico.Autenticar();
                new ClienteModel().Excluir(id);

            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}
