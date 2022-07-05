using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum ApplicationRole
    {
        [DescriptionAnnotation("Super Admin", "Super Admin")]
        SUPER_ADMIN = 1,

        [DescriptionAnnotation("Admin", "Admin")]
        ADMIN = 2,
        [DescriptionAnnotation("MANAGER", "MANAGER")]
        BRANCH_MANAGER = 4,

        [DescriptionAnnotation("DELIVERYMAN", "DELIVERYMAN")]
        DELIVERYMAN = 5,

        [DescriptionAnnotation("SUPERVISOR", "SUPERVISOR")]
        SUPERVISOR = 6,

        //[DescriptionAnnotation("RENTER_ADMIN", "RENTER_ADMIN")]
        //RENTER_ADMIN = 7,

        //[DescriptionAnnotation("RENTER_OFFICER", "RENTER_OFFICER")]
        //RENTER_OFFICER = 8,

        [DescriptionAnnotation("AREA_MANAGER", "AREA_MANAGER")]
        AREA_MANAGER = 9,
        [DescriptionAnnotation("DISPATCHER", "DISPATCHER")]
        DISPATCHER = 10,
        [DescriptionAnnotation("OPERATOR", "OPERATOR")]
        Operator = 11,
        [DescriptionAnnotation("MARKETING", "MARKETING")]
        MARKETING = 12
    }
}
