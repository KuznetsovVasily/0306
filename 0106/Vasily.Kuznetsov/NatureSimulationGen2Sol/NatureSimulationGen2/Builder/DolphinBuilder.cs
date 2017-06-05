using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.BuilderRecorder;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Builder
{
    public class DolphinBuilder : AnimalBuilder
    {
        public override Entity Build()
        {
            var dolphin = new Dolphin(X, Y, Gender);
            dolphin.SetHealth(Health);
            dolphin.SetGender(Gender);
            return dolphin;
        }
    }
}
