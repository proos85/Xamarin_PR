namespace XamarinBootcamp.Services
{
    public class DisplayService : IDisplayService
    {
        public DisplayService()
        {

        }

        public string GetMessage()
        {
            return $"I'm clicked from display service.{nameof(GetMessage)}";
        }
    }
}