using client_desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace client_desktop.ViewModels
{
    class AccountViewModel : ViewModelBase
    {
        private static readonly AccountServiceReference.IAccountService accountService = new AccountServiceReference.AccountServiceClient();

        private string userName_ = Account.GetInstace().UserName;
        private string firstName_ = Account.GetInstace().FirstName;
        private string lastName_ = Account.GetInstace().LastName;
        private string phone_ = Account.GetInstace().Phone;
        private string email_ = Account.GetInstace().Email;
        private string oldPassword_ = string.Empty;
        private string newPassword_ = string.Empty;
        private string errorMessage_ = string.Empty;

        public string UserName
        {
            get
            {
                return userName_;
            }
            set
            {
                userName_ = value;
                OnPropertyChanged("UserName");
            }
        }
        public string FirstName
        {
            get
            {
                return firstName_;
            }
            set
            {
                firstName_ = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return lastName_;
            }
            set
            {
                lastName_ = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Phone
        {
            get
            {
                return phone_;
            }
            set
            {
                phone_ = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Email
        {
            get
            {
                return email_;
            }
            set
            {
                email_ = value;
                OnPropertyChanged("Email");
            }
        }

        public string OldPassword
        {
            get
            {
                return oldPassword_;
            }
            set
            {
                oldPassword_ = value;
                OnPropertyChanged("OldPassword");
            }
        }

        public string NewPassword
        {
            get
            {
                return newPassword_;
            }
            set
            {
                newPassword_ = value;
                OnPropertyChanged("NewPassword");
            }
        }


        public string ErrorMessage
        {
            get
            {
                return errorMessage_;
            }
            set
            {
                errorMessage_ = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public ICommand EditAccountCancelCommand
        {
            get
            {
                return new DelegateCommand(EditAccountCancel);
            }
        }

        private void EditAccountCancel()
        {
            Phone = Account.GetInstace().Phone;
            Email = Account.GetInstace().Email;
            OldPassword = string.Empty;
            NewPassword = string.Empty;
            UserName = Account.GetInstace().UserName;
        }

        public ICommand EditAccountOkCommand
        {
            get
            {
                return new DelegateCommand(EditAccountOk);
            }
        }

        private void EditAccountOk()
        {
            try
            {
                if (CheckFields())
                {
                    if (accountService.SetChangesAsync(new AccountServiceReference.Person { Email = Email, Phone = Phone, UserName = UserName }, Account.GetInstace().Session).Result)
                    {
                        Account.GetInstace().Email = Email;
                        Account.GetInstace().Phone = Phone;
                        Account.GetInstace().UserName = UserName;
                    }
                    if (!OldPassword.Equals(string.Empty) && !NewPassword.Equals(string.Empty))
                    {
                        accountService.ChangePasswordAsync(Convert.ToBase64String(Hash.GenerateHash(Encoding.UTF8.GetBytes(OldPassword))), Convert.ToBase64String(Hash.GenerateHash(Encoding.UTF8.GetBytes(NewPassword))), Account.GetInstace().Session);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        private bool CheckFields()
        {
            if (Email.Equals(string.Empty) || Phone.Equals(string.Empty) || UserName.Equals(string.Empty))
            {
                throw new Exception("Please fill out the fields");
            }
            if (FieldValidation.ValidatePhone(Phone))
            {

            }
            if (!OldPassword.Equals(string.Empty) && !NewPassword.Equals(string.Empty))
            {
                if (!FieldValidation.ValidatePassword(NewPassword))
                {
                    throw new Exception("Not a valid password");
                }
            }
            return true;
        }
    }
}
