using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TCSASystems.Blazor.EmployeeManagement.Areas.Identity.Pages.Account;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager
 

        public LoginModel(SignInManager<Identity> signInManager)
    {
        _signInManager = signInManager;
      
    }
    [BindProperty]
    public InputModel Input { get; set; }
    
    public async Task<IActionResult> OnPosrAsync()
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, lockoutOnFailure:false);
            if (result.Succeeded)
            {
                return LocalRedirect("~/")
            }
        }
        return Pages();
    }
}
public class InputModel
{
    [Required]
    [EmailAddress]

    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
