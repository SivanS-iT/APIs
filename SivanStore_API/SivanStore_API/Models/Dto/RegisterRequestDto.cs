namespace SivanStore_API.Models.Dto
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role{ get; set; }  // role shouldn't be here but it is done for learning

    }
}
