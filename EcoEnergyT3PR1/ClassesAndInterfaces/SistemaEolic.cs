namespace Eco
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia //Eòlic
    {
        public double VelocitatVent { get; set; }
        public static double DefaultVelocitatVent = 0;
        public SistemaEolic(double velocitatVent, string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        { 
            VelocitatVent = velocitatVent;
        }
        public SistemaEolic(string simulationType, DateTime simulationDate) : base(simulationType, simulationDate)
        {
            VelocitatVent = DefaultVelocitatVent;
        }
        public override double CalcularEnergia()
        {
            const int NumDecimals = 2;
            return Math.Round(Math.Pow(VelocitatVent, 3) * 0.2, NumDecimals);
        }
    }
}
