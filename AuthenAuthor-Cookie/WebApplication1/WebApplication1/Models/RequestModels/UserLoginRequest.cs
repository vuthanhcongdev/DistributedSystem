namespace WebApplication1.Models.RequestModels;

public record UserLoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; } 
    public bool RememberMe { get; set; }
}
