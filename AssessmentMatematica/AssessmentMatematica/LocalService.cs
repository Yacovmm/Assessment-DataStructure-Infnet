using AssessmentMatematica.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentMatematica
{
    public class LocalService : ILocal
    {
        public Local CriarLocal(Local l)
        {
            return l;
        }
    }
}
