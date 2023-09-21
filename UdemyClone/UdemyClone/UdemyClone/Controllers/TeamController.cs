using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UdemyClone.DTO;
using UdemyClone.Services.Interfaces;
using UdemyClone.Services.Repositories;
using UdemyClone.Models;

namespace UdemyClone.Controllers
{
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPlayerRepository _playerRepository;

        public TeamController(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }

        [HttpPost("addSatelite")]
        public async Task<ActionResult> AddSatekite(SateliteDto team)
        {
            try
            {
                _teamRepository.AddSatelite(team);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("addPlanet")]
        public async Task<ActionResult> addPlanet(PlanetDto team)
        {
            try
            {
                _teamRepository.AddPlanet(team);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("getAllPLanets")]
        public ActionResult<List<PlanetDto>> GetAllPLanets()
        {
            var categ = _teamRepository.GetAllPlantes();

            return categ;

            if (categ == null)
            {
                return BadRequest();
            }

            return Ok(categ);
        }

        [HttpGet("getAllSatelites")]
        public ActionResult<List<SateliteDto>> GetAllSatelites(string name)
        {
            var categ = _teamRepository.Getallbyplanetname(name);

            return categ;

            if (categ == null)
            {
                return BadRequest();
            }

            return Ok(categ);
        }

        [HttpGet("getPlayersByBirthYear")]
        public ActionResult<List<PlayerDto>> GetPlayersByBirthYEar(int year)
        {
            var categ = _playerRepository.GetAllPLayersByBirthYear(year);

            return categ;

            if (categ == null)
            {
                return BadRequest();
            }

            return Ok(categ);
        }  
        [HttpGet("updatePLayer")]
        public ActionResult<List<PlayerDto>> UpdatePLayer(Player player)
        {
            _playerRepository.Update(player);

            return Ok();
        }

        [HttpGet("updateTeam")]
        public ActionResult<List<PlayerDto>> UpdateTeam(Team team)
        {
            _teamRepository.Update(team);

            return Ok();
        }
        [HttpGet("getPLayersByTeam")]
        public ActionResult<List<PlayerDto>> GetPLayersByTeam(string team)
        {
          var tt=  _playerRepository.GetPlayersByTeam(team);

            return tt;
        }
    }
}
