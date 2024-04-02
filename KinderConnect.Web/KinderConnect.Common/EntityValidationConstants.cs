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

            public const int AgeMin = 1;
            public const int AgeMax = 6;
        }
        public static class Classroom
        {
            public const int NameMinLenght = 1;
            public const int NameMaxLenght = 20;

            public const int InfoMinLenght = 20;
            public const int InfoMaxLenght = 3000;

            public const int MinimumAgeMinLenght = 0;
            public const int MinimumAgeMaxLenght = 3;

            public const int MaximumAgeAgeMinLenght = 3;
            public const int MaximumAgeAgeMaxLenght = 6;
        }
        public static class Qualification
        {
            public const int NameMaxLenght = 120;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 500;
        }
        public static class Activity
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;

            public const int DesctiptionMinLength = 5;
            public const int DescriptionMaxLength = 50;
        }
        public static class BlogPost
        {
            public const int TitleMaxLength = 60;
            public const int TitleMinLength = 5;

            public const int ContentMaxLength = 3500;
            public const int ContentMinLength = 700;

            public const int AuthorMaxLength = 40;
            public const int AuthorMinLength = 2;
        }
        public static class Teacher
        {
            public const int SummaryMinLength = 15;
            public const int SummaryMaxLength = 500;
        }
    }
}
