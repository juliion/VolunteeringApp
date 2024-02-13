//using FluentValidation;
//using VolunteeringApp.BLL.DTOs.User.Requests;

//namespace VolunteeringApp.BLL.Validators;

//public class LoginValidator : AbstractValidator<UserLoginDTO>
//{
//    public LoginValidator()
//    {
//        RuleFor(ul => ul.Email)
//             .NotNull()
//             .EmailAddress();
//        RuleFor(ut => ut.Password)
//             .NotNull()
//             .NotEmpty()
//             .Length(5, 15);
//    }
//}
