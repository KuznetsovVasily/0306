﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NatureSimulationGen2.AquaAnimal;
using NatureSimulationGen2.Global;
using NatureSimulationGen2.Plant;

namespace NatureSimulationGen2.Animal
{
    public class Owl : Animal
    {
        protected static int RandomDelta { get; set; }
        protected int Timer { get; set; }
        public bool Predator { get; set; }
        public Owl(int x, int y, Gender gender = Gender.Male, bool predator = true)
            : base(x, y, gender)
        {
            Predator = predator;
        }
        public override List<SurfaceType> GetSurfaces()
        {
            return new List<SurfaceType> { Global.SurfaceType.Ground, Global.SurfaceType.Water };
        }
        protected override int GetSpeed()
        {
            return 1;
        }
        protected override int GetHealth()
        {
            return this.Health;
        }

        public void SetHealth(int health)
        {
            this.Health = health;
        }
        public void SetGender(Gender gender)
        {
            this.Gender = gender;
        }
        protected override bool GetEdibility()
        {
            return false;
        }
        protected override bool GetIsVegan()
        {
            return false;
        }
        public override Intention RequestIntention(World world)
        {
            Health--;
            var objectsAtTheSamePoint = world.GetObjectsAt(X, Y).Where(e => !e.Equals(this));
            if (Timer % 3 == 0 && objectsAtTheSamePoint is Animal)
            {
                if (objectsAtTheSamePoint.Any(e => ((Animal)e).IsEatable = true))             
                {
                    Timer++;
                    Health = Health + RandomHolder.GetInstance().Random.Next(6);
                    ((Animal) objectsAtTheSamePoint.FirstOrDefault()).Health = 0;
                    return new Intention { DeltaX = 0, DeltaY = 0 };
                }
            }
            RandomDelta = RandomHolder.GetInstance().Random.Next(-1, 2);
            while (RandomDelta == 0)
            {
                RandomDelta = RandomHolder.GetInstance().Random.Next(-1, 2);
            }
            var rand = RandomHolder.GetInstance().Random.Next(2);
            if (rand == 0)
            {
                return new Intention { DeltaX = 0, DeltaY = (RandomDelta * Speed) };
            }
            return new Intention { DeltaX = (RandomDelta * Speed), DeltaY = 0 };
        }
    }
}


