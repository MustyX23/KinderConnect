namespace KinderConnect.Common
{
    public static class EntityValidationConstants
    {
        public static class Child
        {
            public const int FirstNameMinLenght = 1;
            public const int FirstNameMaxLenght = 50;

            public const int LastNameMinLenght = 1;
            public const int LastNameMaxLenght = 50;

            public const int MedicalInfoMinLenght = 20;
            public const int MedicalInfoMaxLenght = 1000;

            public const int AllergiesMinLenght = 50;
            public const int AllergiesMaxLenght = 500;
        }
        public static class Classroom
        {
            public const int NameMinLenght = 1;
            public const int NameMaxLenght = 20;
        }
        public static class Qualification
        {
            public const int NameMaxLenght = 120;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 500;
        }
    }
}
