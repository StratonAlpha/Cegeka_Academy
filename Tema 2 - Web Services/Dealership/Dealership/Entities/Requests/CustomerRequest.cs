namespace Dealership.Entities
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public CustomerRequest(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
