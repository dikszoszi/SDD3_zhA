using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Validator.Tables
{
    public partial class PersonTable
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPhone { get; set; }
        public int? PersonFloor { get; set; }

        public override string ToString()
        {
            return $"#{this.PersonId}\t{this.PersonName} | {this.PersonPhone} | {this.PersonFloor}";
        }
    }
}
