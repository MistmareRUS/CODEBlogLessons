﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodBlogFitness.BL.Controller
{
    public interface IDateSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class;
    }
}
