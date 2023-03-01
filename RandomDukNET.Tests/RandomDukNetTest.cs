using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDukNET.Models;

namespace RandomDukNET.Tests
{
    [TestClass]
    public class RandomDUKNetTest
    {
        [TestMethod]
        public void GetRandom_ReturnsRandom()
        {
            RandomDukManager manager = new RandomDukManager();
            Duk result = manager.GetRandom().Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void GetQuack_ReturnsRandom()
        {
            RandomDukManager manager = new RandomDukManager();
            Duk result = manager.GetQuack().Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.IsNotNull(result.Message);
        }

        [TestMethod]
        public void GetImage_ValidIDJpg_ReturnsByteJpegImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetDuckImageJpeg("1").Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetImage_ValidIDGif_ReturnsByteGifImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetDuckImageGif("1").Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetImage_InvalidID_DoesNotReturnImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetDuckImageJpeg("abc").Result;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetHttpImage_ValidStatusCode_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetHttpDuckImage("200").Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetHttpImage_InalidStatusCode_Returns404ByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetHttpDuckImage("1").Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }
    }
}