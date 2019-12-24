﻿using FormuleCirkelEntity.DAL;
using FormuleCirkelEntity.Filters;
using FormuleCirkelEntity.Models;
using FormuleCirkelEntity.Services;
using FormuleCirkelEntity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormuleCirkelEntity.Controllers
{
    [Route("[controller]")]
    public class TracksController : ViewDataController<Track>
    {
        public TracksController(FormulaContext context, PagingHelper pagingHelper) : base(context, pagingHelper)
        {
        }

        [SortResult(nameof(Track.Name)), PagedResult]
        public override Task<IActionResult> Index()
        {
            return base.Index();
        }
        
        [Route("Traits/{id}")]
        public async Task<IActionResult> TrackTraits(int id)
        {
            var track = await Data.IgnoreQueryFilters()
                .SingleOrDefaultAsync(t => t.Id == id)
                .ConfigureAwait(false);
            // Still requires a check if the chosen track doesnt already contain the trait.
            var traits = DataContext.Traits
                .Where(tr => tr.TraitGroup == TraitGroup.Track && !track.Traits.Values.Contains(tr));

            if (track == null)
                return NotFound();

            var model = new TraitsTrackModel
            {
                Track = track,
                Traits = traits
            };

            return View(model);
        }

        [HttpPost("Traits/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrackTraits(int id, [Bind("TraitId")] int traitId)
        {
            var track = await Data.SingleOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);
            var trait = await DataContext.Traits.SingleOrDefaultAsync(tr => tr.TraitId == traitId).ConfigureAwait(false);

            if (track == null || trait == null)
                return NotFound();

            track.Traits.Add(track.Traits.Count, trait);
            DataContext.Update(track);
            await DataContext.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToAction(nameof(TrackTraits), new { id });
        }

        [Route("Archived")]
        public IActionResult ArchivedTracks()
        {
            List<Track> tracks = Data.IgnoreQueryFilters().Where(t => t.Archived).OrderBy(t => t.Location).ToList();
            return View(tracks);
        }
    }
}
