using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

//TODO: Change this namespace to match your project
namespace FinalProject.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        //TODO:  Add any fields that you need for creating a new user

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        //Additional fields go here
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        [Display(Name = "Zipcode")]
        public Int32 ZipCode { get; set; }

        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        [Display(Name = "Credit Card Type")]
        public String CreditCardType { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public String ConfirmPassword { get; set; }
    }
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public String OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public String NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public String ConfirmPassword { get; set; }
    }

    public class ChangeFirstNameViewModel
    {
        [Required]
        [Display(Name = "Current first name")]
        public String OldFirstName { get; set; }

        [Required]
        [Display(Name = "New first name")]
        public String NewFirstName { get; set; }
    }

    public class ChangeLastNameViewModel
    {
        [Required]
        [Display(Name = "Current last name")]
        public String OldLastName { get; set; }

        [Required]
        [Display(Name = "New last name")]
        public String NewLastName { get; set; }
    }

    public class ChangeEmailViewModel
    {
        [Required]
        [Display(Name = "Current email")]
        public String OldEmail { get; set; }

        [Required]
        [Display(Name = "New email")]
        public String NewEmail { get; set; }
    }

    public class ChangeStreetAddressViewModel
    {
        [Required]
        [Display(Name = "Current street address ")]
        public String OldStreetAddress { get; set; }

        [Required]
        [Display(Name = "New street address")]
        public String NewStreetAddress { get; set; }
    }

    public class ChangePhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Current phone number")]
        public String OldPhoneNumber { get; set; }

        [Required]
        [Display(Name = "New phone number")]
        public String NewPhoneNumber { get; set; }
    }

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String StreetAddress { get; set; }
        public String PhoneNumber { get; set; }
        public List<CreditCard> CreditCards { get; set; }
    }
}