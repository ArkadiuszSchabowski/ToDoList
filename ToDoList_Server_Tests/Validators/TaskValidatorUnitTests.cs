#nullable disable

using FluentAssertions;
using ToDoList_Server.Exceptions;
using ToDoList_Server.Models;
using ToDoList_Server.Validators;

namespace ToDoList_Server_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class TaskValidatorUnitTests
    {
        [Fact]
        public void ValidateTask_WhenDtoIsNull_ThrowsBadRequestException()
        {
            var taskValidator = new TaskValidator();
            AddTaskDto dto = null;

            var action = () => taskValidator.ValidateTask(dto);


            action.Should().Throw<BadRequestException>().WithMessage("Task is required.");
        }

        [Fact]
        public void ValidateTask_WhenTitleIsNullOrWhitespace_ThrowsBadRequestException()
        {
            var taskValidator = new TaskValidator();
            var dto = new AddTaskDto { Title = " " };

            var action = () => taskValidator.ValidateTask(dto);

            action.Should().Throw<BadRequestException>().WithMessage("Title is required.");
        }

        [Fact]
        public void ValidateTask_WhenTitleTooShort_ThrowsBadRequestException()
        {
            var taskValidator = new TaskValidator();
            var dto = new AddTaskDto { Title = "1234" };

            var action = () => taskValidator.ValidateTask(dto);

            action.Should().Throw<BadRequestException>().WithMessage("Please provide a title between 5 and 50 characters.");
        }

        [Fact]
        public void ValidateTask_WhenDescriptionTooShort_ThrowsBadRequestException()
        {
            var taskValidator = new TaskValidator();
            var dto = new AddTaskDto
            {
                Title = "Valid Title",
                Description = "Short"
            };

            var action = () => taskValidator.ValidateTask(dto);

            action.Should().Throw<BadRequestException>().WithMessage("Description (optional) must be between 10 and 200 characters.");
        }

        [Fact]
        public void ValidateTask_WhenValid_DoesNotThrow()
        {
            var taskValidator = new TaskValidator();
            var dto = new AddTaskDto
            {
                Title = "Valid Title",
                Description = "Valid description of correct length."
            };

            var action = () => taskValidator.ValidateTask(dto);

            action.Should().NotThrow();
        }
    }
}