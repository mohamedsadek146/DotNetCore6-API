namespace DotNetCore6.Models.Interfaces
{
    public interface IDelete
    {
        int ID { get; set; }
        bool IsDeleted { get; set; }
    }
}
