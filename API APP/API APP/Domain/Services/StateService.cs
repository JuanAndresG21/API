﻿using API_APP.Controllers;
using API_APP.DAL;
using API_APP.DAL.Entities;
using API_APP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_APP.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DatabaseContext _context;

        public StateService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId)
        {
            return await _context.States
                .Where(s => s.CountryId == countryId)
                .ToListAsync();
        }

        public async Task<State> CreateStateAsync(State state, Guid countryId)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                state.CountryId = countryId;
                //state.Country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
                state.ModifiedDate = null;

                _context.States.Add(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            return await _context.States.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<State> EditStateAsync(State state, Guid id)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;

                _context.States.Update(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await _context.States.FirstOrDefaultAsync(s => s.Id == id);
                if (state == null) return null;

                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}