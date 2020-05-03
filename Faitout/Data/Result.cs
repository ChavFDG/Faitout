using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faitout.Data
{
    public class Result
    {
        public bool OperationPass { get; set; }
        public string ErrorMessage { get; set; }

        public Result(bool operationPasse = true)
        {
            OperationPass = operationPasse;
        }

        public Result(string errorMessage, bool operationPasse = false)
        {
            OperationPass = operationPasse;
            ErrorMessage = errorMessage;
        }
    }
}
