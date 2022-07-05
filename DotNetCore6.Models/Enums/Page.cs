using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum Page
    {
        [DescriptionAnnotation("ANY", "ANY")]
        ANY = 0,

        [DescriptionAnnotation("User", "User")]
        USER = 1,

        [DescriptionAnnotation("Role", "Role")]
        ROLE = 2,

        [DescriptionAnnotation("Job", "Job")]
        JOB = 3,


        [DescriptionAnnotation("Employee", "Employe")]
        EMPLOYEE = 4,

        [DescriptionAnnotation("Governrate", "Governrate")]
        Governrate = 5,

        [DescriptionAnnotation("City", "City")]
        City = 5,

        [DescriptionAnnotation("Customer", "Customer")]
        Customer = 6,

        [DescriptionAnnotation("Service", "Service")]
        Service = 6,

        [DescriptionAnnotation("Shipping Address", "Shipping Address")]
        ShippingAddress = 7,

        [DescriptionAnnotation("Trip", "Trip")]
        Trip = 8,

        [DescriptionAnnotation("Order", "Order")]
        Order = 9,

        [DescriptionAnnotation("Branch Configuration", "Branch Configuration")]
        BranchConfiguration = 10,

        [DescriptionAnnotation("Order Priority", "Order Priority")]
        OrderPriority = 11,

        [DescriptionAnnotation("Branch", "Branch")]
        BRANCH = 12,

        [DescriptionAnnotation("DELIVERYMAN", "DELIVERYMAN")]
        DELIVERYMAN = 13,

        [DescriptionAnnotation("DEVICE_TOKEN", "DEVICE_TOKEN")]
        DEVICE_TOKEN = 14,





    }
}
