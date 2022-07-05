using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum ApplicationFeature
    {
        [DescriptionAnnotation("REMOVE ORDER FROM TRIP", "REMOVE ORDER FROM TRIP")]
        REMOVE_ORDER_FROM_TRIP= 1,

        [DescriptionAnnotation("ADD ORDER TO TRIP", "ADD ORDER To TRIP")]
        ADD_ORDER_To_TRIP,

        [DescriptionAnnotation("Cancel ORDER ", "Cancel ORDER")]
        CANCEL_ORDER=3,
        [DescriptionAnnotation("Pause ORDER ", "Pause ORDER")]
        PAUSE_ORDER = 4,

        [DescriptionAnnotation("UnPause ORDER ", "UnPause ORDER")]
        UnPause_ORDER = 5,

        [DescriptionAnnotation("Change Status To Ready", "Change Status To Ready")]
        CHANGE_STATUS_TO_READY = 6,

        [DescriptionAnnotation("Deliver Order", "Deliver Order")]
        DELIVER_ORDER = 7,

        [DescriptionAnnotation("Change Order Priority", "Change Order Priority")]
        CHANGE_ORDER_PRIORITY = 8,

        [DescriptionAnnotation("Update Order Info", "Update Order Info")]
        UPDATE_ORDER_INFO = 9,
        [DescriptionAnnotation("ADD USER", "ADD USER")]
        ADD_USER = 10,
        [DescriptionAnnotation("Add To Queue", "Add To Queue")]
        AddToQueue = 11,
        [DescriptionAnnotation("End_Shift", "End_Shift")]

        End_Shift = 12,
        [DescriptionAnnotation("Archive", "Archive")]

        Archive = 13,
        [DescriptionAnnotation("ChangeBranch", "ChangeBranch")]

        ChangeBranch = 14,
        [DescriptionAnnotation("RemovePenalize", "RemovePenalize")]

        RemovePenalize = 15,
        [DescriptionAnnotation("START_BREAK", "START_BREAK")]

        START_BREAK = 16,
        [DescriptionAnnotation("Reactivate", "Reactivate")]

        Reactivate = 17,
        [DescriptionAnnotation("SET_AS_IN_PROGRESS", "SET_AS_IN_PROGRESS")]
        SET_AS_IN_PROGRESS = 18,
        [DescriptionAnnotation("START_TRIP", "START_TRIP")]
        START_TRIP = 19,
        [DescriptionAnnotation("CANCEL_TRIP", "CANCEL_TRIP")]
        CANCEL_TRIP = 20,
        [DescriptionAnnotation("ASSIGN_TO_DM", "ASSIGN_TO_DM")]
        ASSIGN_TO_DM = 21,
        [DescriptionAnnotation("CREATE_SPECIAL_TRIP", "CREATE_SPECIAL_TRIP")]
        CREATE_SPECIAL_TRIP = 22,
        [DescriptionAnnotation("END_BREAK", "END_BREAK")]
        END_BREAK = 23,
        [DescriptionAnnotation("GET_ORDER_DETAIL", "GET_ORDER_DETAIL")]
        GET_ORDER_DETAIL = 24,
        [DescriptionAnnotation("GET_TRIP_DETAIL", "GET_TRIP_DETAIL")]
        GET_TRIP_DETAIL = 25,
        [DescriptionAnnotation("UPDATE_CUSTOMER_PRIORITY", "UPDATE_CUSTOMER_PRIORITY")]
        UPDATE_CUSTOMER_PRIORITY=26,
        [DescriptionAnnotation("FORCE_LOG_OUT", "FORCE_LOG_OUT")]
        FORCE_LOG_OUT = 27,
        [DescriptionAnnotation("Resolve Customer Review", "Resolve Customer Review")]
        Resolve_Customer_Review = 28,
        [DescriptionAnnotation("Set as Schedulde", "Set as Schedulde")]
        SET_AS_SCHEDULED = 29,
        [DescriptionAnnotation("Set as New", "Set as New")]
        SET_AS_NEW= 30,
        [DescriptionAnnotation("Unscheduled Order", "Unscheduled Order")]
        UNSCHEDULED_ORDER = 31
    }
}
