namespace Aplikacja
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;
        public EmployeeBase(string name, string surname, string dateOfBirth, string sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
        }
        public string Name { get; private set; } 

        public string Surname { get; private set; }

        public string DateOfBirth { get; private set; } 

        public string Sex { get; private set; }

        public void AddGrade(double grade) 
        {
            this.AddGrade((float)grade);
        }

        public abstract void AddGrade(float grade);

        public void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                AddGrade(result);
            }
            else
            {
                if (grade.Length == 1) AddGrade(grade[0]);
                else throw new Exception("BŁĄD [A..F]/[1..50]");
            }
        }

        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'a':
                case 'A':
                    {
                        AddGrade(50);
                        break;
                    }
                case 'b':
                case 'B':
                    {
                        AddGrade(40);
                        break;
                    }
                case 'c':
                case 'C':
                    {
                        AddGrade(30);
                        break;
                    }
                case 'd':
                case 'D':
                    {
                        AddGrade(20);
                        break;
                    }
                case 'e':
                case 'E':
                    {
                        AddGrade(10);
                        break;
                    }
                case 'f':
                case 'F':
                    {
                        AddGrade(0);
                        break;
                    }
                default:
                    {
                        throw new Exception("BŁĄD [A..F]/[a..f]");
                    }
            }
        }

        public abstract Statistics GetStatistics(); 
    }
}