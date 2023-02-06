using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MusicListingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ArtistController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select ArtistId, ArtistName from 
                    dbo.Artist
                    ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection sqlConnection
        }
    }
}
