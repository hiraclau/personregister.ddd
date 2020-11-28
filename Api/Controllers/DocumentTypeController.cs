﻿using Application.Commands.DocumentType;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/documenttype")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private IGenericRepository<DocumentType> _repository;
        private IGenericHandler<DocumentTypeCreateCommand> _handler;

        public DocumentTypeController(IGenericRepository<DocumentType> repository, IGenericHandler<DocumentTypeCreateCommand> handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_repository.SearchById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] DocumentTypeCreateCommand command)
        {
            return Ok(_handler.Handle(command));
        }
    }
}
