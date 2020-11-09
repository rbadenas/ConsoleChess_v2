using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleChess
{
    public class Interval
    {

        private double inferior;

        private double superior;

        public Interval(double inferior, double superior)
        {
            this.inferior = inferior;
            this.superior = superior;
        }

        public Interval(double superior) : this(0, superior) { }

        public Interval(Interval interval) : this(interval.inferior, interval.superior) { }

        public Interval() : this(0, 0) { }

        public double Inferior() => inferior;

        public double Superior() => superior;




        public Interval Clone()
        {
            return new Interval(this);
        }

        public List<double> ListDiscreteValues()
        {
            var result = new List<double>();

            int increment = 1;

            if (inferior > superior)
                increment = -1;

            for (double i = Inferior() + increment; i < Superior(); i += increment)
            {
                result.Add(i);
            }

            return result;
        }

        public double Lenght()
        {
            return superior - inferior;
        }

        public void Move(double desplazamiento)
        {
            inferior += desplazamiento;
            superior += desplazamiento;
        }

        public bool Includes(double valor)
        {
            return inferior <= valor && valor <= superior;
        }

        public bool Includes(Interval intervalo)
        {
            Debug.Assert(intervalo != null);
            return this.Includes(intervalo.inferior) &&
                    this.Includes(intervalo.superior);
        }

        public bool Equals(Interval intervalo)
        {
            Debug.Assert(intervalo != null);
            return inferior == intervalo.inferior &&
                    superior == intervalo.superior;
        }

        public Interval Intersection(Interval intervalo)
        {
            Debug.Assert(this.Intersects(intervalo));

            if (this.Includes(intervalo))
            {
                return intervalo.Clone();
            }
            else if (intervalo.Includes(this))
            {
                return this.Clone();
            }
            else if (this.Includes(intervalo.inferior))
            {
                return new Interval(intervalo.inferior, superior);
            }
            else
            {
                return new Interval(inferior, intervalo.superior);
            }
        }

        public bool Intersects(Interval intervalo)
        {
            Debug.Assert(intervalo != null);
            return this.Includes(intervalo.inferior) ||
                    this.Includes(intervalo.superior) ||
                    intervalo.Includes(this);
        }

        public void Oppose()
        {
            double inferiorInicial = inferior;
            double superiorInicial = superior;
            inferior = -superiorInicial;
            superior = -inferiorInicial;
        }

        public void Read()
        {
            var console = new ConsoleIO();
            inferior = console.InDouble("Inferior?");
            superior = console.InDouble("Superior?");
        }

        public void Display()
        {
            new ConsoleIO().Out("[" + inferior + "," + superior + "]");
        }


    }

}