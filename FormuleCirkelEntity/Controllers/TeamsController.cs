﻿using FormuleCirkelEntity.DAL;
using FormuleCirkelEntity.Models;
using FormuleCirkelEntity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FormuleCirkelEntity.Controllers
{
    public class TeamsController : Controller
    {
        private readonly FormulaContext _context;

        public TeamsController(FormulaContext context)
        {
            _context = context;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        public async Task<IActionResult> Stats(int? id)
        {
            if (id == null)
                return NotFound();

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            var seasondrivers = _context.SeasonDrivers
                .Where(sd => sd.SeasonTeam.TeamId == id)
                .Include(sd => sd.Driver);
            var driverresults = _context.DriverResults
                .Where(dr => dr.SeasonDriver.SeasonTeam.TeamId == id);
            var teamresults = _context.TeamResults
                .Where(tr => tr.SeasonTeam.TeamId == id);

            // Calculates the amount of championships a team has won.
            int driverchamps = 0;
            int teamchamps = 0;
            foreach (var season in _context.Seasons)
            {
                var driverwinner = _context.SeasonDrivers
                    .Where(s => s.SeasonId == season.SeasonId && s.Season.State == SeasonState.Finished)
                    .OrderByDescending(dr => dr.Points)
                    .FirstOrDefault();

                var teamwinner = _context.SeasonTeams
                    .Where(s => s.SeasonId == season.SeasonId && s.Season.State == SeasonState.Finished)
                    .OrderByDescending(dr => dr.Points)
                    .FirstOrDefault();

                if (driverwinner != null)
                {
                    if (driverwinner.DriverId == id)
                    {
                        driverchamps++;
                    }
                }

                if (teamwinner != null)
                {
                    if (teamwinner.TeamId == id)
                    {
                        teamchamps++;
                    }
                }
            }

            ViewBag.driverchampionships = driverchamps;
            ViewBag.teamchampionships = teamchamps;

            var stats = new TeamStatsModel()
            {
                Team = team,
                SeasonDriver = seasondrivers,
                DriverResults = driverresults,
                TeamResults = teamresults
            };

            return View(stats);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Name,Abbreviation,Colour,Accent")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,Abbreviation,Colour,Accent")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var edit = _context.Teams.First(t => t.TeamId == team.TeamId);
                    _context.Entry(edit).CurrentValues.SetValues(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}