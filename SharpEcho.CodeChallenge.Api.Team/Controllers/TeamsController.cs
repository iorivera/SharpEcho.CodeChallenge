using Microsoft.AspNetCore.Mvc;
using SharpEcho.CodeChallenge.Api.Team.Entities;
using SharpEcho.CodeChallenge.Data;
using System;
using System.Linq;
using System.Xml.Linq;

namespace SharpEcho.CodeChallenge.Api.Team.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : GenericController<Entities.Team>
    {
        public TeamsController(IRepository repository) : base(repository)
        {
        }

        [HttpGet("GetTeamByName")]
        public virtual ActionResult<Entities.Team> GetTeamByName(string name)
        {
            var result = Repository.Query<Entities.Team>("SELECT * FROM Team WHERE Name = @Name", new { Name = name });
            if (result != null && result.Count() > 0)
            {
                return result.First();
            }
            return NotFound();
        }

        /// <summary>
        /// Takes in a Match object to record outcome of the game
        /// </summary>
        /// <param name="match"></param>
        /// <returns>boolean to indicated record was saved successfully</returns>
        [HttpPost("RecordMatch")]
        public string RecordMatch(Match match)
        {
            string result = string.Empty;

            try
            {
               var matchRecord = Repository.Insert(match);

                result = "Match Recorded Successfully!" + matchRecord;
            }
            catch (Exception e) {

                result = "Unable to record match: " + e.Message;
            }

            return result;
        }


        [HttpGet("GetWinLoss")]
        public string GetWinLoss(Match match)
        {
            string result = string.Empty;
            try
            {
                //select * from Team where Team1 = match.team1 or match.team 2 and  Team2 = match.team1 or match.team 2 and 

                var WinLossResult = Repository.Query<Entities.Team>("SELECT * FROM Match WHERE Team1ID = @TeamID1 Or", new { TeamID1 = match.Team1ID });

                result = "Match Recorded Successfully!";
            }
            catch (Exception e)
            {

                result = "Unable to record match: " + e.Message;
            }

            return result;
        }

    }


}


