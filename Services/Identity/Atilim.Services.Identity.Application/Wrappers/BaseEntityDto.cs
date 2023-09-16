namespace Atilim.Services.Identity.Application.Wrappers
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
