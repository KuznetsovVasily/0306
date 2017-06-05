using NatureSimulationGen2.Animal;
using NatureSimulationGen2.BuilderRecorder;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Builder
{
    public class RabbitBuilder : AnimalBuilder
    {
        public override Entity Build()
        {
            var rabbit = new Rabbit(X, Y, Gender, IsVegan = true);
            rabbit.SetHealth(Health);
            rabbit.SetGender(Gender);
            return rabbit;
        }
    }
}
