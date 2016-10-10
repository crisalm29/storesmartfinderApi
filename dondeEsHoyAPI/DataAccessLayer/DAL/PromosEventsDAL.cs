﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Entities;

namespace DataAccessLayer.DAL
{
    public class PromosEventsDAL: IPromosEvents
    {

        public dynamic[] promosEventsToday()
        {
            dynamic[] result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    promos_events[] promEve = DBContext.promos_events.Where(pe => pe.start_date.Date.CompareTo(DateTime.Today.Date)==0).ToArray();  //pe => pe.start_date.Date == DateTime.Today.Date
                    if (promEve != null) {
                         result = new dynamic[promEve.Length];
                        for (int i=0;i< promEve.Length;i++) {

                            var obj = new { promEve[i].id, promEve[i].name, promEve[i].start_date, promEve[i].due_date, promEve[i].description, promEve[i].establishment, promEve[i].imagebase64 };
                            result[i] = obj;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }


        public dynamic[] promosEventsThisMoth()
        {
            dynamic[] result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    promos_events[] promEve = DBContext.promos_events.Where(pe => pe.start_date.Month == DateTime.Now.Month && pe.start_date.Year == DateTime.Now.Year).ToArray(); 
                    if (promEve != null)
                    {
                        result = new dynamic[promEve.Length];
                        for (int i = 0; i < promEve.Length; i++)
                        {

                            var obj = new { promEve[i].id, promEve[i].name, promEve[i].start_date, promEve[i].due_date, promEve[i].description, promEve[i].establishment, promEve[i].imagebase64 };
                            result[i] = obj;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }


        public dynamic[] promosEventsByEstablishment(int establishment)
        {
            dynamic[] result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    promos_events[] promEve = DBContext.promos_events.Where(pe => pe.establishment == establishment).ToArray();  
                    if (promEve != null)
                    {
                        result = new dynamic[promEve.Length];
                        for (int i = 0; i < promEve.Length; i++)
                        {

                            var obj = new { promEve[i].id, promEve[i].name, promEve[i].start_date, promEve[i].due_date, promEve[i].description, promEve[i].establishment, promEve[i].imagebase64 };
                            result[i] = obj;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public dynamic[] promosEventsThisWeek()
        {
            /* dynamic[] result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    promos_events[] promEve = DBContext.promos_events.Where(pe => pe.start_date.Date.CompareTo(DateTime.Today.Date)==0).ToArray();  //pe => pe.start_date.Date == DateTime.Today.Date
                    if (promEve != null) {
                         result = new dynamic[promEve.Length];
                        for (int i=0;i< promEve.Length;i++) {

                            var obj = new { promEve[i].id, promEve[i].name, promEve[i].start_date, promEve[i].due_date, promEve[i].description, promEve[i].establishment, promEve[i].imagebase64 };
                            result[i] = obj;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;*/
            throw new NotImplementedException();
        }
    }
}