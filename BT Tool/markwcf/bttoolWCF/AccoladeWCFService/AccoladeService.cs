﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AccoladeWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccoladeService" in both code and config file together.
    public class AccoladeService : IAccoladeService
    {
        public string GetMessage(string message)
        {
            return message;
        }
    }
}
