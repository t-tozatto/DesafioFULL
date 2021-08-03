using DesafioFULL.Application.DTO;
using DesafioFULL.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TituloController : Controller
    {
        private readonly IApplicationServiceTitulo _applicationServiceTitulo;
        private readonly IApplicationServiceParcela _applicationServiceParcela;

        public TituloController(IApplicationServiceTitulo applicationServiceTitulo,
            IApplicationServiceParcela applicationServiceParcela)
        {
            _applicationServiceTitulo = applicationServiceTitulo;
            _applicationServiceParcela = applicationServiceParcela;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<TituloDTO> titulos =_applicationServiceTitulo.GetAll().ToList();

            for(int i = 0; i < titulos.Count(); i++)
                titulos[i].Parcela = _applicationServiceParcela.GetByProperty("Titulo", titulos[i].Id).ToList();

            return Ok(titulos);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            TituloDTO titulo = _applicationServiceTitulo.GetById(id);
            titulo.Parcela = _applicationServiceParcela.GetByProperty("Titulo", titulo.Id).ToList();

            return Ok(titulo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TituloDTO tituloDTO)
        {
            try
            {
                if (tituloDTO == null)
                    return NotFound();

                int? idTitulo = _applicationServiceTitulo.Add(tituloDTO);

                if (idTitulo.HasValue)
                {
                    tituloDTO.setId(idTitulo.Value);

                    foreach (ParcelaDTO p in tituloDTO.Parcela)
                        _applicationServiceParcela.Add(p);
                }

                return Ok("Título cadastrado com sucesso!");
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] TituloDTO tituloDTO)
        {
            try
            {
                if (tituloDTO == null)
                    return NotFound();

                _applicationServiceTitulo.Update(tituloDTO);
                return Ok("Título atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] TituloDTO tituloDTO)
        {
            try
            {
                if (tituloDTO == null)
                    return NotFound();

                _applicationServiceTitulo.Remove(tituloDTO);
                return Ok("Título excluído com sucesso!");
            }
            catch
            {
                throw;
            }
        }
    }
}
