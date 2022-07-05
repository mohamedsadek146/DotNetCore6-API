using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum ItemType
    {
        [DescriptionAnnotation("عميل", "CUSTOMER")]
        CUSTOMER = 1,

        [DescriptionAnnotation("طلب ", "ORDER")]
        ORDER= 2,

    
    }
}
