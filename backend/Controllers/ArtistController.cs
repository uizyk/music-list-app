using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MusicListingApp.Models;

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

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Artist where ArtistId=@ArtistId
                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ArtistId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Artist art)
        {
            string query = @"
                           update dbo.Artist set ArtistName = @ArtistName where ArtistId=@ArtistId
                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ArtistId", art.ArtistId);
                    myCommand.Parameters.AddWithValue("@ArtistName", art.ArtistName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpPost]
        public JsonResult Post(Artist art)
        {
            string query = @"
                           insert into dbo.Artist values (@ArtistName)
                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ArtistName", art.ArtistName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                           select ArtistId, ArtistName from dbo.Artist
                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand(query, myCon))
                {

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }
    }
}
