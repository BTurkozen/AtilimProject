namespace Atilim.Services.Identity.Application.Wrappers
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public int CreatedBy { get; set; }
        //public DateTime? UpdatedOn { get; set; }
        //public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
