using Newtonsoft.Json;

namespace ErrorHandling.Models
{
    public class ErrorDetails
    {
        public int Statuscode { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string CorrelationId { get; set; }

        // return object as json
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
