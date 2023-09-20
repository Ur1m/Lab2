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

        [HttpPost("addTeam")]
        public async Task<ActionResult> AddTeam(TeamDTO team)
        {
            try
            {
                _teamRepository.AddTeam(team);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("addPlayer")]
        public async Task<ActionResult> AddPlayer(PlayerDto team)
        {
            try
            {
                _playerRepository.AddPlayer(team);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("getTeams")]
        public ActionResult<List<TeamDTO>> GetTeams()
        {
            var categ = _teamRepository.GetAllTeams();

            return categ;

            if (categ == null)
            {
                return BadRequest();
            }

            return Ok(categ);
        }

        [HttpGet("getPlayers")]
        public ActionResult<List<PlayerDto>> GetPlayers()
        {
            var categ = _playerRepository.GetAllPLayers();

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
    }
}
