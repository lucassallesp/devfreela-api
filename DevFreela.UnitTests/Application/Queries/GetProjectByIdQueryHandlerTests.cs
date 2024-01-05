using System;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public void ProjectExist_Executed_ReturnProjectProjectDetailsViewModel()
        {
            // // Arrange
            // var project = new Project("Nome de teste 1", "Descrição de teste 1", 1, 2, 10000);
            // var client = new User("Nome de teste 1", "teste@teste", DateTime.Now, "client", "password-hash");
            // var freelancer = new User("Nome de teste 2", "teste@teste", DateTime.Now, "freelancer", "password-hash");
            // project.Id = 1;

            // var projectRepositoryMock = new Mock<IProjectRepository>();
            // projectRepositoryMock.Setup(pr => pr.GetProjectById(project.Id).Result).Returns(
                
            // );

            // var getProjectByIdQuery = new GetProjectByIdQuery(project.Id);
            // var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // // Act
            // var projectDetailsViewModel = getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken()).Result;

            // // Assert
            // Assert.Equal(project.Id, projectDetailsViewModel.Id);
            // Assert.Equal(project.Title, projectDetailsViewModel.Title);
            // Assert.Equal(project.Description, projectDetailsViewModel.Description);
            // Assert.Equal(project.TotalCost, projectDetailsViewModel.TotalCost);

            // projectRepositoryMock.Verify(pr => pr.GetProjectById(project.Id).Result, Times.Once);
        }
    }
}
