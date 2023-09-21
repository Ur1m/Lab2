using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UdemyClone.Database;
using UdemyClone.DTO;
using UdemyClone.Models;
using UdemyClone.Services.Interfaces;

namespace UdemyClone.Services.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private ProductDB _db;
        private readonly IMapper _mapper;
        public TeamRepository(ProductDB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddPlanet(PlanetDto planetDto)
        {
            try
            {
                _db.planets.Add(_mapper.Map<Planet>(planetDto));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSatelite(SateliteDto planetDto)
        {
            try
            {
                _db.satelites.Add(_mapper.Map<Satelite>(planetDto));
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PlanetDto> GetAllPlantes()
        {
            return _mapper.Map<List<PlanetDto>>(_db.planets.ToList());

        }

        public void DeleteSatelite( int sateliteId)
        {
            var tt =_db.satelites.Where(x => x.Id == sateliteId).FirstOrDefault();
            tt.IsDeleted = false;

        }


        public List<SateliteDto> Getallbyplanetname(string name)
        {
          var tt =  _mapper.Map<List<SateliteDto>>(_db.satelites.Include(x => x.Planet).Where(x => x.Planet.Name == name).ToList());

            return tt;
        }
        public List<TeamDTO> GetAllTeams()
        {
            try
            {
                var teams = _db.teams.Include(x => x.Players).Select(x => new TeamDTO
                {
                    Name = x.Name,
                    Players = _mapper.Map<List<PlayerDto>>(x.Players)
                }).ToList();
                return teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Team team)
        {
            var tt = _db.teams.Where(x => x.Id == team.Id).FirstOrDefault();

            tt.Name = team.Name;

            _db.Update(tt);
            _db.SaveChanges();
        }

        public void AddTeam(TeamDTO prodDTO)
        {
            throw new NotImplementedException();
        }
    }
}
