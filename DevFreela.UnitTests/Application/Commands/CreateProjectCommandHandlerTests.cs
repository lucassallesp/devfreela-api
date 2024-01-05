using System;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Título do projeto",
                Description = "Descrição do projeto",
                TotalCost = 10000,
                IdClient = 1,
                IdFreelancer = 2
            };
            
            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());
            
            // Assert
            Assert.True(id >= 0);

            projectRepositoryMock.Verify(pr => pr.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}
