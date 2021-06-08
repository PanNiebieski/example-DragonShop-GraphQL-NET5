using System;
using System.Collections.Generic;

namespace DragonShop.Website.Models
{
    [Newtonsoft.Json.JsonObject(Title = "dragon")]
    public class DragonModel
    {
        public int Id { get; set; }
        public List<DragonExpertOpinionModel> Opinions { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Rating { get; set; }

        public ColorTypeEnum Color { get; set; }

        public BreathTypeEnum Breath { get; set; }

        public DateTimeOffset IntroducedAt { get; set; }


    }
}
