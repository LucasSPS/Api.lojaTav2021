﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace lojaTAV.interfaces
{
    public interface IFrete
    {
        public double GetValorFreteBR(int cep);

        public double GetValorFreteInternacional(string pais);


    }
}
