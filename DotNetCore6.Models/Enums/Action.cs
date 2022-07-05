using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum Action
    {
        [DescriptionAnnotation("ANY", "ANY")]
        ANY = 0,

        [DescriptionAnnotation("INDEX", "INDEX")]
        INDEX = 1,

        [DescriptionAnnotation("CREATE", "CREATE")]
        CREATE = 2,

        [DescriptionAnnotation("EDIT", "EDIT")]
        EDIT = 3,

        [DescriptionAnnotation("DELETE", "DELETE")]
        DELETE = 4,
    }
}
