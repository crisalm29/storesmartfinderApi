﻿using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.DAL
{
    public class UsersDAL : IUsersDAL
    {

        public bool login(string email, string password)
        {
            users result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    result = DBContext.users.Where(user => user.email == email && user.password == password).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result != null;
        }

        public void addNewUser(users user)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try {
                    DBContext.users.Add(user);
                    DBContext.SaveChanges();
                }catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public users userInfoById(int id)
        {
            users result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.users.Where(user => user.id == id).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public users userInfoByEmail(string email)
        {
            users result = null;
            using (var DBContext = new dondeeshoyEntities()) {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.users.Where(user => user.email == email).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public void modifyUser(users user)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    var entity = DBContext.users.Find(user.id);
                    DBContext.Entry(entity).CurrentValues.SetValues(user);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public void deleteUser(int id)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    users user = new users { id = id };
                    DBContext.users.Attach(user);
                    DBContext.users.Remove(user);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }
    }
}
