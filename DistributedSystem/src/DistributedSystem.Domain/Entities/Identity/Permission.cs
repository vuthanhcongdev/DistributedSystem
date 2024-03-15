namespace DistributedSystem.Domain.Entities.Identity;

public class Permission
{
    public Guid RoleId { get; set; }
    public string FunctionId { get; set; }
    public string ActionId { get; set; }
}
