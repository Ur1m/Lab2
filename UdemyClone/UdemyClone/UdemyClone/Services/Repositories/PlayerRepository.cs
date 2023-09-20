using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UdemyClone.Database;
using UdemyClone.DTO;
using UdemyClone.Models;
using UdemyClone.Services.Interfaces;

namespace UdemyClone.Services.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private ProductDB _db;
        private readonly IMapper _mapper;

        public PlayerRepository(ProductDB db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddPlayer(PlayerDto playerDto)
        {

            playerDto.BirthDay = new System.DateTime(playerDto.BirthDay.Year, playerDto.BirthDay.Month, playerDto.BirthDay.Day);
            _db.players.Add(_mapper.Map<Player>(playerDto));
            _db.SaveChanges();

        }

        public List<PlayerDto> GetAllPLayers()
        {
            var tt =_db.players.Include(x=>x.Team).Select(x=> new PlayerDto
            {
                Name = x.Name,
                TeamId = x.TeamId,
                BirthDay = x.BirthDay,
                Team = _mapper.Map<TeamDTO>(x.Team)
            }).ToList();

            return tt;
        }
        public List<PlayerDto> GetAllPLayersByBirthYear(int year)
        {
            var tt = _db.players.Include(x => x.Team).Select(x => new PlayerDto
            {
                Name = x.Name,
                TeamId = x.TeamId,
                BirthDay = x.BirthDay,
                Team = _mapper.Map<TeamDTO>(x.Team)
            }).Where(x=>x.BirthDay.Year == year).ToList();

            return tt;
        }

        public void Update(Player player)
        {
            var tt = _db.players.Where(x => x.Id == player.Id).FirstOrDefault();

            tt.Name = player.Name;
            tt.BirthDay = player.BirthDay;
            tt.TeamId = player.TeamId;

            _db.Update(tt);
            _db.SaveChanges();
        }
    }
}
