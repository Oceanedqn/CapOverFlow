﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapOverFlow.Shared.Dto;
using CapOverFlow.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapOverFlow.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly DataContext _context;
        public PublicationController(DataContext context)
        {
            _context = context;
        }

        private async Task<List<PublicationDto>> GetDbPublications()
        {
            return await _context.PublicationsDb
                .Include(us => us.Usr)
                .Include(ty => ty.Typ)
                .Include(tag => tag.Tag)
                .ThenInclude(ct => ct.Ctg)
                .ToListAsync();
        }

        private async Task<PublicationDto> GetPublicationById(int id)
        {
            var question = await _context.PublicationsDb
               .Include(us => us.Usr)
                .Include(ty => ty.Typ)
                .Include(tag => tag.Tag)
                .ThenInclude(ct => ct.Ctg)
                .FirstOrDefaultAsync(h => h.PbcId == id);
            return question;
        }



        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return base.Ok(await GetDbPublications());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await GetPublicationById(id);         
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(PublicationDto publication)
        {

            publication.PbcDate = DateTime.UtcNow;
            _context.PublicationsDb.Add(publication);
            await _context.SaveChangesAsync();

            return Ok(await GetPublicationById(publication.PbcId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(PublicationDto publication)
        {
            var dbPubli = await _context.PublicationsDb
                .FirstOrDefaultAsync(h => h.PbcId == publication.PbcId);
           
            dbPubli.PbcTitle = publication.PbcTitle;
            dbPubli.PbcDescription = publication.PbcDescription;
            dbPubli.PbcResolved = publication.PbcResolved;
            dbPubli.PbcDate = DateTime.Now;
            dbPubli.TypId = 1;
            dbPubli.UsrId = 1;

            await _context.SaveChangesAsync();
            return Ok(await GetDbPublications());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var dbHPubli = await _context.PublicationsDb
                .FirstOrDefaultAsync(h => h.PbcId == id);

            _context.PublicationsDb.Remove(dbHPubli);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPublications());
        }


    }
}
