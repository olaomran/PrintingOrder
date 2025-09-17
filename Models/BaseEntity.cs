namespace PrintingOrder.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatorUserId { get; set; }
        public bool? isModified { get; set; }
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
        public string? ModifyUserId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; } = DateTime.UtcNow;
        public string? DeletedUserId { get; set; }
    }
}
