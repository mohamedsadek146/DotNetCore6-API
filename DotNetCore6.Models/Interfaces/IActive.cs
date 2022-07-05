namespace DotNetCore6.Models.Interfaces
{
    public interface IActive
    {
        int ID { get; set; }
        bool IsActive { get; set; }
    }
}
