using AutoMapper;
using System.Collections.Generic;
using UdemyClone.Database;
using UdemyClone.DTO;
using UdemyClone.Models;

namespace UdemyClone.Services.Interfaces
{
    public interface IPlayerRepository
    {
        void AddPlayer(PlayerDto playerDto);
        List<PlayerDto> GetAllPLayers();
        List<PlayerDto> GetAllPLayersByBirthYear(int year);
        void Update(Player player);
        List<PlayerDto> GetPlayersByTeam(string team);


    }
}
