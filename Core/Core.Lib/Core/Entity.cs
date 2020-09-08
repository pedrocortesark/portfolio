using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Newtonsoft.Json;
using System;

namespace Common.Lib.Core
{
    public abstract class  Entity
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public ValidationResult CurrentValidation { get; set; }

        public static IDependencyContainer DepCon { get; set; }

        public virtual ValidationResult Validate()
        {
            var output = new ValidationResult()
            {
                IsSuccess = true
            };

            return output;
        }

        public virtual SaveResult<T> Save<T>() where T : Entity
        {
            var output = new SaveResult<T>();

            CurrentValidation = Validate();

            if (CurrentValidation.IsSuccess)
            {
                var repo = Entity.DepCon.Resolve<IRepository<T>>();

                if (this.Id == Guid.Empty)
                {
                    this.Id = Guid.NewGuid();
                    repo.Add(this as T);
                }
                else
                    repo.Update(this as T);
                
            }

            output.Validation = CurrentValidation;
            

            return output;
        }

        public virtual SaveResult<T> Delete<T>() where T : Entity
        {
            var output = new SaveResult<T>();

            var repo = Entity.DepCon.Resolve<IRepository<T>>();
            repo.Delete(this as T);

            return output;
        }

        public virtual T Clone<T>() where T : Entity, new()
        {
            var output = new T();
            output.Id = this.Id;
            return output;
        }
    }
}
