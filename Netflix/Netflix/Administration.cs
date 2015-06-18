using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix
{
    /*
     * Dit is de klasse die de webforms laat communiceren met de databseclasse.
     * Alles wat op een form uit de database gehaald moet worden gaat via deze klasse
     * Ook alles wat IN de database moet worden gezet vanuit de webforms gaat via hier.
     */

    public class Administration
    {
        //Private database om daar meet te communiceren, in de webforms bestaat er dan een private Administration om daar dingen door te geven
        private database db = new database();


        // In pincipe alleen methodes die strings/ints/lists van strings ophalan
        // De andere methodes zijn voids die een insertquery uitvoeren in de db klasse.


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