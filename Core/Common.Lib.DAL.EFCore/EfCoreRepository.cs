using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Lib.DAL.EFCore
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity
    {

        DbContext DbContext { get; set; }

        public EfCoreRepository()
        {

        }

        public EfCoreRepository(DbContext context)
        {
            DbContext = context;
        }

        DbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public IQueryable<T> QueryAll()
        {
            return DbSet.AsQueryable<T>();
        }

        public virtual T Find(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual SaveResult<T> Add(T entity)
        {
            var output = new SaveResult<T>()
            {
                IsSuccess = true
            };

            if (entity.Id == default(Guid))
                entity.Id = Guid.NewGuid();

            if (DbSet.Any(x => x.Id == entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ojo!! Ya existe una entity con ese id");
            }

            if (output.IsSuccess)
            {

                DbSet.Add(entity);
                DbContext.SaveChanges();
                output.Entity = entity;
            }

            return output;



        }

        public virtual SaveResult<T> Update(T entity)
        {
            var output = new SaveResult<T>
            {
                IsSuccess = true
            };

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            if (entity.Id != default(Guid) && DbSet.All(x => x.Id != entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Update(entity);
                DbContext.SaveChanges();
                output.Entity = entity;
            }

            return output;
        }

        public virtual SaveResult<T> Delete(T entity)
        {
            var output = new SaveResult<T>
            {
                IsSuccess = true
            };

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede eliminar una entidad sin Id");
            }

            if (DbSet.All(x => x.Id != entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Esta entidad no se encuentra en la base de datos.");
            }

            if (output.IsSuccess)
            {
                DbSet.Remove(entity);
                DbContext.SaveChanges();
            }

            return output;
        }
        
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}