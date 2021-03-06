﻿using RocketLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Windows;
using DataLibrary;
using static DataLibrary.BusinessLogic.PlayerProcessor;
using System.Net.Configuration;

namespace RocketLeague.Controllers
{
    public class LiquipediaController : Controller
    {
        public ActionResult Teams()
        {
            return View();
        }
        public ActionResult Player()
        {
            ViewBag.Message = "Player List Page";

            var data = LoadPlayers();

            List<PlayerRegistrationModel> players = new List<PlayerRegistrationModel>();

            foreach (var row in data)
            {
                players.Add(new PlayerRegistrationModel
                {
                    playerName = row.playerName,
                    userName = row.userName,
                    playerBirthdate = row.playerBirthDate,
                    playerTeam = row.playerTeam,
                    playerEarnings = row.playerEarnings,
                    system = row.system,
                    timeZone = row.timeZone,
                    mmr = row.mmr
                });
            }

            return View(players);
        }

        public ActionResult PlayerRegistration()
        {
            ViewBag.Message = "Player Registration Page";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlayerRegistration(PlayerRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreatePlayer(model.playerName, model.userName, model.playerBirthdate, model.playerTeam, 
                    model.playerEarnings, model.system, model.timeZone, model.mmr);
                MessageBox.Show("You have successfully registered your account");
                return RedirectToAction("Liquipedia", "Home");
            }
            return View();
        }

        public ActionResult Rizzo()
        {
            ViewBag.Message = "Rizzo";

            return View();
        }

        public ActionResult Jknaps()
        {
            ViewBag.Message = "Jknaps";

            return View();
        }

        public ActionResult Chicago()
        {
            ViewBag.Message = "Chicago";

            return View();
        }

        public ActionResult G2()
        {
            ViewBag.Message = "G2";

            return View();
        }
    }
}