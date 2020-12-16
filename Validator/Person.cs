namespace Validator
{
    public class Person
    {
        public Person(System.Xml.Linq.XElement source) : this()
        {
            if (source is not null)
            {
                this.Name = source.Element("name").Value;
                this.Email = source.Element("email").Value;
                this.Dept = source.Element("dept").Value;
                this.Rank = source.Element("rank").Value;
                this.Phone = source.Element("phone").Value;

                string[] room = source.Element("room").Value.Split('.');
                if (room.Length >= 2 && int.TryParse(room[1], out int floor))
                {
                    this.Floor = floor;
                }
            }
        }

        public Person()
        {
        }

        [DbPropertyName("PersonId")]
        public int Id { get; set; }

        [NotNull]
        [NotEmpty]
        [DbPropertyName("PersonName")]
        public string Name { get; set; }

        [NotNull]
        [NotEmpty]
        public string Email { get; set; }

        [NotNull]
        [NotEmpty]
        public string Dept { get; set; }

        [NotNull]
        [NotEmpty]
        public string Rank { get; set; }

        [NotNull]
        [NotEmpty]
        [DbPropertyName("PersonPhone")]
        public string Phone { get; set; }

        [DbPropertyName("PersonFloor")]
        public int Floor { get; set; }

        public override string ToString()
        {
            return $"#{this.Id}\t{this.Name} | {this.Rank} - {this.Dept} | {this.Email} | {this.Floor}";
        }
    }
}
