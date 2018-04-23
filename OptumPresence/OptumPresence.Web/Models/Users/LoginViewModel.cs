using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OptumPresence.Domain.Entities;
using OptumPresence.Models.Shared;

namespace OptumPresence.Models.Users
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            this.UserEntity = new UserEntity();
        }

        public UserEntity UserEntity { get; set; }

        //TODO: Setup resource file for validation messages
        [Required(ErrorMessage = "Please Input Username")]
        public string Username
        {
            get
            {
                return this.UserEntity.Username;
            }
            set
            {
                this.UserEntity.Username = value;
            }
        }

        //TODO: Setup resource file for validation messages
        [Required(ErrorMessage = "Please Input Password")]
        public string Password
        {
            get
            {
                return this.UserEntity.Password;
                
            }
            set
            {
                this.UserEntity.Password = value;
                
            }
        }
    }
}