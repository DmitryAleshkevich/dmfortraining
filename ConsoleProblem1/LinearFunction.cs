using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem1
{
    public class LinearFunction
    {
        #region Fields

        private double coeffA { get; set; }

        private double coeffB { get; set; }

        #endregion

        #region Methods

        public double GetFunctionValue(double variableX)
        {
            return this.coeffA * variableX + this.coeffB;
        }

        #endregion

        #region Constructors

        public LinearFunction() { }
       
        public LinearFunction(double coeffA, double coeffB)
        {
            this.coeffA = coeffA;
            this.coeffB = coeffB;
        }

        #endregion

    }
}
