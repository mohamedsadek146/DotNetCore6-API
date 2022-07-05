using DotNetCore6.Models.Shared;

namespace DotNetCore6.Models.Enums
{
    public enum AttachmentType
    {
        [DescriptionAnnotation("العقد", "Contract")]
        Contract = 0,
        [DescriptionAnnotation("صورة لموقف السيارات", "Parking photo")]
        ParkingPhoto = 1,
    }

}
