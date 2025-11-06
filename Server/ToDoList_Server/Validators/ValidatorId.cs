using ToDoList_Server.Exceptions;
using ToDoList_Server.Interfaces;

namespace ToDoList_Server.Validators
{
    public class ValidatorId : IValidatorId
    {
        public void ValidateId(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id value should be greater than 0.");
            }
        }
    }
}
