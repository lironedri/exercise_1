using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private String name;
        private func calculateFunc;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type { get;  set; } = "Single";
        public event EventHandler<double> OnCalculate;

        public SingleMission(func func, string strName){
            this.calculateFunc = func;
            this.name = strName;
        }

        public double Calculate(double value)
        {
            double tempVal = calculateFunc(value);
            //check if there are an activate mission- invoke the events. 
            OnCalculate?.Invoke(this, tempVal);
            return tempVal;
        }

        

      
    }
}
