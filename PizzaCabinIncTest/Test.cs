using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using static PizzaCabinInc.Model.ScheduleModel;
using PizzaCabinInc.Controllers;
using System;
using System.Globalization;

namespace PizzaCabinIncTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestGetPossibleTimes_AllPojectionOk()
        {
            // TestData
            var testData =
                "{\"ScheduleResult\":{\"Schedules\":[{\"ContractTimeMinutes\":480,\"Date\":\"\\/Date(1450051200000+0000)\\/\",\"IsFullDayAbsence\":false,\"Name\":\"Daniel Billsus\",\"PersonId\":\"4fd900ad-2b33-469c-87ac-9b5e015b2564\",\"Projection\":[{\"Color\":\"#FFFF00\",\"Description\":\"Ok\",\"Start\":\"\\/Date(1450094400000+0000)\\/\",\"minutes\":50},{\"Color\":\"#1E90FF\",\"Description\":\"Ok\",\"Start\":\"\\/Date(1450097400000+0000)\\/\",\"minutes\":130},{\"Color\":\"#FF0000\",\"Description\":\"Ok\",\"Start\":\"\\/Date(1450105200000+0000)\\/\",\"minutes\":15}]}]}}";
            var dataObj = JObject.Parse(testData);
            var scheduleresponse = dataObj;
            //var scheduleresponse = new ScheduleResponse(dataObj);

            //Test
            var result = WebApiClient.GetPossibleTimes(scheduleresponse);

            //Assert
            Assert.AreEqual(DateTimeOffset.Parse("2015-12-14 13:00:00", CultureInfo.InvariantCulture), result.Item2.First().First());
            Assert.AreEqual(DateTimeOffset.Parse("2015-12-14 16:00:00", CultureInfo.InvariantCulture), result.Item2.First().Last());
            Assert.AreEqual(13, result.Item2.First().Count);
            //Assert.Pass();
        }

        [TestMethod]
        public void TestGetPossibleTimes_FirstPojectionNotOK()
        {
            //TestData
            var testData =
                "{\"ScheduleResult\":{\"Schedules\":[{\"ContractTimeMinutes\":480,\"Date\":\"\\/Date(1450051200000+0000)\\/\",\"IsFullDayAbsence\":false,\"Name\":\"Daniel Billsus\",\"PersonId\":\"4fd900ad-2b33-469c-87ac-9b5e015b2564\",\"Projection\":[{\"Color\":\"#FFFF00\",\"Description\":\"Lunch\",\"Start\":\"\\/Date(1450094400000+0000)\\/\",\"minutes\":60},{\"Color\":\"#1E90FF\",\"Description\":\"Ok\",\"Start\":\"\\/Date(1450098000000+0000)\\/\",\"minutes\":120},{\"Color\":\"#FF0000\",\"Description\":\"Ok\",\"Start\":\"\\/Date(1450105200000+0000)\\/\",\"minutes\":15}]}]}}";
            var dataObj = JObject.Parse(testData);
            var scheduleresponse = dataObj;
            //var scheduleresponse = new scheduleresponse(dataObj); // need to create a constructor in the  scheduleresponse class 

            // PreAssert testData: first Projection Not Ok = Lunch
            //Assert.AreEqual("Lunch", ScheduleResponse.ScheduleResult.Schedules[0].Projection[0].Description);

            //Test
            var result = WebApiClient.GetPossibleTimes(scheduleresponse);

            //Assert
            Assert.AreEqual(DateTimeOffset.Parse("2015-12-14 14:00:00", CultureInfo.InvariantCulture), result.Item2.First().First());
            Assert.AreEqual(DateTimeOffset.Parse("2015-12-14 16:00:00", CultureInfo.InvariantCulture), result.Item2.First().Last());
            Assert.AreEqual(9, result.Item2.First().Count);
            //Assert.Pass();
        }

    }
}
