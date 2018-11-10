using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories {
    public class DojoFactory {
        string Server = "localhost";
        string Port = "3306";
        string Database = "DojoLeague";
        string UserId = "root";
        string Password = "password";

        internal IDbConnection Connection {
            get {
                return new MySqlConnection ($"Server={Server};Port={Port};Database={Database};UserID={UserId};Password={Password};SslMode=None");
            }
        }
        public void create_dojo (Dojo dojo) {
            using (IDbConnection dbConnection = Connection) {
                var query = "INSERT INTO Dojos (Dojos.name, Dojos.location, Dojos.description) VALUE (@name, @location, @description)";
                // var query = "INSERT INTO Dojos (Dojos.name) VALUE (@name)";
                dbConnection.Open();
                dbConnection.Execute (query, dojo);
            }
        }

        public IEnumerable<Models.Dojo> getAllDojos () {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open ();
                return dbConnection.Query<Models.Dojo>("SELECT * FROM Dojos");
            }
        }

        public Dojo FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM Dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}