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

        public void AddTeam(TeamDTO prodDTO)
        {
            try
            {



                _db.teams.Add(_mapper.Map<Team>(prodDTO));

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }
            public List<TeamDTO > GetAllTeams()
            {
                try
                {
                   var teams = _db.teams.Include(x=>x.Players).Select(x=> new TeamDTO
                   {
                       Name= x.Name,
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

    }
}
