using System.ComponentModel.DataAnnotations;

namespace WereldbouwerAPI
{
    public class WereldBouwer
    {
        [Required]

        public string name; { get; set; }
        public int maxLength; { get; set; }
        public int maxHeight; { get; set; }

        public WereldBouwer(string name, int maxLength, int maxHeight)
        {
            this.name = name;
            this.maxLength = maxLength;
            this.maxHeight = maxHeight;
        }
    }
}
