using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using ArtistMVC.Models;

namespace ArtistMVC.Repositories
{
    public class ArtistRepository
    {
        public List<ArtistModel> GetAll(int id)
        {
            List<ArtistModel> artists = new List<ArtistModel>();
            string connectionString = "[YOUR CONNECTION STRING HERE]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("usp_ArtistSpotify_Select", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ArtistModel artist = new ArtistModel();
                    artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);
                    artist.Name = reader["Name"].ToString();
                    artist.SpotifyId = reader["SpotifyId"].ToString();
                    artists.Add(artist);
                }
                reader.Close();
            }
            return artists;
        }
    }
}