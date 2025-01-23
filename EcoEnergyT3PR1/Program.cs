// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using Eco;

namespace Eco
{
    public class Program
    {
        public static void Main()
        {
            const string Title = " _______              _______                              \r\n(_______)            (_______)                             \r\n _____   ____ ___     _____   ____   ____  ____ ____ _   _ \r\n|  ___) / ___) _ \\   |  ___) |  _ \\ / _  )/ ___) _  | | | |\r\n| |____( (__| |_| |  | |_____| | | ( (/ /| |  ( ( | | |_| |\r\n|_______)____)___/   |_______)_| |_|\\____)_|   \\_|| |\\__  |\r\n                                              (_____(____/ ";
            const string MsgNumSimulations = " Type the number of simulations You want to do: ";
            const string MsgAskHoursOfSun = " How many hours of sun is your system exposed to? ";
            const string MsgAskWindSpeed = " At what wind speed is your eolic system exposed to? ";
            const string MsgAskWaterFlow = " How much water flow is affecting your system? ";
            const string MsgGeneratedEnergy = " The amount of energy generated is: ";
            const string MsgNoReports = " There are no reports to show";
            const string MsgNoMoreSimulations = " You can't add more simulations without deleting the previous ones.";
            const string MsgDeleteSimulations = " Do You want to delete all your simulations? (Y/N): ";
            const string SolarType = "Solar";
            const string EolicType = "Eolic";
            const string HidroelectricType = "Hidroelectric";
            const double MinSunHours = 1;
            const double MinWindSpeed = 5;
            const double MinWaterFlow = 20;

            char? whichSimulation = null;
            bool continueProgram = true;

            Console.WriteLine(Title);

            while (continueProgram)
            {
                bool continueSimulations = true;
                EcoUtils.DisplayMenu();

                switch (EcoUtils.GetValidInput())
                {
                    case 'a': //Initiate simulations

                        int numSimulations = EcoUtils.GetValidInt(MsgNumSimulations);
                        DateTime[] simulationDates = new DateTime[numSimulations];
                        string[] simulationSystemTypes = new string[numSimulations];
                        double[] simulationGeneratedEnergy = new double[numSimulations];

                        for (int i = 0; i < numSimulations; i++)
                        {
                            EcoUtils.DisplaySimulationStartMenu();
                            whichSimulation = EcoUtils.GetValidInput();

                            if (whichSimulation == 'a') //Solar
                            {
                                SistemaSolar solarSimulation = new SistemaSolar(SolarType, DateTime.Now);

                                solarSimulation.HoresDeSol = EcoUtils.GetValidValue(MinSunHours, EcoUtils.GetValidDouble(MsgAskHoursOfSun), MsgAskHoursOfSun);
                                solarSimulation.SimulationGeneratedEnergy = solarSimulation.CalcularEnergia();
                                Console.WriteLine($"{MsgGeneratedEnergy}{solarSimulation.SimulationGeneratedEnergy}");
                                simulationDates[i] = solarSimulation.SimulationDate;
                                simulationSystemTypes[i] = solarSimulation.SimulationType;
                                simulationGeneratedEnergy[i] = solarSimulation.SimulationGeneratedEnergy;
                            }
                            else if (whichSimulation == 'b') //Eòlic
                            {
                                SistemaEolic eolicSimulation = new SistemaEolic(EolicType, DateTime.Now);

                                eolicSimulation.VelocitatVent = EcoUtils.GetValidValue(MinWindSpeed, EcoUtils.GetValidDouble(MsgAskWindSpeed), MsgAskWindSpeed);
                                eolicSimulation.SimulationGeneratedEnergy = eolicSimulation.CalcularEnergia();
                                Console.WriteLine($"{MsgGeneratedEnergy}{eolicSimulation.SimulationGeneratedEnergy}");
                                simulationDates[i] = eolicSimulation.SimulationDate;
                                simulationSystemTypes[i] = eolicSimulation.SimulationType;
                                simulationGeneratedEnergy[i] = eolicSimulation.SimulationGeneratedEnergy;
                            }
                            else if (whichSimulation == 'c') //Hidroelèctric
                            {
                                SistemaHidroelectric hidroelecSimulation = new SistemaHidroelectric(HidroelectricType, DateTime.Now);

                                hidroelecSimulation.CabalAigua = EcoUtils.GetValidValue(MinWaterFlow, EcoUtils.GetValidDouble(MsgAskWaterFlow), MsgAskWaterFlow);
                                hidroelecSimulation.SimulationGeneratedEnergy = hidroelecSimulation.CalcularEnergia();
                                Console.WriteLine($"{MsgGeneratedEnergy}{hidroelecSimulation.SimulationGeneratedEnergy}");
                                simulationDates[i] = hidroelecSimulation.SimulationDate;
                                simulationSystemTypes[i] = hidroelecSimulation.SimulationType;
                                simulationGeneratedEnergy[i] = hidroelecSimulation.SimulationGeneratedEnergy;
                            }
                        }

                        while (continueSimulations)
                        {
                            EcoUtils.DisplayMenu();

                            switch (EcoUtils.GetValidInput())
                            {
                                case 'a':
                                    Console.WriteLine(MsgNoMoreSimulations);
                                    Console.Write(MsgDeleteSimulations);
                                    if (EcoUtils.GetYesOrNo())
                                    {
                                        continueSimulations = false;
                                    }
                                        break;
                                case 'b':
                                    EcoUtils.ShowReports(simulationDates, simulationSystemTypes, simulationGeneratedEnergy, numSimulations);
                                    break;
                                case 'c':
                                    continueSimulations = false;
                                    continueProgram = false;
                                    break;
                            }
                        }
                        break;

                    case 'b': //Show report
                        Console.WriteLine(MsgNoReports);
                        break;

                    case 'c': //Exit
                        continueProgram = false;
                        break;
                }
            }
        }
    }
}