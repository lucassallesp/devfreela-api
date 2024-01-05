using System;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public void ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome de teste 1", "Descrição de teste 1", 1, 2, 10000),
                new Project("Nome de teste 2", "Descrição de teste 2", 1, 2, 10000),
                new Project("Nome de teste 3", "Descrição de teste 3", 1, 2, 10000),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllProjects().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);
            
            // Act
            var projectsViewModel = getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken()).Result;

            // Assert
            Assert.NotNull(projectsViewModel);
            Assert.NotEmpty(projectsViewModel);
            Assert.Equal(projects.Count, projectsViewModel.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllProjects().Result, Times.Once);
        }
    }
}
