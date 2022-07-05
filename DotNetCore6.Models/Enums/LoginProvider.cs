using DotNetCore6.Models.Shared;


namespace DotNetCore6.Models.Enums
{
    public enum LoginProvider
    {
        [DescriptionAnnotation("TayarUser", "TayarUser")]
        TayarUser = 1,
        [DescriptionAnnotation("Active Directory", "Active Directory")]
        ActiveDirectory = 2,
    }
}
