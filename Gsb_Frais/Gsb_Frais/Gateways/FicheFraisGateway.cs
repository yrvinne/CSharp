using Dapper;
using Gsb_Frais.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gsb_Frais.Gateways
{
    public class FicheFraisGateway
    {
        string _connectionString;

        public FicheFraisGateway(string connectionString)
        {
            _connectionString = DatabaseHelpers.ConnectionString;
        }

        public IEnumerable<FicheFrais> GetAll()
        {
            string sql = @"SELECT * FROM gsb_frais.fichefrais;";

            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<FicheFrais>(sql);
            }
        }

        public void UpdateLastMonthToCL()
        {
            string sql = @"update gsb_frais.fichefrais set idetat = 'CL' where idvisisteur = @Id where datemodif >= @startDate and datemodif <= @endDate";

            var list = GetAll().Where(p => p.MoisToDateTime().Month < DateTime.Now.Month);

            var currentdate = DateTime.Now;
            var startDate = new DateTime(currentdate.Year, currentdate.Month, 1).ToString("yyyy-MM-dd");
            var endDate = new DateTime(currentdate.Year, currentdate.Month, 10).ToString("yyyy-MM-dd");

            using (var connection = new MySqlConnection(_connectionString))
            {

                foreach (FicheFrais p in list)
                {
                    var affectedRows = connection.Execute(sql, new { Id = p.IdVisiteur, startDate = startDate, endDate = endDate });
                    Console.WriteLine(affectedRows);
                }
            }
        }

        public void UpdateToRB()
        {
            string sql = @"update gsb_frais.fichefrais set idetat = 'RB' where idvisiteur = @Id and datemodif >= @startDate and datemodif <= @endDate";

            var list = GetAll();

            var currentdate = DateTime.Now;
            var year = currentdate.Year;
            var month = currentdate.Month;
            var startDate = new DateTime(year, month, 20).ToString("yyyy-MM-dd");
            var endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month)).ToString("yyyy-MM-dd");

            using (var connection = new MySqlConnection(_connectionString))
            {

                foreach (FicheFrais p in list)
                {
                    var affectedRows = connection.Execute(sql, new { Id = p.IdVisiteur, startDate = startDate, endDate = endDate });
                    Console.WriteLine(affectedRows);
                }
            }
        }
    }
}

