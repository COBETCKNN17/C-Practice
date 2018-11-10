using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DojoLeague.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace DojoLeague.Factories {
    public class NinjaFactory {
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

        public void create_ninja (Ninja ninja) {
            using (IDbConnection dbConnection = Connection) {
                var query = "INSERT INTO Ninjas (Ninjas.name, Ninjas.location, Ninjas.description, Ninjas.dojo_id) VALUE (@name, @location, @description, @dojo_id)";
                dbConnection.Open ();
                dbConnection.Execute (query);
            }
        }

        public IEnumerable<Models.Ninja> getAllNinjas () {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open ();
                return dbConnection.Query<Models.Ninja> ("SELECT * FROM Ninjas");
            }
        }

        public Ninja FindByID (int id) {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open ();
                return dbConnection.Query<Ninja> ("SELECT * FROM Ninjas WHERE id = @Id", new { Id = id }).FirstOrDefault ();
            }
        }
    }
}