using DotNetCore6.Models.Interfaces;

namespace DotNetCore6.ViewModels.Shared
{
    public class ActivateViewModel
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
    }
    public static class ActivateExtension
    {
        public static T ToModel<T>(this ActivateViewModel viewModel) where T : IActive, new()
        {
            T model = new T();
            model.ID = viewModel.ID;
            model.IsActive = viewModel.IsActive;
            return model;
        }
    }

}
