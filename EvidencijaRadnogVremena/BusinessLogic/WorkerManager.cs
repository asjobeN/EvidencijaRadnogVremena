using EvidencijaRadnogVremena.Controllers;
using EvidencijaRadnogVremena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaRadnogVremena.BusinessLogic
{
    public class RadnikManager
    {
        public static Result<string> RadnikCheckIn(HomeController.UserViewModel model)
        {
            Result<string> res = new Result<string>();
            using (var context = new ApplicationDbContext())
            {
                BusinessAction lastAction = context.BusinessActions.AsEnumerable().LastOrDefault(x => x.RadnikId == model.RadnikId
                                                                                    && x.Date.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
                if (lastAction == null)
                {
                    context.BusinessActions.Add(new BusinessAction()
                    {
                        RadnikId = model.RadnikId,
                        Date = DateTime.Now,
                        TipRada = Enums.TipRadaEnum.Radi,
                        LocalMachine = model.LocalMachine
                    });
                    context.SaveChanges();
                    res.Success = true;
                }
                else
                {
                    res.Message = Resource.alreadyCheckedIn;
                }
            }
            return res;
        }

        internal static Result<string> GoToBrake(HomeController.UserViewModel model)
        {
            Result<string> res = new Result<string>();
            using (var context = new ApplicationDbContext())
            {
                BusinessAction lastAction = context.BusinessActions.AsEnumerable().LastOrDefault(x => x.RadnikId == model.RadnikId
                                                                                    && x.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
                if (lastAction != null && lastAction.TipRada == Enums.TipRadaEnum.Radi)
                {
                    context.BusinessActions.Add(new BusinessAction()
                    {
                        RadnikId = model.RadnikId,
                        Date = DateTime.Now,
                        TipRada = Enums.TipRadaEnum.Pauza,
                        LocalMachine = model.LocalMachine
                    });
                    context.SaveChanges();
                    res.Success = true;
                }
                if (lastAction.TipRada == Enums.TipRadaEnum.Pauza)
                    res.Message = Resource.alreadyOnBrake;
            }
            return res;
        }

        internal static Result<string> RadnikCheckOut(HomeController.UserViewModel model)
        {
            Result<string> res = new Result<string>();
            using (var context = new ApplicationDbContext())
            {
                BusinessAction lastActionWorking = context.BusinessActions.AsEnumerable().LastOrDefault(x => x.RadnikId == model.RadnikId
                                                                                    && x.Date.Date.ToShortDateString() == DateTime.Now.ToShortDateString()
                                                                                    && x.TipRada == Enums.TipRadaEnum.Radi);
                BusinessAction lastAction = context.BusinessActions.AsEnumerable().LastOrDefault(x => x.RadnikId == model.RadnikId
                                                                                    && x.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
                if (lastActionWorking != null && lastAction.TipRada != Enums.TipRadaEnum.NeRadi)
                {
                    context.BusinessActions.Add(new BusinessAction()
                    {
                        RadnikId = model.RadnikId,
                        Date = DateTime.Now,
                        TipRada = Enums.TipRadaEnum.NeRadi,
                        LocalMachine = model.LocalMachine
                    });
                    context.SaveChanges();
                    res.Success = true;
                }
            }
            return res;
        }

        internal static Result<string> BackFromBreak(HomeController.UserViewModel model)
        {
            Result<string> res = new Result<string>();
            using (var context = new ApplicationDbContext())
            {
                BusinessAction lastAction = context.BusinessActions.AsEnumerable().LastOrDefault(x => x.RadnikId == model.RadnikId
                                                                                    && x.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
                if (lastAction != null && lastAction.TipRada == Enums.TipRadaEnum.Pauza)
                {
                    context.BusinessActions.Add(new BusinessAction()
                    {
                        RadnikId = model.RadnikId,
                        Date = DateTime.Now,
                        TipRada = Enums.TipRadaEnum.Radi,
                        LocalMachine = model.LocalMachine
                    });
                    context.SaveChanges();
                    res.Success = true;
                }
            }
            return res;
        }
        internal static Result<string> CheckPassword(HomeController.UserViewModel model)
        {
            Result<string> res = new Result<string>() { Success = true };
            using (var context = new ApplicationDbContext())
            {
                var radnik = context.Workers.AsEnumerable().FirstOrDefault(x => x.RadnikId == model.RadnikId);
                if (radnik.Password != model.Password)
                {
                    res.Success = false;
                    res.Message = Resource.wrongPassword;
                    return res;
                }
                return res;
            }
        }

        //internal static Task CreateRegisteredWorker(ViewModel.RegisterViewModel model)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        context.Workers.Add(new Worker() { Username = model.Username, Password = model.Password, ConfirmPassword = model.Password, Email = model.Email });
        //        context.SaveChanges();
        //    }
        //    return Task.Factory.StartNew(() => {  });
        //}

        internal static Task CreateRegisteredWorker(ViewModel.RegisterViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Workers.Add(new Worker()
                {
                    Username = model.Username,
                    Password = model.Password,
                    ConfirmPassword = model.Password,
                    Uloga = Enums.UlogaEnum.Administrator,
                    ImePrezime = model.Username,
                    Email = model.Email
                });
                context.SaveChanges();
            }
            return Task.Factory.StartNew(() => { });
        }
    }
}