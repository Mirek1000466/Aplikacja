namespace Aplikacja
{
    public class EmployeeMemory : EmployeeBase
    {
        public override event GradeAddedDelegate GradeAdded;

        private List<float> grades = new List<float>();   
        public EmployeeMemory(string name, string surname, string dateOfBirth, string sex)
            : base(name, surname, dateOfBirth, sex) { }

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
