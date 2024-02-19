﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetClubApi.Model;
using NetClubApi.Model.ResponseModel;

namespace NetClubApi.LeagueModule
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueDataAccess _leagueDataAccess;
        private readonly ILeagueBussinessLayer _leagueBussinessLayer;
        public LeagueController(ILeagueDataAccess leagueDataAccess,ILeagueBussinessLayer leagueBussinessLayer)
        {
            _leagueDataAccess = leagueDataAccess;
            _leagueBussinessLayer = leagueBussinessLayer;
        }
        [HttpPost]
        [Authorize]

       //only admin can create the createLeague
        public async Task<string> CreateLeague(League league)

        {
            int user_id = int.Parse(User.FindFirst("id").Value);
            return await _leagueDataAccess.CreateLeague(league,user_id);
            
        }

        [HttpGet]
        [Authorize]
        public async Task<List<LeagueResponse>> GetClubLeagues(int club_Id)
        {
            return await _leagueBussinessLayer.GetClubLeagues(club_Id);
        }

        [HttpGet]
        [Authorize]
        public async Task<int?> GetLeagueMatches(int league_id)
        {
            return await _leagueBussinessLayer.GetLeagueMatches(league_id);
        }
        public async Task<string> RegisterLeague(int league_id)
        {

        }

    }
}
