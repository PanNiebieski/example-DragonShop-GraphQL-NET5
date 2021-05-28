using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragonShop.Domain
{
    public class Dragon
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public DateTimeOffset IntroducedAt { get; set; }

        public bool Active { get; set; }

        public int CrewCapacity { get; set; }

        public string Description { get; set; }

        public double DiameterMeters { get; set; }

        public int DryMassKg { get; set; }

        public bool DoneFirstFlight { get; set; }

        public int Age { get; set; }

        public int OrbitDurationYears { get; set; }

        public string Name { get; set; }

        public WhatColors Color { get; set; }

        public WhatBreath Breath { get; set; }

        public double HeightInMeters { get; set; }
    }



}
