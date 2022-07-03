using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NetVision.Infrastructure.Files
{
    public class FileService : IFileService
    {
        private readonly string startPath = @"";
        private readonly string text = "";

        /// <summary>
        /// Allows to open file and read his content.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns></returns>
        public async Task<string> LoadFromTxtFileAsync(string path)
        {
            string result = string.Empty;
            byte [] buffer; //buffer purposed for storing content bytes

            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var filePath = Path.Combine(startPath, path);

            using (var fo = File.OpenRead(filePath))
            {
                buffer = new byte[fo.Length];   //create new instance to byte array with fo filestream length
                await fo.ReadAsync(buffer, 0, buffer.Length);
                fo.Close();
            }

            result = Encoding.UTF8.GetString(buffer);
            await Task.CompletedTask;
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Async task allows to save file in .txt format.
        /// </summary>
        /// <param name="fpath">Path file.</param>
        /// <param name="text">Text to write into file.</param>
        /// <returns> 0 - if file was successfully saved otherwise -1.</returns>
        public async Task<int> SaveTxtFileAsync(string path, string text)
        {
            if (string.IsNullOrEmpty(path))
            {
                return -1;
            }

            var filePath = Path.Combine(startPath, path);
            byte[] writeBytes = Encoding.UTF8.GetBytes(text);

            using (var fs = File.Create(filePath))
            {
               await fs.WriteAsync(writeBytes);
            }

            return 1;   
        }

        public async Task SaveXmlFileAsync(string path, List<string> attributes)
        {
            XmlDocument xml_doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml_doc.CreateXmlDeclaration("1.0", "UTF-8", null); //create a new xml ver. 1.0, encoding UTF-8
            XmlElement root_element = xml_doc.DocumentElement;
            xml_doc.InsertBefore(xmlDeclaration, root_element);
            XmlElement main_attr_elem = xml_doc.CreateElement(string.Empty, "Attribute", string.Empty);
            await Task.CompletedTask;
        }
    }
}
