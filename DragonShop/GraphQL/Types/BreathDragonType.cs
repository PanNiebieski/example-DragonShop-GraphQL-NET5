using DragonShop.Domain;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL.Types
{
    public class BreathDragonType : EnumerationGraphType<WhatBreath>
    {
        public BreathDragonType()
        {
            Name = "BreathDragonType";
            Description = "The type of BreathDragon";
        }
    }
}
