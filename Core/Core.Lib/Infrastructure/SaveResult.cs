﻿using Common.Lib.Core;

namespace Common.Lib.Infrastructure
{
    public class SaveResult<T> where T : Entity
    {
        public ValidationResult Validation { get; set; } = new ValidationResult();

        public bool IsSuccess
        {
            get
            {
                return Validation.IsSuccess;
            }
            set
            {
                Validation.IsSuccess = value;
            }
        }

        public string AllErrors
        {
            get
            {
                return Validation.AllErrors;
            }
        }

        public T Entity { get; set; }

    }
}
