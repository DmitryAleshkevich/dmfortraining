using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem3
{
    public class Triangle
    {
        #region Fields

        private double sideA;
        private double sideB;
        private double sideC;

        #endregion

        #region Properties

        public double SideA
        {
            get { return sideA; }
            set { sideA = value; }
        }

        public double SideB
        {
            get { return sideB; }
            set { sideB = value; }
        }

        public double SideC
        {
            get { return sideC; }
            set { sideC = value; }
        }

        #endregion

        #region Methods

        public bool Validate(double[] sortedsides)
        {
            if (sortedsides[2] >= 0 && sortedsides[0] >= 0 && sortedsides[1] >= 0)
            {
                if (sortedsides[2] < sortedsides[0] + sortedsides[1]) return true;
            }
            return false;
        }

        public double[] SortSides(double sideA, double sideB, double sideC)
        {
            double [] array = new double[3] { sideA, sideB, sideC };
            Array.Sort<double>(array);
            return array;
        }

        public TriangleType GetTriangleType()
        {
            double[] sortedsides = SortSides(sideA, sideB, sideC);
            if (Validate(sortedsides))
            {
                double difference = sortedsides[2] * sortedsides[2] - sortedsides[0] * sortedsides[0] - sortedsides[1] * sortedsides[1];
                if (difference == 0) return TriangleType.rectangularTriangle;
                else if (difference > 0) return TriangleType.obtuseAngled;
                else return TriangleType.acuteAngled;
            }
            else return TriangleType.Incorrect;
        }

        #endregion

        #region Constructors

        public Triangle() { }

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        #endregion
    }

    public enum TriangleType { obtuseAngled, acuteAngled, rectangularTriangle, Incorrect  }
}
