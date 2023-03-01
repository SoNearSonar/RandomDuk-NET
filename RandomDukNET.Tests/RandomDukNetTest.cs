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
        public void GetRandomImage_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetRandomImage().Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
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
        public void GetImage_ValidIDJpg_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetDuckImageJpegById(1).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetImage_ValidIDGif_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetDuckImageGifById(1).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetImage_InvalidID_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetDuckImageJpegById(-1).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetHttpImage_ValidStatusCode_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetHttpDuckImage(200).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetHttpImage_InalidStatusCode_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetHttpDuckImage(1).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetHttpImage_ValidStatusCodeButNotOnAPI_ReturnsByteImage()
        {
            RandomDukManager manager = new RandomDukManager();
            byte[] result = manager.GetHttpDuckImage(203).Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length != 0);
        }

        [TestMethod]
        public void GetImageList_ReturnsList()
        {
            RandomDukManager manager = new RandomDukManager();
            DukList result = manager.GetImageList().Result;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ImageFilenames.Count != 0);
            Assert.IsTrue(result.GifFilenames.Count != 0);
            Assert.IsTrue(result.HttpDuckFilenames.Count != 0);
            Assert.IsTrue(result.ImageCount != 0);
            Assert.IsTrue(result.GifCount != 0);
        }
    }
}