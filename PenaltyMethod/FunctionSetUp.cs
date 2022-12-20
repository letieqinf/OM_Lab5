namespace PenaltyMethod
{
    public partial class Program
    {
        private static double R { get; set; } = 1e-4;
        
        // ----------- FUNCTION f(x) -----------
        
        private static double F(double x, double y)
            => Math.Pow(x - 8, 2) + Math.Pow(y - 7, 2);

        private static double FDerivativeX(double x, double y)
            => 2 * (x - 8);

        private static double FDerivativeY(double x, double y)
            => 2 * (y - 7);
        
        // -------------------------------------
        
        // ----------- FUNCTION h(x) -----------
        
        private static double H(double x, double y)
            => x + y - 5;

        private static double HDerivativeX(double x, double y) => 1;
        private static double HDerivativeY(double x, double y) => 1;
        
        // -------------------------------------
        
        // --------- FUNCTION P(x, R) ----------
        
        private static double P(double x, double y)
            => F(x, y) + R * H(x, y);

        private static double PDerivativeX(double x, double y)
            => FDerivativeX(x, y) + R * Math.Pow(HDerivativeX(x, y), 2);

        private static double PDerivativeY(double x, double y)
            => FDerivativeY(x, y) + R * Math.Pow(HDerivativeY(x, y), 2);

        // -------------------------------------
    }
}
