using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum BackupJobAction
    {
        
        [DescriptionAnnotation("RESET_NOT_STARTED_TRIP", "RESET_NOT_STARTED_TRIP")]
        RESET_NOT_STARTED_TRIP = 1,

        [DescriptionAnnotation("RESET_TRIP_PENDDING_REQUEST", "RESET_TRIP_PENDDING_REQUEST")]
        RESET_TRIP_PENDDING_REQUEST = 2,

        [DescriptionAnnotation("RESET_AVAILABILITY_PENDDING_REQUEST", "RESET_AVAILABILITY_PENDDING_REQUEST")]
        RESET_AVAILABILITY_PENDDING_REQUEST = 3,

        [DescriptionAnnotation("RESET_PENDDING_CREATED_ORDER", "RESET_PENDDING_CREATED_ORDER")]
        RESET_PENDDING_CREATED_ORDER = 4,

        [DescriptionAnnotation("RESET_DM_WITHOUT_RUNNING_TRIP", "RESET_DM_WITHOUT_RUNNING_TRIP")]
        RESET_DM_WITHOUT_RUNNING_TRIP = 5,

        [DescriptionAnnotation("RESET_PENDDING_SPECIAL_TRIP", "RESET_PENDDING_SPECIAL_TRIP")]
        RESET_PENDDING_SPECIAL_TRIP = 6,

        [DescriptionAnnotation("EXPIR_PENDING_ORDER", "EXPIR_PENDING_ORDER")]
        EXPIRE_PENDING_ORDER = 7,

        [DescriptionAnnotation("CANCEL_EMPTY_READY_TRIP", "CANCEL_EMPTY_READY_TRIP")]
        CANCEL_EMPTY_READY_TRIP = 8,

        [DescriptionAnnotation("END_SHIFT", "END_SHIFT")]
        END_SHIFT = 8,


    }
}
