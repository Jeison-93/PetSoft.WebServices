﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Dto.Pet;

namespace PetSoft.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetAppService _PetAppService;
        public PetController(IPetAppService PetAppService)
        {
            _PetAppService = PetAppService;
        }
        [HttpGet]
        [Route("Get")]

        public PetGetDto Get(int id)
        {
            return _PetAppService.Get(id);
        }
        [HttpPost]
        [Route("save")]

        public string save(PetSaveDto parameter)
        {
            return _PetAppService.Save(parameter);
        }
    }
}
