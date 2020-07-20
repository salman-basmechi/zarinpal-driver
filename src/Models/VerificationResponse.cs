namespace ZarinPalDriver.Models
{
    public class VerificationResponse
    {
        public VerificationResponse(Status status, string referenceId)
        {
            Status = status;
            ReferenceId = referenceId;
        }

        public Status Status { get; }

        public string ReferenceId { get; }
    }
}
