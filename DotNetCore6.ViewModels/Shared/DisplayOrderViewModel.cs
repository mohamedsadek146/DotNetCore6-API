using DotNetCore6.Models.Interfaces;

namespace DotNetCore6.ViewModels.Shared
{
    public class DisplayOrderViewModel
    {
        public int ID { get; set; }
        public int DisplayOrder { get; set; }
    }
    public static class DisplayOrderExtension
    {
        public static T ToModel<T>(this DisplayOrderViewModel viewModel) where T : IDisplayOrder, new()
        {
            T result = new T();
            result.ID = viewModel.ID;
            result.DisplayOrder = viewModel.DisplayOrder;
            return result;
        }
    }
}
