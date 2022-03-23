using System.Collections.Generic;
using Moq;
using Xunit;
using SkSampleLibrary.Mocking;

namespace SkSampleLibrary.Tests.Mocking
{
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repository;

        public VideoServiceTests()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }
        
        [Fact]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();
            
            Assert.Contains("error", result.ToLower());
            //Assert.Throws<Expection>(() => _videoService.ReadVideoTitle());
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.Equal(result, "");
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video { Id = 1 },
                new Video { Id = 2 },
                new Video { Id = 3 },
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.Equal(result, "1,2,3");
        }
        
    }
}