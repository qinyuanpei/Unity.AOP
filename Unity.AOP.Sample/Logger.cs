﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity.AOP.Sample
{
    static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
