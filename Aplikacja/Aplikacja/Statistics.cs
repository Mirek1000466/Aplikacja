using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public float Sum {  get; private set; }
        public float Count { get; private set; }
        public char AverageLetter 
        {
            get 
            {
                switch (this.Average) 
                {
                    case var average when average >= 41:
                        return 'A';
                    case var average when average >= 31:
                        return 'B';
                    case var average when average >= 21:
                        return 'C';
                    case var average when average >= 21:
                        return 'D';
                    case var average when average >= 11:
                        return 'E';
                    default: return 'F';
                }
                return AverageLetter; 
            }
        }
        public Statistics() 
        {
            this.Min = float.MaxValue;
            this.Max = float.MinValue;
            this.Count = 0;
            this.Sum = 0;

        }
        public void AddGrade(float grade) 
        {
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);
            this.Count++;
            this.Sum += grade;
        }
    }
}
