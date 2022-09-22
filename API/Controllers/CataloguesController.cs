
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    public class CataloguesController : BaseApiController
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CataloguesController(IUnitOfWork unitOfWork, IMapper mapper)
        {            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("estado-civil")]
        public async Task<ActionResult<IReadOnlyList<EstadoCivilDto>>> GetEstadoCivil()
        {
            var estadoCivil = await _unitOfWork.Repository<EstadoCivil>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<EstadoCivilDto>>(estadoCivil));           
        }

        [HttpGet("tipo-prestamo")]
        public async Task<ActionResult<IReadOnlyList<TipoPrestamoDto>>> GetTipoPrestamo()
        {
            var tipoPrestamo = await _unitOfWork.Repository<TipoPrestamo>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<TipoPrestamoDto>>(tipoPrestamo));
        }

        [HttpGet("destino-prestamo")]
        public async Task<ActionResult<IReadOnlyList<DestinoPrestamoDto>>> GetDestinoPrestamo()
        {
            var destinoPrestamo = await _unitOfWork.Repository<DestinoPrestamo>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<DestinoPrestamoDto>>(destinoPrestamo));
        }

        [HttpGet("gestores")]
        public async Task<ActionResult<IReadOnlyList<GestorDto>>> GetGestores()
        {
            var gestores = await _unitOfWork.Repository<Gestor>().ListAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<GestorDto>>(gestores));
        }


    }
}
