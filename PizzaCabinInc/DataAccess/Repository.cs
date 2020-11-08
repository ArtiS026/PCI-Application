using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LiteDB;
using PizzaCabinInc.Model;

namespace PizzaCabinInc.DataAccess
{
    public class Repository
    {
        //Add Json data in MyData DB 
        public static void InsertScheduleResponse(ScheduleModel.ScheduleResponse JsonResult)
        {
            try
            {
                List<ScheduleModel.ScheduleResponse> schedule = new List<ScheduleModel.ScheduleResponse>();
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<ScheduleModel.ScheduleResponse>();
                    col.Insert(JsonResult);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        //get json data from MyData db to query
        public static List<ScheduleModel.ScheduleResponse> GetSchedulesResponse()
        {
            try
            {
                List<ScheduleModel.ScheduleResponse> scheduleResponses = new List<ScheduleModel.ScheduleResponse>();
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<ScheduleModel.ScheduleResponse>("ScheduleResult");
                    scheduleResponses = col.FindAll().ToList();

                }
                return scheduleResponses;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); ;
            }

        }
    }
}
