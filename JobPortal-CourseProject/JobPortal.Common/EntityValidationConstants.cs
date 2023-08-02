namespace JobPortal.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 40;
        }

        public static class Job
        {
            public const int TitleMinLenght = 10;
            public const int TitleMaxLenght = 50;

            public const int DescriptionMinLenght = 50;
            public const int DescriptionMaxLenght = 500;

            public const int RequirementsMinLenght = 10;
            public const int RequirementsMaxLenght = 500;
        }

        public static class Employer
        {
            public const int CompanyNameMinLength = 2;
            public const int CompanyNameMaxLength = 50;

            public const int CompanyAddressMinLength = 2;
            public const int CompanyAddressMaxLength = 50;

            public const int PhoneNumberMinLenght = 7;
            public const int PhoneNumberMaxLenght = 15;
        }
        
        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 20;
            
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }
    }
}
