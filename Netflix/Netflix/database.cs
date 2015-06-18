using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Netflix
{
    //dit is dus de datbase connectie
    public class database
    {
        private OracleConnection connectie = new OracleConnection();
        //De connectie string is opgeslagen in de webconfig onder de naam ConString, en word hieronder opgehaald.
        private string conn = WebConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public void Connectieopen()
        {
            // Opent de connectie met de database, sluit de connectie als er iets mis gaat.
            try
            {
                connectie = new OracleConnection();
                connectie.ConnectionString = WebConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                connectie.Open();
            }
            catch
            {
                connectie.Close();
            }

        }

        // Deze haalt alle shows op
        public List<string> GetShows()
        {
            List<string> resultaat = new List<string>();
            string sql;
            sql = "select titel from show";

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["titel"]));
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connectie.Close();
            }
            return resultaat;
        }

        //Deze controlleert of het emailadres en wachtwoord bij elkaar horen (of iemand dus goed inlogt)
        public bool checkLogin(string email, string password)
        {
            bool resultaat = false;
            string sql;
            sql = "select count (*) as aantal from account where emailadres = :email and wachtwoord = :password";

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("email", email));
                cmd.Parameters.Add(new OracleParameter("password", password));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["aantal"]) > 0)
                    {
                        resultaat = true;
                    }

                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connectie.Close();
            }
            return resultaat;
        }

        //Deze haalt alle profielen op van het account wat woord meegegeven via de email parameter
        public List<string> GetProfiles(string email)
        {
            List<string> resultaat = new List<string>();
            string sql;
            sql = "select naam from profiel where emailadres = :email";

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("email", email));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["naam"]));
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connectie.Close();
            }
            return resultaat;
        }

        //Deze haalt op welke categorie een bepaaalde profiel is (Volwassene of kind) Word niet meer gebruikt.
        public string GetProfileCat(string email, string naam)
        {
            string resultaat = "";
            string sql;
            sql = "select categorie from profiel where emailadres = :email and NAAM = :naam";

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("email", email));
                cmd.Parameters.Add(new OracleParameter("naam", naam));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat =(Convert.ToString(reader["categorie"]));
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connectie.Close();
            }
            return resultaat;
        }

        //Deze haal alle shows op die bij een profiel horen (dus de persoonlijke lijst)
        public List<string> GetProfileShows(string email, string profile)
        {
            List<string> resultaat = new List<string>();
            string sql;
            sql = "select titel from lijst l, profiel p, show s where l.PROFIELID = p.PROFIELID and l.SHOWID = s.SHOWID and p.NAAM = :profile and p.EMAILADRES = :email";

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("profile", profile));
                cmd.Parameters.Add(new OracleParameter("email", email));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["titel"]));
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connectie.Close();
            }
            return resultaat;
        }

        //Deze methode haalt de omschrijving van een bepaalde show op
        public string GetShowInfo(string titel)
        {
            string resultaat = "";
            string sql;
            sql = "select omschrijving from show where titel = :titel";

            try
            {
                Connectieopen();
                OracleCommand cmd = new OracleCommand(sql, connectie);
                cmd.Parameters.Add(new OracleParameter("titel", titel));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = (Convert.ToString(reader["omschrijving"]));
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connectie.Close();
            }
            return resultaat;
        }

        
    }
}