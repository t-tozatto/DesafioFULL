using DesafioFULL.Application.DTO;
using DesafioFULL.Application.Interface;
using DesafioFULL.ApplicationDTO.DTO;
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

            return Ok(titulos.Select(x => new TituloFrontDTO(x)));
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            TituloDTO titulo = _applicationServiceTitulo.GetById(id);
            titulo.Parcela = _applicationServiceParcela.GetByProperty("Titulo", titulo.Id).ToList();

            return Ok(new TituloFrontDTO(titulo));
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

                return Ok();
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                _applicationServiceParcela.RemoveByTitulo(id);
                _applicationServiceTitulo.Remove(id);
                return Ok();
            }
            catch
            {
                throw;
            }
        }
    }
}
