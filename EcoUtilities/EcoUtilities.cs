namespace Eco
{
    public class EcoUtils
    {
        public static void DisplayMenu()
        {
            const string MenuTitle = " ECO ENERGY MENU";
            const string MenuSeparation = " ---------------";
            const string MenuEmptySeparation = "\n";
            const string MenuOptionA = " a) [Initiate simulation]";
            const string MenuOptionB = " b) [See simulations report]";
            const string MenuOptionC = " c) [Exit]";
            const string MenuHelpUser = " Press a, b or c to select your option: ";

            Console.WriteLine(MenuEmptySeparation);
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuSeparation);
            Console.WriteLine($"{MenuEmptySeparation}{MenuOptionA}");
            Console.WriteLine(MenuOptionB);
            Console.WriteLine(MenuOptionC);
            Console.Write($"{MenuEmptySeparation}{MenuHelpUser}");
        }
        public static void DisplaySimulationStartMenu()
        {
            const string MenuTitle = " SIMULATION MENU";
            const string MenuSeparation = " ---------------";
            const string MenuEmptySeparation = "\n";
            const string MenuOptionA = " a) [Solar system]";
            const string MenuOptionB = " b) [Eolic system]";
            const string MenuOptionC = " c) [Hidroelectric system]";
            const string MenuHelpUser = " Press a, b or c to select your option: ";

            Console.WriteLine(MenuEmptySeparation);
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuSeparation);
            Console.WriteLine($"{MenuEmptySeparation}{MenuOptionA}");
            Console.WriteLine(MenuOptionB);
            Console.WriteLine(MenuOptionC);
            Console.Write($"{MenuEmptySeparation}{MenuHelpUser}");
        }
        public static void ShowReports(DateTime[] dates, string[] types, double[] energy, int numSimulations)
        {
            const string MsgDates = "Date";
            const string MsgTypes = "Type";
            const string MsgEnergy = "Generated Energy";

            string Separation = new string('-', 60);

            Console.WriteLine();    
            Console.WriteLine($" {MsgDates, -20}| {MsgTypes, -15}| {MsgEnergy, -20}");
            //Els valors negatius dels missatges indiquen alineació a l'esquerra de mida X
            Console.WriteLine($" {Separation}\n");

            for (int i = 0; i < numSimulations; i++)
            {
                Console.WriteLine($" {dates[i], -20}| {types[i], -15}| {energy[i], -20}");
                Console.WriteLine($" {Separation}");
            }
        }
        public static double GetValidValue(double min, double num, string msgAsk)
        {
            const string msgError = " The value should be {0} or higher!";
            double newNum = 0;
            if (num < min)
            {
                do
                {
                    Console.WriteLine(msgError, min);
                    newNum = GetValidDouble(msgAsk);
                } while (newNum < min);
                return newNum;
            }
            else { return num; }
        }
        public static char GetValidInput()
        {
            const string Error = " Type a valid option (a, b or c): ";

            bool valid;
            char output = 'a';

            do
            {
                string? input = Console.ReadLine();
                if (char.TryParse(input, out output))
                {
                    output = Char.ToLower(output);
                    if (output == 'a' || output == 'b' || output == 'c') { valid = true; }
                    else 
                    { 
                        Console.Write(Error);
                        valid = false; 
                    }
                }
                else { Console.Write(Error); valid = false; }
            } while (!valid);

            return output;
        }
        public static bool GetYesOrNo()
        {
            const string Error = " Type a valid option (Y or N): ";

            bool valid;
            bool functionOutput = false;
            char output = 'a';

            do
            {
                string? input = Console.ReadLine();
                if (char.TryParse(input, out output))
                {
                    output = Char.ToUpper(output);
                    if (output == 'Y'){ functionOutput = true; valid = true; }
                    else if (output == 'N') { functionOutput = false; valid = true; }
                    else {
                        Console.WriteLine(Error);
                        valid = false;
                    }
                } else { valid = false; }
            } while (!valid);

            return functionOutput;
        }
        public static double GetValidDouble(string MsgInfo)
        {
            const string Error = " Type a valid number";

            bool valid;
            double output = 0;

            Console.Write(MsgInfo);

            do
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out output))
                {
                    valid = true;
                }
                else { Console.WriteLine(Error); valid = false; }
            } while (!valid);

            return output;
        }

        public static int GetValidInt(string MsgInfo)
        {
            const string Error = " Type a valid number";

            bool valid;
            int output = 0;

            Console.Write(MsgInfo);
            do
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out output))
                {
                    valid = true;
                }
                else { Console.WriteLine(Error); valid = false; }
            } while (!valid);

            return output;
        }
    }
}