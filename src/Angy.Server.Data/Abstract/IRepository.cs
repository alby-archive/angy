﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Angy.Model;

namespace Angy.Server.Data.Abstract
{
    public interface IRepository<T>
        where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetOne(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(Guid id, T entity);

        Task<T> Delete(Guid id);
    }
}