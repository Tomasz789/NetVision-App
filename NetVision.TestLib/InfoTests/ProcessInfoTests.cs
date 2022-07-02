using NetVision.DataCore.Model;
using NetVision.Infrastructure.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.TestLib.InfoTests
{
    [TestFixture]
    public class ProcessInfoTests
    {
        private IProcessInfoService _service;
        private IEnumerable<ProcessModel> _list;

        [SetUp]
        public void Init()
        {
            _service = new ProcessInfoService();
            _list = _service.GetProcesses();
        }

        [Test]
        public void TestIfProcessListIsNotNullOrEmpty()
        {
            var actual = _list;
            bool notEmpty = false;

            if (actual.Any())
            {
                notEmpty = true;
            }

            // Act
            Assert.IsNotNull(actual);
            Assert.IsTrue(notEmpty);
        }

        [Test]
        public void ListReturnsProcessWithGivenId_Test()
        {
            var actual = _service.SearchInIdRange(0, 4, _list);
            var firstElementId = actual.FirstOrDefault().Id;

            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.ToList().Count);
            Assert.AreEqual(0, firstElementId);
        }
    }
}
