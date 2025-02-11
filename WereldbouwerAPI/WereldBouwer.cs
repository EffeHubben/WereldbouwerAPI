using System.ComponentModel.DataAnnotations;

namespace WereldbouwerAPI
{
    public class WereldBouwer
    {
        [Required]
        public string name { get; set; }
        public int maxLength { get; set; }
        public int maxHeight { get; set; }

        // Constructor to initialize the 'name' field
        public WereldBouwer(string name)
        {
            this.name = name;
        }
    }
}