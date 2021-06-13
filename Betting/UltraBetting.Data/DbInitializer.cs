﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraBetting.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UltraBettingContext context)
        {
            //context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}
