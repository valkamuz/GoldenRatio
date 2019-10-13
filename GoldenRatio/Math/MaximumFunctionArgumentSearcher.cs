using System;

namespace GoldenRatio.Math
{
    // Поиск максимального значения функции методом золотого сечения
    // Описание алгоритма здесь: https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D0%B7%D0%BE%D0%BB%D0%BE%D1%82%D0%BE%D0%B3%D0%BE_%D1%81%D0%B5%D1%87%D0%B5%D0%BD%D0%B8%D1%8F
    public class MaximumFunctionArgumentSearcher
    {
        // Пропорция золотого сечения
        private static double GoldenRatioConst = 0.5 * (1 + System.Math.Pow(5d, 0.5));

        private Func<double, double> Function { get; set; }

        private double _min;
        private double _max;
        private double _epsilon;

        public double ResultArgument { get; private set; }
        public double ResultValue { get; private set; }


        public MaximumFunctionArgumentSearcher(Func<double, double> function, double min, double max, double epsilon)
        {
            Function = function;
            _min = min;
            _max = max;
            _epsilon = epsilon;
        }

        public void Search()
        {
            double a = _min;
            double b = _max;

            double x1 = GetPointByGoldenRatio(a, b, true);
            double x2 = GetPointByGoldenRatio(a, b, false);

            while (!ArePointsClose(a, b))
            {
                double value1 = Function(x1);
                double value2 = Function(x2);

                bool leftPointBetter = value1 > value2;
                if (leftPointBetter)
                {
                    b = x2;
                    x2 = x1;
                    x1 = GetPointByGoldenRatio(a, b, true);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = GetPointByGoldenRatio(a, b, false);
                }
            }

            ResultArgument = (a + b) / 2d;
            ResultValue = Function(ResultArgument);
        }

        private bool ArePointsClose(double x1, double x2)
        {
            double dif = System.Math.Abs(x1 - x2);
            bool close = dif < _epsilon;
            return close;
        }

        private double GetPointByGoldenRatio(double a, double b, bool leftPoint)
        {
            double delta = (b - a) / GoldenRatioConst;
            double result = leftPoint ? b - delta : a + delta;
            return result;
        }

    }
}
