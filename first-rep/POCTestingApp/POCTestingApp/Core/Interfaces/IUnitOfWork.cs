﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCTestingApp.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
    }
}
