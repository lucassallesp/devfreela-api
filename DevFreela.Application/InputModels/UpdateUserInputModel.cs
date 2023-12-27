using System;

namespace DevFreela.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public UpdateUserInputModel(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        
    }
}
