using System.ComponentModel.DataAnnotations;

namespace DragonShop.Domain
{
    public class DragonExpertOpinion
    {
        public int Id { get; set; }
        public int DragonId { get; set; }
        public Dragon Dragon { get; set; }

        [StringLength(150), Required]
        public string Title { get; set; }

        public string Review { get; set; }
    }
}
