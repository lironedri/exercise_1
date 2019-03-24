using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public string name;
        private List<func> funcList;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type { get; set; } = "Composed";
        public event EventHandler<double> OnCalculate;


        //public string Type => throw new NotImplementedException();

        public ComposedMission(string strName)
        {
            this.name = strName;
            this.funcList = new List<func>();
        }

        public ComposedMission Add(func func)
        {
            funcList.Add(func);
            return this;
        }

        public double Calculate(double value)
        {
            double tempVal = value;
            foreach (var func in funcList)
            {
                tempVal = func(tempVal);
            }
            OnCalculate?.Invoke(this, tempVal);
            return tempVal;
        }
    }
}
