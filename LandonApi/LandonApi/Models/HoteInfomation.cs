namespace LandonApi.Models
{
    public class HoteInfomation : Resource
    {
        public string Title { get; set; }

        public string Email { get; set; }

        public Address Location {  get; set; }  
    }

    public class Address
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
