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
    public class SongController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SongController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Song where SongId=@SongId
                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SongId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Song song)
        {
            string query = @"
                           update dbo.Song set 
                            SongName = @SongName, 
                            Artist = @Artist,
                            Genre = @Genre,
                            DateOfRelease = @DateOfRelease
                            where SongId=@SongId

                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SongId", song.SongId);
                    myCommand.Parameters.AddWithValue("@SongName", song.SongName);
                    myCommand.Parameters.AddWithValue("@Artist", song.Artist);
                    myCommand.Parameters.AddWithValue("@Genre", song.Genre);
                    myCommand.Parameters.AddWithValue("@DateOfRelease", song.DateOfRelease);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpPost]
        public JsonResult Post(Song song)
        {
            string query = @"
                           insert into dbo.Song
                            (SongName, Artist, Genre, DateOfRelease) values
                            (@SongName, @Artist, @Genre, @DateOfRelease)
                           ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MusicListingAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SongName", song.SongName);
                    myCommand.Parameters.AddWithValue("@Artist", song.Artist);
                    myCommand.Parameters.AddWithValue("@Genre", song.Genre);
                    myCommand.Parameters.AddWithValue("@DateOfRelease", song.DateOfRelease);

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
                           select SongId, SongName, Artist, Genre, convert(varchar(10),DateOfRelease,120) as DateOfRelease from dbo.Song
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
