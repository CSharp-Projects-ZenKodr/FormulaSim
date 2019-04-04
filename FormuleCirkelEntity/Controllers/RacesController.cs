﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormuleCirkelEntity.DAL;
using FormuleCirkelEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormuleCirkelEntity.Controllers
{
    public class RacesController : Controller
    {
        private readonly FormulaContext _context;
        private static readonly Random rng = new Random();

        public RacesController(FormulaContext context)
        {
            _context = context;
        }

        public IActionResult RacePreview()
        {
            var nextrace = _context.Races.Where(r => r.Season.CurrentSeason == true)
                .Include(r => r.Track).ToList().OrderBy(r => r.Round).FirstOrDefault(r => r.DriverResults == null);
            return View(nextrace);
        }

        [HttpPost]
        public IActionResult RacePreview(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var drivers = _context.SeasonDrivers;
            var driverresults = new List<DriverResult>();

            foreach (var driver in drivers)
            {
                var result = new DriverResult();
                try
                {
                    result.RaceId = id.GetValueOrDefault();
                    result.SeasonDriverId = driver.SeasonDriverId;
                } catch(Exception e)
                {
                    TempData["msg"] = "<script>alert('Race toevoegen mislukt!');</script>";
                    return RedirectToAction(nameof(RacePreview));
                }
                driverresults.Add(result);
            }

            _context.DriverResults.AddRange(driverresults);
            _context.SaveChanges();
            
            return RedirectToAction("RaceWeekend", new { id });
        }

        public IActionResult RaceWeekend(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var race = _context.Races.FirstOrDefault(r => r.RaceId == id);
            ViewBag.track = race.Track;
            ViewBag.race = race;
            ViewBag.id = id;

            return View(_context.SeasonDrivers.Include(s => s.Drivers).Include(t => t.SeasonTeam).ThenInclude(t => t.Team)
                .ToList());
        }

        public IActionResult Qualifying()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetRacingDrivers(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return BadRequest();

            try
            {
                // Get all drivers of the season.
                var drivers = _context.SeasonDrivers
                .Include(s => s.Drivers)
                .Include(t => t.SeasonTeam)
                .ThenInclude(t => t.Team)
                .ToList();

                // Get the existing qualification results of the current race.
                var currentQualifyingResult = _context.Qualification.Where(q => q.RaceId == 1).ToList();

                // If there are no qualifying results yet, initialize them.
                if (!currentQualifyingResult.Any())
                {
                    currentQualifyingResult.AddRange(GetQualificationsFromDrivers(drivers));
                }

                var driverLimit = GetQualifyingDriverLimit(source);

                // Take the current result, then order descending to place highest score first, lowest score last. 
                // From the resulting ordered list, take the amount of drivers allowed to continue to the next qualifying round.
                var qualificationResultsToUpdate = currentQualifyingResult
                    .OrderBy(q => q.Position)
                    .Take(driverLimit);

                // Apply qualifying RNG on the drivers in the round.
                foreach (var qualificationResult in qualificationResultsToUpdate)
                {
                    var qualifyingDriver = drivers.Single(d => d.SeasonDriverId == qualificationResult.DriverId);
                    qualificationResult.Score = GenerateDriverScore(qualifyingDriver);  
                }

                var qualificationResults = qualificationResultsToUpdate.OrderByDescending(q => q.Score).ToList();

                // Using a for loop, use the loop index to set the position.
                for (int i = 0; i < qualificationResultsToUpdate.Count(); i++)
                {
                    var resultToUpdate = qualificationResults[i];
                    resultToUpdate.Position = i + 1;
                }

                // Update everything and save.
                _context.UpdateRange(qualificationResultsToUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(qualificationResultsToUpdate);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        IList<Qualification> GetQualificationsFromDrivers(IList<SeasonDriver> drivers)
        {
            var result = new List<Qualification>();
            foreach (var driver in drivers.ToList())
            {
                result.Add(new Qualification()
                {
                    DriverId = driver.SeasonDriverId,
                    RaceId = 1,
                    TeamName = driver.SeasonTeam.Team.Name,
                    DriverName = driver.Drivers.Name,
                    Score = 0
                });
            }
            return result;
        }

        int GetQualifyingDriverLimit(string qualifyingStage)
        {
            const int Q1_LIMIT = 4;
            const int Q2_LIMIT = 3;
            const int Q3_LIMIT = 2;

            if (qualifyingStage == "Q2")
                return Q2_LIMIT;
            if (qualifyingStage == "Q3")
                return Q3_LIMIT;
            return Q1_LIMIT;
        }

        int GenerateDriverScore(SeasonDriver driver)
        {
            var result = 0;
            result += driver.Skill;
            result += driver.SeasonTeam.Chassis;
            result += rng.Next(0, 60);
            return result;
        }
        
        public IActionResult Race()
        {
            return View();
        }
    }
}