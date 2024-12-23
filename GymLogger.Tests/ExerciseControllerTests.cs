using AutoFixture;
using gymlogger.Controllers;
using gymlogger.Helpers;
using gymlogger.Interfaces;
using gymlogger.Models;
using gymlogger.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit.Abstractions;

namespace GymLogger.Tests
{
    public class ExerciseControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IExerciseRepository> _mockExerciseRepository;
        private readonly ExerciseController _controller;

        public ExerciseControllerTests()
        {
            _fixture = new Fixture();
            _mockExerciseRepository = new Mock<IExerciseRepository>();
            _controller = new ExerciseController(_mockExerciseRepository.Object);
        }

        [Fact]
        public void GetAll_Returns_All_Exercises()
        {
            // Arrange 
            var exercises = _fixture.CreateMany<Exercise>(3).ToList();
            _mockExerciseRepository.Setup(repo => repo.GetAllAsync(new GetExercisesQueryObject { Muscle = null })).ReturnsAsync(exercises);

            // Act 
            var response = _controller.GetAll(new GetExercisesQueryObject { Muscle = null });

            //Assert 
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var returnedExercises = Assert.IsAssignableFrom<IEnumerable<Exercise>>(okResult.Value);
            Assert.Equal(exercises.Count, returnedExercises.Count());
            Assert.True(exercises.SequenceEqual(returnedExercises)); // Check for value equality

        }
    }
}