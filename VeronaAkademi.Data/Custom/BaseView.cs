﻿using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeronaAkademi.Data.Custom
{
    public abstract class BaseView : RazorPage<object>
    {
        public string Test()
        {
            return "1";
        }
    }
}
