using NatureSimulationGen2.Animal;
using NatureSimulationGen2.BuilderRecorder;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Builder
{
    public class OwlBuilder : AnimalBuilder
    {
        private bool predator = true;
        public override Entity Build()
        {
            var owl = new Owl(X, Y, Gender, predator);
            owl.SetHealth(Health);
            owl.SetGender(Gender);
            return owl;
        }
    }
}
