namespace App.Domain.Models.Kernels
{
    public class Notification
    {
        public Notification(string message)
        {
            Id = Guid.NewGuid().ToString();
            Message = message;
        }

        public string Id { get; private set; }
        public string Message { get; private set; }
    }
}
