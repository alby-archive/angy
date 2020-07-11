﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Angy.Core.Abstract;
using Angy.Core.Extensions;
using Angy.Core.Specifications;
using Angy.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Angy.Core.Repositories
{
    public class MicroCategoryRepository : IRepository<MicroCategory>
    {
        readonly LuciferContext _context;

        public MicroCategoryRepository(LuciferContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MicroCategory>> GetAll() => await _context.MicroCategories.ToListAsync();

        public async Task<MicroCategory> GetOne(Guid id) => await _context.MicroCategories.Specify(new MicroCategorySpecification(id)).SingleOrDefaultAsync();

        public async Task<MicroCategory> Create(MicroCategory micro)
        {
            _context.Entry(micro).State = EntityState.Modified;
            await _context.MicroCategories.AddAsync(micro);
            await _context.SaveChangesAsync();
            
            //TODO: Return null

            return micro;
        }

        public async Task<MicroCategory> Update(Guid id, MicroCategory entity)
        {
            var micro = await _context.MicroCategories.Specify(new MicroCategorySpecification(id)).FirstOrDefaultAsync();

            micro.Name = entity.Name;
            micro.Description = entity.Description;

            await _context.SaveChangesAsync();

            return micro;
        }

        public Task<MicroCategory> Delete(Guid id) => throw new NotImplementedException();
    }
}