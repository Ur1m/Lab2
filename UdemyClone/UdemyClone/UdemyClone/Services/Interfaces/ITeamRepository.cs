using System.Collections.Generic;
using UdemyClone.DTO;
using UdemyClone.Models;

namespace UdemyClone.Services.Interfaces
{
    public interface ITeamRepository
    {
        void AddTeam(TeamDTO prodDTO);
        List<TeamDTO> GetAllTeams();
        void Update(Team team);


    }
}
