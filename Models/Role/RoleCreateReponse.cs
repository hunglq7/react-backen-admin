namespace WebApi.Models.Role
{
    public class RoleCreateReponse
    {
                 public Guid RoleId { get; set; }
                public string? Name {  get; set; }
               public string? NormalizedName {  get; set; }
                public string? Description { get; set; }
    }
}
