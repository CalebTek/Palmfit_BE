﻿using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IMealPlanRepository
    {
        public string AddMealPlan(FoodClassDTO foodClassDTO);
    }
}