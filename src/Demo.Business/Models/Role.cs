using System.Runtime.Serialization;

namespace Demo.Business.Models;

public enum Role
{
    [EnumMember(Value = "None")]
    None = 0,

    [EnumMember(Value = "Management")]
    Management = 1,

    [EnumMember(Value = "Operations")]
    Operations = 2
}
