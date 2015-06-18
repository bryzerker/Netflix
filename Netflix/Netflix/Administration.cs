using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix
{

    public class Administration
    {
        private database db = new database();

        public List<String> Shows()
        {
            List<string> resultaat = new List<string>();

            foreach (string s in db.GetShows())
            {
                resultaat.Add(s);
            }

            return resultaat;
        }

        public bool login(string email, string password)
        {
            return db.checkLogin(email, password);
        }

        public List<String> Profiles(string email)
        {
            List<string> resultaat = new List<string>();

            foreach (string s in db.GetProfiles(email))
            {
                resultaat.Add(s);
            }

            return resultaat;
        }

        public string profileCat(string email, string naam)
        {
            return db.GetProfileCat(email, naam);
        }

        public List<string> ProfileShows(string email, string profile)
        {
            return db.GetProfileShows(email, profile);
        }

        public string ShowInfo(string titel)
        {
            return db.GetShowInfo(titel);
        }
    }
}