using NetVision.Infrastructure.Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.TestLib.IO.FileTest
{
    [TestFixture]
    public class FileUnitTests
    {
        private IFileService _service;

        /// <summary>
        /// Init a new FileService class.
        /// </summary>
        [SetUp]
        public void Init()
        {
            _service = new FileService();
        }

        [Test]
        public async Task FileServiceTestInvalidFilePath()
        {
            string path = string.Empty;
            var actual = await _service.SaveTxtFileAsync(path, string.Empty);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public async Task FileServiceTestSaveFileSuccsessfully()
        {
            string path = "D:\\file.txt";
            string text = "Text";

            var actual = await _service.SaveTxtFileAsync(path, text);
            Assert.AreEqual(1, actual);
        }

    }
}
