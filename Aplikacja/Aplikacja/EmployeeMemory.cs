namespace Aplikacja
{
    public class EmployeeMemory : EmployeeBase
    {
        public override event GradeAddedDelegate GradeAdded;

        private List<float> grades = new List<float>();   
        public EmployeeMemory(string name, string surname, string dateOfBirth, string sex)
            : base(name, surname, dateOfBirth, sex) { }

        public override void AddGrade(double grade) 
        {
            AddGrade((float)grade);
        }
        public override void AddGrade(float grade) 
        {
            if (grade >= 0 && grade <= 50) 
            {
                grades.Add(grade);
                if (GradeAdded != null) GradeAdded(this, new EventArgs());
            }
            else
            {
                throw new Exception("Podano błędną ocenę!");
            }
            
        }
        public override void AddGrade(string grade) 
        {
            if(float.TryParse(grade, out float redult)) 
            {
                AddGrade(redult);
            }
            else 
            {
                if (grade.Length == 1) AddGrade(grade[0]);
                else throw new Exception("BŁĄD [A..F]/[1..50]");
            }
        }
        public override void AddGrade(char grade) 
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
                        break;
                    }
            }
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
