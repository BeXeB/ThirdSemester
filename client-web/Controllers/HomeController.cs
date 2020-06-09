using System;
using LoginRegisterServiceReference;
using client_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using AccountServiceReference;
using ListServiceReference;
using HouseServiceReference;
using ChatServiceReference;
using ChoreServiceRefence;
using System.Collections.Generic;

namespace client_web.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private static readonly ILoginRegisterService loginRegisterService = new LoginRegisterServiceClient();
        private static readonly IAccountService accountService = new AccountServiceClient();
        private static readonly IListService listService = new ListServiceClient();
        private static readonly IHouseService houseService = new HouseServiceClient();
        private static readonly IChatService chatService = new ChatServiceClient();
        private static readonly IChoreService choreService = new ChoreServiceClient();

        [Route("")]
        [Route("/index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [Route("")]
        [Route("/index")]
        [Route("~/")]
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (model.Password == null || model.UserName == null)
            {
                ViewBag.NotValidUser = "Please fill in the fields";
                return View("Index");
            }
            string sessionid = loginRegisterService.LoginAsync(new LoginRegisterServiceReference.Person { UserName = model.UserName, PassWord = Convert.ToBase64String(GenerateHash(Encoding.UTF8.GetBytes(model.Password))) }).Result;
            if (sessionid != null)
            {
                AccountModel.GetInstace().Session = sessionid;
                return Home();
            }
            else
            {
                ViewBag.NotValidUser = "Could not login";
            }
            return View("Index");
        }

        [Route("/register")]
        public IActionResult Register()
        {
            return View("RegisterView");
        }

        [Route("/register")]
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password == null || model.UserName == null || model.FirstName == null || model.DoB != null || model.LastName == null || model.Email == null || model.Phone == null || model.ConfirmPassword == null || !model.Password.Equals(model.ConfirmPassword))
            {
                ViewBag.NotValidUser = "Please fill in the fields";
                return View("RegisterView");
            }
            string result = loginRegisterService.RegisterAsync(new LoginRegisterServiceReference.Person { DateOfBirth = model.DoB, Phone = model.Phone, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PassWord = Convert.ToBase64String(GenerateHash(Encoding.UTF8.GetBytes(model.Password))) }).Result;
            if (result.Equals("Successful Registration"))
            {
                return View("Index");
            }
            else
            {
                ViewBag.NotValidUser = result;
            }
            return View("RegisterView");
        }


        [Route("/account")]
        public IActionResult Account()
        {
            AccountServiceReference.Person person = accountService.GetAccountIfromationAsync(AccountModel.GetInstace().Session).Result;
            AccountModel.GetInstace().Id = person.Id;
            AccountModel.GetInstace().UserName = person.UserName;
            AccountModel.GetInstace().FirstName = person.FirstName;
            AccountModel.GetInstace().LastName = person.LastName;
            AccountModel.GetInstace().Phone = person.Phone;
            AccountModel.GetInstace().Email = person.Email;
            return View("AccountView", AccountModel.GetInstace());
        }

        [Route("/account")]
        [HttpPost]
        public IActionResult Account(AccountModel model)
        {
            accountService.SetChangesAsync( new AccountServiceReference.Person { Email = model.Email, Phone = model.Phone, UserName = model.UserName }, AccountModel.GetInstace().Session).Wait();
            if (model.NewPassword!=null && model.OldPassword!=null)
            {
                accountService.ChangePasswordAsync(Convert.ToBase64String(GenerateHash(Encoding.UTF8.GetBytes(model.OldPassword))), Convert.ToBase64String(GenerateHash(Encoding.UTF8.GetBytes(model.NewPassword))), AccountModel.GetInstace().Session ).Wait();
            }
            return Account();
        }

        [Route("/list")]
        public IActionResult List()
        {
            MemoList[] list = listService.GetAllListAsync(AccountModel.GetInstace().Session).Result;
            List<ListModel> lists = new List<ListModel>();
            foreach (var item in list)
            {
                lists.Add(new ListModel { Title = item.Title, Description = item.Description, Id = item.Id });
            }
            ViewBag.list = lists;
            return View("ListView");
        }

        [Route("/editlist")]
        public IActionResult EditList(ListModel model)
        {
            return View("EditListView", model);
        }

        [Route("/editlist")]
        [HttpPost]
        public IActionResult EditListEdit(ListModel model)
        {
            if (model.Title != null && model.Description != null)
            {
                listService.UpdateListAsync(new MemoList { Id = model.Id.Value, Description = model.Description, Title = model.Title }, AccountModel.GetInstace().Session).Wait();
            }
            return List();
        }

        [Route("/createlist")]
        public IActionResult CreateList()
        {
            return View("CreateListView");
        }

        [Route("/createlist")]
        [HttpPost]
        public IActionResult CreateList(ListModel model)
        {
            if (model.Title != null && model.Description != null)
            {
                listService.CreateListAsync(new MemoList { Description = model.Description, Title = model.Title }, AccountModel.GetInstace().Session).Wait();
            }
            return List();
        }

        [Route("/deletelist")]
        public IActionResult DeleteList(ListModel model)
        {
            if (model.Id != null)
            {
                listService.DeleteListAsync(new MemoList { Id = model.Id.Value }, AccountModel.GetInstace().Session).Wait();
            }
            return List();
        }


        [Route("/logout")]
        public IActionResult Logout()
        {
            AccountModel.NullOut();
            return View("Index");
        }


        [Route("/home")]
        public IActionResult Home()
        {
            House[] list = houseService.GetAllHouseAsync(AccountModel.GetInstace().Session).Result;
            List<HouseModel> lists = new List<HouseModel>();
            foreach (var item in list)
            {
                lists.Add(new HouseModel { City = item.Address.City, DoorNo = item.Address.DoorNo, Floor = item.Address.FloorNo, HouseNo = item.Address.HouseNo, Id = item.Id, InviteCode = item.InviteCode, Name = item.Name, Street = item.Address.Street, ZipCode = item.Address.ZipCode });
            }
            ViewBag.list = lists;
            return View("HomeView");
        }


        [Route("/createhouse")]
        public IActionResult CreateHouse()
        {
            return View("CreateHouseView");
        }

        [Route("/createhouse")]
        [HttpPost]
        public IActionResult CreateHouse(HouseModel model)
        {
            houseService.CreateHouseAsync(new House { Name = model.Name, Address = new Address { City = model.City, DoorNo = model.DoorNo, FloorNo = model.Floor, HouseNo = model.HouseNo, Street = model.Street, ZipCode = model.ZipCode } }, AccountModel.GetInstace().Session).Wait();
            return Home();
        }


        [Route("/joinhouse")]
        public IActionResult JoinHouse()
        {
            return View("JoinHouseView");
        }


        [Route("/joinhouse")]
        [HttpPost]
        public IActionResult JoinHouse(HouseModel model)
        {
            houseService.JoinHouseAsync(model.InviteCode, AccountModel.GetInstace().Session).Wait();
            return Home();
        }

        [Route("/leavehouse")]
        public IActionResult LeaveHouse(HouseModel house)
        {
            houseService.LeaveHouseAsync(new House { Id = house.Id }, AccountModel.GetInstace().Session).Wait();
            return Home();
        }

        [Route("/chat")]
        public IActionResult Chat(HouseModel model)
        {
            ChatServiceReference.ChatMessage[] messages = chatService.GetChatMessagesAsync(model.Id).Result;
            List<ChatModel> chat = new List<ChatModel>();
            foreach (var item in messages)
            {
                chat.Add(new ChatModel { Id = item.Id, Author = item.Sender.UserName, HouseId = model.Id, Message = item.Message, SendDate = item.SendDate });
            }
            ViewBag.houseid = model.Id;
            ViewBag.list = chat;
            return View("ChatView");
        }

        [Route("/chat")]
        [HttpPost]
        public IActionResult SendChat(ChatModel model)
        {
            if (model.Message != null && !model.Message.Equals(string.Empty))
            {
                chatService.SendMessageAsync(new ChatServiceReference.ChatMessage { Message = model.Message, SendDate = DateTime.Now }, model.HouseId, AccountModel.GetInstace().Session).Wait();
            }
            return Chat(new HouseModel { Id = model.HouseId });
        }

        [Route("/chore")]
        public IActionResult Chore(HouseModel model)
        {
            ChoreServiceRefence.Chore[] chores = choreService.GetChoresForHouseAsync(model.Id).Result;
            List<ChoreModel> chore = new List<ChoreModel>();
            foreach (var item in chores)
            {
                string username;
                if (item.Person == null)
                {
                    username = null;
                }
                else
                {
                    username = item.Person.UserName;
                }
                chore.Add(new ChoreModel { Id = item.Id, EndDate = item.DueDate, HouseId = model.Id, Name = item.Description, Person = username, Status = (ChoreModel.StatusEnum)item.Status });
            }
            ViewBag.houseid = model.Id;
            ViewBag.list = chore;
            return View("ChoreView");
        }

        [Route("/createchore")]
        public IActionResult CreateChore(HouseModel model)
        {
            ViewBag.houseid = model.Id;
            return View("CreateChoreView");
        }

        [Route("/createchore")]
        [HttpPost]
        public IActionResult CreateChore(ChoreModel model)
        {
            if (model.EndDate != null && model.Name != null)
            {
                choreService.CreateChoreAsync(new ChoreServiceRefence.Chore { Description = model.Name, DueDate = model.EndDate }, model.HouseId).Wait();
            }
            return Chore(new HouseModel { Id = model.HouseId });
        }

        [Route("/joinchore")]
        public IActionResult JoinChore(ChoreModel model)
        {
            choreService.JoinChoreAsync(new ChoreServiceRefence.Chore { Id = model.Id }, AccountModel.GetInstace().Session).Wait();
            return Chore(new HouseModel { Id = model.HouseId });
        }

        [Route("/editchore")]
        public IActionResult EditChore(ChoreModel model)
        {
            ViewBag.houseid = model.Id;
            return View("EditChoreView", model);
        }

        [Route("/editchore")]
        [HttpPost]
        public IActionResult EditChoreEdit(ChoreModel model)
        {
            choreService.UpdateStatusAsync(new ChoreServiceRefence.Chore { Id = model.Id, Status = (byte)model.Status }, AccountModel.GetInstace().Session).Wait();
            return Chore(new HouseModel { Id = model.HouseId });
        }

        public static byte[] GenerateHash(byte[] plainText)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            return algorithm.ComputeHash(plainText);
        }
    }
}