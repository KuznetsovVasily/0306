using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using NatureSimulationGen2.Global;

namespace NatureSimulationGen2.Animal
{
    public abstract class Animal : Entity
    {
        protected int Speed { get; set; }
        public int Health { get; set; }
        public bool IsEatable { get; set; }
        public Gender Gender { get; set; }
        public int PregnantTimer { get; set; }
        public bool IsVegan { get; set; }
        protected Animal(int x, int y, Gender gender = Gender.Male)
            : base(x, y)
        {
            Gender = gender;
            Speed = GetSpeed();
            Health = GetHealth();
            IsEatable = GetEdibility();
            PregnantTimer = GetPregnantTimer();
            IsVegan = GetIsVegan();
        }
        protected abstract int GetSpeed();
        protected abstract int GetHealth();
        protected abstract bool GetEdibility();
        protected abstract int GetPregnantTimer();
        protected abstract bool GetIsVegan();

        public override bool GetBarrier()
        {
            return false;
        }
    }
}
