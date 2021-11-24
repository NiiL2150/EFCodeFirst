using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFCodeFirst.View
{
    public partial class Form1 : Form
    {
        private readonly OlympicContext db;
        DataTable data;
        public Form1()
        {
            InitializeComponent();
            db = new OlympicContext();
            data = new DataTable();
            dgData.DataSource = data;

            if (db.Database.EnsureCreated())
            {
                AddCountries(db);
                AddSports(db);
                AddSportsmen(db);
                AddMedal(db);
                AddSportSportsman(db);
            }
        }

        private void buttonTables_Click(object sender, EventArgs e)
        {
            data = new DataTable();
            dgData.DataSource = null;
            int index = comboBoxTables.SelectedIndex;

            if (index == 0)
            {
                dgData.DataSource = (from sman in db.Sportsmen
                                     join ctr in db.Countries on sman.Country.CountryId equals ctr.CountryId
                                     select new
                                     {
                                         Id = sman.SportsmanId,
                                         Name = sman.FirstName,
                                         Surname = sman.LastName,
                                         Country = ctr.Name
                                     }).ToList();
            }
            else if (index == 1)
            {
                dgData.DataSource = (from sp in db.Sports
                                     select new
                                     {
                                         Id = sp.SportId,
                                         sp.Title
                                     }).ToList();
            }
            else if (index == 2)
            {
                dgData.DataSource = (from ctr in db.Countries
                                     select new
                                     {
                                         Id = ctr.CountryId,
                                         ctr.Name
                                     }).ToList();
            }
        }

        private void buttonTablesId_Click(object sender, EventArgs e)
        {
            data = new DataTable();
            dgData.DataSource = null;
            int index = comboBoxTables.SelectedIndex;
            int id;
            if(!Int32.TryParse(textBoxId.Text, out id))
            {
                return;
            }

            if (index == 0)
            {
                dgData.DataSource = (from sman in db.Sportsmen
                                     join ctr in db.Countries on sman.Country.CountryId equals ctr.CountryId
                                     join spsman in db.SportSportsmen on sman.SportsmanId equals spsman.Sportsman.SportsmanId
                                     join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                     join mdl in db.Medals on spsman.Medal.Id equals mdl.Id into medals
                                     from medal in medals.DefaultIfEmpty()
                                     where sman.SportsmanId == id
                                     select new
                                     {
                                         Id = sman.SportsmanId,
                                         Name = sman.FirstName,
                                         Surname = sman.LastName,
                                         Country = ctr.Name,
                                         Sport = sp.Title,
                                         Medal = medal.Type.ToString()
                                     }).ToList();
            }
            
            else if (index == 1)
            {
                
                int smanCount = (from spsman in db.SportSportsmen
                                 join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 where sp.SportId == id
                                  group spsman by spsman.Sportsman.SportsmanId into spsman
                                  select new
                                  {
                                      spsman.Key
                                  }).ToList().Count();
                
                
                int countryCount = (from spsman in db.SportSportsmen
                                    join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                    join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                    join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                    where sp.SportId == id
                                    group spsman by spsman.Sportsman.Country.CountryId into sman
                                   select new
                                   {
                                       sman.Key
                                   }).ToList().Count();

                int goldCount = (from spsman in db.SportSportsmen
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                 where sp.SportId == id && mdl.Type == MedalType.Gold
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int silverCount = (from spsman in db.SportSportsmen
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                 where sp.SportId == id && mdl.Type == MedalType.Silver
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int bronzeCount = (from spsman in db.SportSportsmen
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                 where sp.SportId == id && mdl.Type == MedalType.Bronze
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                dgData.DataSource = (from sp in db.Sports
                                     where sp.SportId == id
                                     select new
                                     {
                                         Name = sp.Title,
                                         Sportsmen = smanCount,
                                         Countries = countryCount,
                                         Gold = goldCount,
                                         Silver = silverCount,
                                         Bronze = bronzeCount
                                     }).ToList();
                
            }
            else if (index == 2)
            {
                int smanCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                 where country.CountryId == id
                                  group spsman by spsman.Sportsman.SportsmanId into spsman
                                  select new
                                  {
                                      spsman.Key
                                  }).ToList().Count();

                int sportCount = (from spsman in db.SportSportsmen
                                  join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                  join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                  join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                  where country.CountryId == id
                                  group sp by sp.SportId into spsman
                                  select new
                                  {
                                      spsman.Key
                                  }).ToList().Count();

                int goldCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 where country.CountryId == id && mdl.Type == MedalType.Gold
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int silverCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 where country.CountryId == id && mdl.Type == MedalType.Silver
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int bronzeCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 where country.CountryId == id && mdl.Type == MedalType.Bronze
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                dgData.DataSource = (from ctr in db.Countries
                                     where ctr.CountryId == id
                                     select new
                                     {
                                         ctr.Name,
                                         Sports = sportCount,
                                         Sportsmen = smanCount,
                                         Gold = goldCount,
                                         Silver = silverCount,
                                         Bronze = bronzeCount
                                     }).ToList();
            }
            
        }

        #region InitialCreate
        private void AddCountries(OlympicContext db)
        {
            db.Countries.Add(new Country { Name = "Russian Federation" });
            db.Countries.Add(new Country { Name = "USA" });
            db.Countries.Add(new Country { Name = "China" });

            db.SaveChanges();
        }

        private void AddSports(OlympicContext db)
        {
            db.Sports.Add(new Sport { Title = "Swimming" });
            db.Sports.Add(new Sport { Title = "Running" });

            db.SaveChanges();
        }

        private void AddSportsmen(OlympicContext db)
        {
            db.Sportsmen.Add(new Sportsman { FirstName = "Vladimir", LastName = "Petrov", Country = db.Countries.AsEnumerable().ElementAt(0) });
            db.Sportsmen.Add(new Sportsman { FirstName = "Anastasiya", LastName = "Ivanova", Country = db.Countries.AsEnumerable().ElementAt(0) });

            db.Sportsmen.Add(new Sportsman { FirstName = "John", LastName = "Doe", Country = db.Countries.AsEnumerable().ElementAt(1) });
            db.Sportsmen.Add(new Sportsman { FirstName = "Sanders", LastName = "McDonald", Country = db.Countries.AsEnumerable().ElementAt(1) });

            db.Sportsmen.Add(new Sportsman { FirstName = "Xi", LastName = "Jinping", Country = db.Countries.AsEnumerable().ElementAt(2) });
            db.Sportsmen.Add(new Sportsman { FirstName = "Deng", LastName = "Xiaoping", Country = db.Countries.AsEnumerable().ElementAt(2) });

            db.SaveChanges();
        }

        private void AddMedal(OlympicContext db)
        {
            db.Medals.Add(new Medal { Type = MedalType.Gold });
            db.Medals.Add(new Medal { Type = MedalType.Silver });
            db.Medals.Add(new Medal { Type = MedalType.Bronze });

            db.SaveChanges();
        }

        private void AddSportSportsman(OlympicContext db)
        {
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(0), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(0), Medal = db.Medals.AsEnumerable().ElementAt(0) });
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(0), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(2), Medal = db.Medals.AsEnumerable().ElementAt(1) });
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(0), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(4), Medal = db.Medals.AsEnumerable().ElementAt(2) });
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(0), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(5) });

            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(1), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(1) });
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(1), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(3), Medal = db.Medals.AsEnumerable().ElementAt(2) });
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(1), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(4), Medal = db.Medals.AsEnumerable().ElementAt(1) });
            db.SportSportsmen.Add(new SportSportsman { Sport = db.Sports.AsEnumerable().ElementAt(1), Sportsman = db.Sportsmen.AsEnumerable().ElementAt(5), Medal = db.Medals.AsEnumerable().ElementAt(0) });

            db.SaveChanges();
        }
        #endregion

        private void buttonTopCountry_Click(object sender, EventArgs e)
        {
            data = new DataTable();
            dgData.DataSource = null;
            Dictionary<int, string> countries = new Dictionary<int, string>();
            Dictionary<int, int> smen = new Dictionary<int, int>(),
                sports = new Dictionary<int, int>(),
                golds = new Dictionary<int, int>(),
                silvers = new Dictionary<int, int>(),
                bronzes = new Dictionary<int, int>();

            for (int i = 1; i <= db.Countries.Count(); i++)
            {
                countries.Add(i, db.Countries.Single(c => c.CountryId == i).Name);

                int smanCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                 where country.CountryId == i
                                 group sman by sman.SportsmanId into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int sportCount = (from spsman in db.SportSportsmen
                                  join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                  join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                  join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                  where country.CountryId == i
                                  group sp by sp.SportId into spsman
                                  select new
                                  {
                                      spsman.Key
                                  }).ToList().Count();

                int goldCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 where mdl.Type == MedalType.Gold && country.CountryId == i
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int silverCount = (from spsman in db.SportSportsmen
                                   join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                   join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                   join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                   where mdl.Type == MedalType.Silver && country.CountryId == i
                                   group spsman by spsman.Id into spsman
                                   select new
                                   {
                                       spsman.Key
                                   }).ToList().Count();

                int bronzeCount = (from spsman in db.SportSportsmen
                                   join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                   join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                   join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                   where mdl.Type == MedalType.Bronze && country.CountryId == i
                                   group spsman by spsman.Id into spsman
                                   select new
                                   {
                                       spsman.Key
                                   }).ToList().Count();

                smen.Add(i, smanCount);
                sports.Add(i, sportCount);
                golds.Add(i, goldCount);
                silvers.Add(i, silverCount);
                bronzes.Add(i, bronzeCount);
            }
            

            dgData.DataSource = (from country in countries
                                 join sman in smen on country.Key equals sman.Key
                                 join sport in sports on country.Key equals sport.Key
                                 join gold in golds on country.Key equals gold.Key
                                 join silver in silvers on country.Key equals silver.Key
                                 join bronze in bronzes on country.Key equals bronze.Key
                                 orderby gold.Value descending,
                                 silver.Value descending,
                                 bronze.Value descending
                                 select new
                                 {
                                     Country = country.Value,
                                     Sports = sport.Value,
                                     Sportsmen = sman.Value,
                                     Gold = gold.Value,
                                     Silver = silver.Value,
                                     Bronze = bronze.Value
                                 }).ToList();
        }

        private void buttonTopSport_Click(object sender, EventArgs e)
        {
            data = new DataTable();
            dgData.DataSource = null;
            Dictionary<int, string> sports = new Dictionary<int, string>();
            Dictionary<int, int> smen = new Dictionary<int, int>(),
                countries = new Dictionary<int, int>(),
                golds = new Dictionary<int, int>(),
                silvers = new Dictionary<int, int>(),
                bronzes = new Dictionary<int, int>();

            for (int i = 1; i <= db.Sports.Count(); i++)
            {
                sports.Add(i, db.Sports.Single(s => s.SportId == i).Title);

                int smanCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                 where sp.SportId == i
                                 group sman by sman.SportsmanId into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int countryCount = (from spsman in db.SportSportsmen
                                    join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                    join country in db.Countries on sman.Country.CountryId equals country.CountryId
                                    join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                    where sp.SportId == i
                                    group country by country.CountryId into spsman
                                    select new
                                    {
                                        spsman.Key
                                    }).ToList().Count();

                int goldCount = (from spsman in db.SportSportsmen
                                 join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                 join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                 join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                 where mdl.Type == MedalType.Gold && sp.SportId == i
                                 group spsman by spsman.Id into spsman
                                 select new
                                 {
                                     spsman.Key
                                 }).ToList().Count();

                int silverCount = (from spsman in db.SportSportsmen
                                   join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                   join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                   join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                   where mdl.Type == MedalType.Silver && sp.SportId == i
                                   group spsman by spsman.Id into spsman
                                   select new
                                   {
                                       spsman.Key
                                   }).ToList().Count();

                int bronzeCount = (from spsman in db.SportSportsmen
                                   join sman in db.Sportsmen on spsman.Sportsman.SportsmanId equals sman.SportsmanId
                                   join sp in db.Sports on spsman.Sport.SportId equals sp.SportId
                                   join mdl in db.Medals on spsman.Medal.Id equals mdl.Id
                                   where mdl.Type == MedalType.Bronze && sp.SportId == i
                                   group spsman by spsman.Id into spsman
                                   select new
                                   {
                                       spsman.Key
                                   }).ToList().Count();

                smen.Add(i, smanCount);
                countries.Add(i, countryCount);
                golds.Add(i, goldCount);
                silvers.Add(i, silverCount);
                bronzes.Add(i, bronzeCount);
            }


            dgData.DataSource = (from sport in sports
                                 join sman in smen on sport.Key equals sman.Key
                                 join country in countries on sport.Key equals country.Key
                                 join gold in golds on sport.Key equals gold.Key
                                 join silver in silvers on sport.Key equals silver.Key
                                 join bronze in bronzes on sport.Key equals bronze.Key
                                 orderby gold.Value descending,
                                 silver.Value descending,
                                 bronze.Value descending
                                 select new
                                 {
                                     Sport = sport.Value,
                                     Countries = country.Value,
                                     Sportsmen = sman.Value,
                                     Gold = gold.Value,
                                     Silver = silver.Value,
                                     Bronze = bronze.Value
                                 }).ToList();
        }

        private void buttonSportsmanCountry_Click(object sender, EventArgs e)
        {
            //TODO: create a button that displays top sportsman from each country
        }

        private void buttonSportCountry_Click(object sender, EventArgs e)
        {
            //TODO: create a button that displays top sport from each country
        }

        //TODO: create advanced sportsmen search
    }
}
