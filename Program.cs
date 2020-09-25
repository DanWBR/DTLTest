using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTLTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var dtlc = new DWSIM.Thermodynamics.CalculatorInterface.Calculator();
            dtlc.Initialize();

            //var pp = dtlc.GetPropPackInstance("Peng-Robinson (PR)");
            //dtlc.SetupPropertyPackage(pp, new[] { "Methane", "Ethane" }, new[] { 0.5, 0.5 });
            //var ms = (DWSIM.Thermodynamics.Streams.MaterialStream)pp.CurrentMaterialStream;
            //ms.SetTemperature(200);
            //ms.SetPressure(1000000);
            //ms.SetMassFlow(1);
            //ms.Calculate();

            //var surftens = ms.GetPhase("Mixture").Properties.surfaceTension.GetValueOrDefault();

            DWSIM.Thermodynamics.PropertyPackages.PropertyPackage ppTest;

            ppTest = new ReaktoroPropertyPackage.ReaktoroPropertyPackage();

            string flashAlgorithm = "NL VLE";

            DWSIM.Thermodynamics.Streams.MaterialStream materialStream;

            var molefraction = new double[] { 0.9, 0.1 };

            var materials = new string[] { "Water", "Ammonia" };

            materialStream = dtlc.CreateMaterialStream(materials, molefraction);

            materialStream.PreferredFlashAlgorithmTag = flashAlgorithm;

            materialStream.PropertyPackage = ppTest;

            materialStream.SetTemperature(273.15);

            materialStream.SetPressure(100000);

            materialStream.SetMassFlow(1);

            materialStream.Calculate();  //--> null ref exception

        }
    }
}
