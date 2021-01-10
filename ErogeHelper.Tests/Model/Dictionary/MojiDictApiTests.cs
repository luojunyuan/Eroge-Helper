﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErogeHelper.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErogeHelper.Model.Dictionary.Tests
{
    [TestClass()]
    public class MojiDictApiTests
    {
        [TestMethod()]
        public async Task RequestAsyncTest()
        {
            var apiInstance = new MojiDictApi();

            string queryWord = "君の名前";

            // result fetchResp.result.word.spell
            var result = await apiInstance.RequestAsync(queryWord).ConfigureAwait(false);

            Assert.AreEqual(result, "君");
        }
    }
}