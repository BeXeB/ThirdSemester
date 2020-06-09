using client_desktop.Models;
using client_desktop.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace client_desktop.ViewModels
{
    class LoginRegisterViewModel : ViewModelBase
    {
        private static readonly LoginRegisterServiceReference.ILoginRegisterService loginRegisterService = new LoginRegisterServiceReference.LoginRegisterServiceClient();
        private static readonly HouseServiceReference.IHouseService houseService = new HouseServiceReference.HouseServiceClient();

        private string errorMsg_ = string.Empty;
        private string loginUserName_ = string.Empty;
        private string loginPassword_ = string.Empty;
        private string registerFirstName_ = string.Empty;
        private string registerLastName_ = string.Empty;
        private string registerPhone_ = string.Empty;
        private DateTimeOffset registerBirthDate_ = DateTimeOffset.Parse("1999-06-30 00:00:00");
        private string registerEmail_ = string.Empty;
        private string registerPassword_ = string.Empty;
        private string registerPasswordConfirm_ = string.Empty;
        private string registerUserName_ = string.Empty;
        private bool isRegisterPhoneValid_;
        private bool isRegisterEmailValid_;
        private bool isRegisterPasswordValid_;
        private bool isRegisterPasswordMatch_;
        private bool isRegister_ = false;
        private bool isLogin_ = true;
        private bool isFPw_ = false;


        public string ErrorMsg
        {
            get
            {
                return errorMsg_;   
            }
            set
            {
                errorMsg_ = value;
                OnPropertyChanged("ErrorMsg");
            }
        }

        public string RegisterUserName
        {
            get
            {
                return registerUserName_;
            }
            set
            {
                registerUserName_ = value;
                OnPropertyChanged("RegisterUserName");
            }
        }

        public string LoginUserName
        {
            get
            {
                return loginUserName_;
            }
            set
            {
                loginUserName_ = value;
                OnPropertyChanged("LoginUserName");
            }
        }

        public string LoginPassword
        {
            get
            {
                return loginPassword_;
            }
            set
            {
                loginPassword_ = value;
                OnPropertyChanged("LoginPassword");
            }
        }

        public string RegisterFirstName
        {
            get
            {
                return registerFirstName_;
            }
            set
            {
                registerFirstName_ = value;
                OnPropertyChanged("RegisterFirstName");
            }
        }

        public string RegisterLastName
        {
            get
            {
                return registerLastName_;
            }
            set
            {
                registerLastName_ = value;
                OnPropertyChanged("RegisterLastName");
            }
        }

        public string RegisterPhone
        {
            get
            {
                return registerPhone_;
            }
            set
            {
                registerPhone_ = value;
                if (!FieldValidation.ValidatePhone(RegisterPhone))
                {
                    IsRegisterPhoneValid = false;
                }
                else
                {
                    IsRegisterPhoneValid = true;
                }
                OnPropertyChanged("RegisterPhone");
            }
        }

        public DateTimeOffset RegisterBirthDate
        {
            get
            {
                return registerBirthDate_;
            }
            set
            {
                registerBirthDate_ = value;
                OnPropertyChanged("RegisterBirthDate");
            }
        }

        public string RegisterEmail
        {
            get
            {
                return registerEmail_;
            }
            set
            {
                registerEmail_ = value;
                if (!FieldValidation.ValidateEmail(RegisterEmail))
                {
                    IsRegisterEmailValid = false;
                }
                else
                {
                    IsRegisterEmailValid = true;
                }
                OnPropertyChanged("RegisterEmail");
            }
        }

        public string RegisterPassword
        {
            get
            {
                return registerPassword_;
            }
            set
            {
                registerPassword_ = value;
                if (!FieldValidation.ValidatePassword(RegisterPassword))
                {
                    IsRegisterPasswordValid = false;
                }
                else
                {
                    IsRegisterPasswordValid = true;
                }
                OnPropertyChanged("RegisterPassword");
            }
        }

        public string RegisterPasswordConfirm
        {
            get
            {
                return registerPasswordConfirm_;
            }
            set
            {
                registerPasswordConfirm_ = value;
                if (RegisterPasswordConfirm.Equals(RegisterPassword))
                {
                    IsRegisterPasswordMatch = true;
                }
                else
                {
                    IsRegisterPasswordMatch = false;
                }
                OnPropertyChanged("RegisterPasswordConfirm");
            }
        }

        public bool IsRegisterPhoneValid
        {
            get
            {
                return isRegisterPhoneValid_;
            }
            set
            {
                isRegisterPhoneValid_ = value;
                OnPropertyChanged("IsRegisterPhoneValid");
            }
        }

        public bool IsRegisterEmailValid
        {
            get
            {
                return isRegisterEmailValid_;
            }
            set
            {
                isRegisterEmailValid_ = value;
                OnPropertyChanged("IsRegisterEmailValid");
            }
        }

        public bool IsRegisterPasswordValid
        {
            get
            {
                return isRegisterPasswordValid_;
            }
            set
            {
                isRegisterPasswordValid_ = value;
                OnPropertyChanged("IsRegisterPasswordValid");
            }
        }

        public bool IsRegisterPasswordMatch
        {
            get
            {
                return isRegisterPasswordMatch_;
            }
            set
            {
                isRegisterPasswordMatch_ = value;
                OnPropertyChanged("IsRegisterPasswordMatch");
            }
        }

        public bool IsRegister
        {
            get
            {
                return isRegister_;
            }
            set
            {
                isRegister_ = value;
                OnPropertyChanged("IsRegister");
            }
        }

        public bool IsLogin
        {
            get
            {
                return isLogin_;
            }
            set
            {
                isLogin_ = value;
                OnPropertyChanged("IsLogin");
            }
        }

        public bool IsFPw
        {
            get
            {
                return isFPw_;
            }
            set
            {
                isFPw_ = value;
                OnPropertyChanged("IsFPw");
            }
        }

        public ICommand GoToLoginCommand
        {
            get
            {
                return new DelegateCommand(GoToLogin);
            }
        }

        public ICommand GoToRegisterCommand
        {
            get
            {
                return new DelegateCommand(GoToRegister);
            }
        }

        public ICommand RegisterClicked
        {
            get
            {
                return new DelegateCommand(Register);
            }
        }

        public ICommand LoginClicked
        {
            get
            {
                return new DelegateCommand(Login);
            }
        }

        private void GoToLogin()
        {
            IsLogin = true;
            IsFPw = false;
            IsRegister = false;
        }

        private void GoToRegister()
        {
            IsRegister = true;
            IsLogin = false;
            IsFPw = false;
        }

        private void Register()
        {
            try
            { 
                if (CheckRegisterFields())
                {
                    string password = Convert.ToBase64String(Hash.GenerateHash(Encoding.UTF8.GetBytes(RegisterPassword)));
                    string message = loginRegisterService.RegisterAsync(new LoginRegisterServiceReference.Person { DateOfBirth = RegisterBirthDate.DateTime, Email = RegisterEmail, FirstName = RegisterFirstName, LastName = RegisterLastName, PassWord = password, Phone = RegisterPhone, UserName = RegisterUserName }).Result;
                    ErrorMsg = message;
                    GoToLogin();
                }
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }

        private bool CheckRegisterFields()
        {
            if (RegisterFirstName.Equals(string.Empty) || RegisterLastName.Equals(string.Empty))
            {
                throw new Exception(message: "Please fill in the fields");
            }
            if (!IsRegisterPhoneValid)
            {
                throw new Exception(message: "Invalid Phone");
            }
            if (!IsRegisterEmailValid)
            {
                throw new Exception(message: "Invalid Email");
            }
            if (!IsRegisterPasswordValid)
            {
                throw new Exception(message: "Invalid Password");
            }
            if (!IsRegisterPasswordMatch)
            {
                throw new Exception(message: "Passwords don't match");
            }
            return true;
        }

        private void Login()
        {
            try
            {
                string password = Convert.ToBase64String(Hash.GenerateHash(Encoding.UTF8.GetBytes(LoginPassword)));
                string session = loginRegisterService.LoginAsync(new LoginRegisterServiceReference.Person { UserName = LoginUserName, PassWord = password }).Result;
                if (session != null)
                {
                    Account.GetInstace().Session = session;
                    HouseListViewModel.Houses.Clear();
                    ObservableCollection<HouseServiceReference.House> serverlist = houseService.GetAllHouseAsync(Account.GetInstace().Session).Result;
                    foreach (var house in serverlist)
                    {
                        ObservableCollection<Person> people = new ObservableCollection<Person>();
                        foreach (var person in house.People)
                        {
                            people.Add(new Person { UserName = person.Person.UserName });
                        }
                        HouseListViewModel.Houses.Add(new HouseItem { City = house.Address.City, DoorNo = house.Address.DoorNo, Floor = house.Address.FloorNo, HouseNo = house.Address.HouseNo, Id = house.Id, Street = house.Address.Street, ZipCode = house.Address.ZipCode, InviteCode = house.InviteCode, People = people, Chat = new ObservableCollection<ChatItem>(), Chores = new ObservableCollection<ChoreItem>() });
                    }
                    NavigationService navigationService = new NavigationService();
                    navigationService.NavigateTo(typeof(HomePage));
                    navigationService.NavigateHomePageTo(typeof(HouseListPage));
                }
                else
                {
                    ErrorMsg = "Could not log in";
                }
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
            }
        }
    }
}