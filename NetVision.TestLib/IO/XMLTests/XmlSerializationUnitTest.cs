using NetVision.Infrastructure.DataSerializer;
using NetVision.TestLib.TestModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.TestLib.IO.XMLTests
{
    [TestFixture]
    public class XmlSerializationUnitTest
    {
        [Test]
        public void ObjectIsSerialized_Test()
        {
            var model = new XmlExampleModel() { Id = 1, Price = 24.95M, Title = "Pride and Prejudice" };
            var serializer = new XmlSerializationHelper<XmlExampleModel>();
            var actual = serializer.SerializeData(model, "D:\\myFile.xml");
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void ObjectDeserialized_Test()
        {
            var deserializer = new XmlSerializationHelper<XmlExampleModel>();
            var model = deserializer.DeserializeData("D:\\myFile.xml");

            Assert.NotNull(model);
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Pride and Prejudice", model.Title);
            Assert.AreEqual(24.95, model.Price);
        }

        [Test]
        public void ValidationReturnsTrueForValidModel_Test()
        {
            var model = new XmlExampleModel() { Id = 2, Price = 13.80M, Currency = "USD", Title = "Symfonia C++" };
            var serializer = new XmlSerializationHelper<XmlExampleModel>();
            var res = serializer.ValidateData(model);

            Assert.IsTrue(res);
        }
    }
}
