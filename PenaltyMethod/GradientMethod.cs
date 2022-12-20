namespace PenaltyMethod
{
    public partial class Program
    {
        private static double[] EvaluateGradient(in double[] point)
            => new[]
            {
                PDerivativeX(point[0], point[1]), 
                PDerivativeY(point[0],point[1])
            };
        
        private static double[] GradientMethod(double x, double y, double eps)
        {
            var currentApprox = new[] { x, y };

            while (true)
            {
                var gradient = EvaluateGradient(currentApprox);
                
                var newApprox = new double[2];
                currentApprox.CopyTo(newApprox, 0);

                var funcMin = P(newApprox[0], newApprox[1]);
                var lambda = eps;

                while (lambda <= 1)
                {
                    var possibleApprox = new[]
                    {
                        currentApprox[0] - lambda * gradient[0],
                        currentApprox[1] - lambda * gradient[1]
                    };
                    var funcCurrent = P(possibleApprox[0], possibleApprox[1]);

                    if (funcMin > funcCurrent)
                    {
                        possibleApprox.CopyTo(newApprox, 0);
                        funcMin = funcCurrent;
                    }
                    
                    lambda += eps;
                }

                var newGradient = EvaluateGradient(newApprox);
                
                if (Math.Sqrt(
                        Math.Pow(currentApprox[0] - newApprox[0], 2) + 
                        Math.Pow(currentApprox[1] - newApprox[1], 2)
                    ) < eps
                    && Math.Sqrt(
                        Math.Pow(newGradient[0], 2) + 
                        Math.Pow(newGradient[1], 2)
                    ) < eps
                   )
                    return (double[])newApprox.Clone();
                
                newApprox.CopyTo(currentApprox, 0);
            }
        }
    }
}