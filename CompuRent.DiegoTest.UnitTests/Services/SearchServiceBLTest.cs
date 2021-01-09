namespace CompuRent.DiegoTest.UnitTests.Services
{
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// SearchS ervice BL Test
    /// </summary>
    [TestClass]
    public class SearchServiceBLTest
    {
        /// <summary>
        /// Gets the song empty.
        /// </summary>
        [TestMethod]
        public void GetSongEmpty()
        {
            var searchService = new Mock<ISearchServiceBL>();
            searchService.Setup(x => x.FindBySong("No Exists")).Returns(new List<SongSetEntity>().AsQueryable());
            Assert.IsInstanceOfType(searchService.Object, typeof(IQueryable<SongSetEntity>));
        }
    }
}
