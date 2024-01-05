using System;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public void ThreeSkillsExist_Executed_ReturnThreeSkillDto()
        {
            // Arrange
            var skills = new List<SkillDto>
            {
                new SkillDto{ Id = 1, Description = "NET" },
                new SkillDto{ Id = 2, Description = "Angular" },
                new SkillDto{ Id = 3, Description = "React" }
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(sr => sr.GetAll().Result).Returns(skills);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            // Act
            var skillsDto = getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken()).Result;

            // Assert
            Assert.NotNull(skillsDto);
            Assert.NotEmpty(skillsDto);
            Assert.Equal(skills.Count, skillsDto.Count);

            skillRepositoryMock.Verify(sr => sr.GetAll().Result, Times.Once);
        }
    }
}
