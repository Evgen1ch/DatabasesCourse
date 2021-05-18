﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesCourse.Validators
{
    public interface IValidator<T>
    {
        string ValidateWithString(T entity);
    }
}