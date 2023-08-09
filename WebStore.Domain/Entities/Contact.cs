namespace Store.Domain.Entities
{
    public sealed class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
