﻿using Microsoft.AspNetCore.Mvc;
using ProjetoControleContatosMVC.Models;
using ProjetoControleContatosMVC.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoControleContatosMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List <ContatoModel> contatos =_contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }      
        
        public IActionResult ExcluirConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }


        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Excluir(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso! ";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente!";
                }
                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente! Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso! ";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
             catch(SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente! Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso! ";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch(SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente! Detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
