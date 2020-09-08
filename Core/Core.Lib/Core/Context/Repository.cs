
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Lib.Core.Context
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        
        public static Dictionary<Guid, T> DbSet { get; set; } = new Dictionary<Guid, T>();

        public IQueryable<T> QueryAll()
        {
            return DbSet.Values.AsQueryable<T>();
        }

        public virtual T Find(Guid id)
        {
            return DbSet[id];
        }

        public virtual SaveResult<T> Add(T entity)
        {
            var output = new SaveResult<T>()
            {
                Validation = new ValidationResult()

            };

            output.Validation.IsSuccess = true;

            if (entity.Id == default(Guid))
                entity.Id = Guid.NewGuid();

            if (DbSet.ContainsKey(entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ojo!! Ya existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Add(entity.Id, entity);
                output.Entity = entity;
            }

            return output;
        }

        public virtual SaveResult<T> Update(T entity)
        {
            var output = new SaveResult<T>
            {
                Validation = new ValidationResult()
            };

            output.Validation.IsSuccess = true;

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            if (entity.Id != default(Guid) && !DbSet.ContainsKey(entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet[entity.Id] = entity;
                output.Entity = entity;
            }

            return output;
        }

        public virtual SaveResult<T> Delete(T entity)
        {
            var output = new SaveResult<T>()
            {
                Validation = new ValidationResult()
            };

            output.IsSuccess = true;

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede eliminar una entidad sin Id");
            }

            if (!DbSet.ContainsKey(entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Esta entidad no se encuentra en la base de datos.");
            }


            return output;
        }

        public void Dispose()
        {          
            
        }
    }
}
