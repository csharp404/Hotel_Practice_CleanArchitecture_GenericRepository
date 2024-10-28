namespace Client.Models
{
   


    public class Guest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string passportNumber { get; set; }
        public bool isPimp { get; set; }
        public List<Room> rooms { get; set; }
    }

}
