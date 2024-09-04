namespace Aplikacja
{
    public class EmployeeFile : EmployeeBase
    {
        public override event GradeAddedDelegate GradeAdded;

        public EmployeeFile(string name, string surname, string dateOfBirth, string sex, string fileName)
            : base(name, surname, dateOfBirth, sex)
        {
            this.FileName = fileName; 
        }
        public string FileName { get; private set; }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 50)
            {
                using (var writer = File.AppendText(this.FileName))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null) GradeAdded(this, new EventArgs());
                }
            }
            else throw new Exception("Podano błędną ocenę!");
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            if(File.Exists(FileName)) 
            {
                using (var reader = File.OpenText(FileName))
                {
                    var lineNumber = 4;
                    var line = "";
                    while (line != null)
                    {
                        if (lineNumber < 5)
                        {
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                        }
                        else if(line !="") statistics.AddGrade(float.Parse(line));
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        } 
    }
}
