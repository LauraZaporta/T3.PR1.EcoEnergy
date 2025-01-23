namespace Eco
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
        public double HoresDeSol { get; set; }
        public static double DefaultHoresDeSol = 0;

        public SistemaSolar(double horesDeSol, string simulationType, DateTime simulationDate) : base (simulationType, simulationDate)
        {
            HoresDeSol = horesDeSol;
        }
        public SistemaSolar(string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            HoresDeSol = DefaultHoresDeSol;
        }

        public override double CalcularEnergia()
        {
            const int NumDecimals = 2;
            return Math.Round(HoresDeSol * 1.5, NumDecimals);
        }
    }
}
