using Moq;
using MagazineStore.BL.Interfaces;
using MagazineStore.BL.Services;
using MagazineStore.DL.Interfaces;
using MagazineStore.Models.DTO;

namespace MagazineService.Tests
{
    public class MagazineBlServiceTests
    {
        private Mock<IMagazineService> _magazineServiceMock;
        private Mock<IAuthorRepository> _authorRepositoryMock;

        public MagazineBlServiceTests()
        {
            _magazineServiceMock = new Mock<IMagazineService>();
            _authorRepositoryMock = new Mock<IAuthorRepository>();
        }

        private List<Magazine> _magazines = new List<Magazine>
        {
            new Magazine()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Magazine 1",
                Year = 2021,
                Authors = ["Author 1", "Author 2"]
            },
            new Magazine()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Magazine 2",
                Year = 2022,
                Authors = ["Author 3", "Author 4"]
            }
        }; 

        private List<Author> _authors = new List<Author>
        {
            new Author()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Author 1"
            },
            new Author()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Author 2"
            },
            new Author()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Author 3"
            },
            new Author()
            {
                Id = "9badefdc-0714-4581-80ae-161cd0a5abbe",
                Name = "Author 4"
            }
        };

        [Fact]
        public void GetDetailedMagazines_Ok()
        {
            //setup
            var expectedCount = 2;

            _magazineServiceMock
                .Setup(x => x.GetAllMagazines())
                .Returns(_Magazines);
            _authorRepositoryMock.Setup(x => 
                    x.GetById(It.IsAny<string>()))
                .Returns((string id) =>
                    _authors.FirstOrDefault(x => x.Id == id));

            //inject
            var magazineBlService = new MagazineBlService(
                _magazineServiceMock.Object,
                _authorRepositoryMock.Object);

            //Act
            var result =
                magazineBlService.GetDetailedMagazines();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }

    }
}