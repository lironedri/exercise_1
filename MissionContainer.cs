using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double func(double x);

    public class FunctionsContainer
    {
        private Dictionary<string, func> calculateFunction;

        public FunctionsContainer()
        {
            calculateFunction = new Dictionary<string, func>();
        }

        //Properties:
        public int Count
        {
            get
            {
                return calculateFunction.Count;
            }
        }

        public func this[string name]
        {
            get
            {
                //check if the dictionary contains the given name
                if (calculateFunction.ContainsKey(name))
                {
                    return calculateFunction[name];
                }
                else
                {
                    //if doesn't exist, add the string name and calculate x val. Then returns them. 
                    calculateFunction.Add(name, (double x) => { return x; });
                    return (double x) => { return x; };
                }
            }

            set
            {
                //Again, chack if the given name exist in the dictionary, if not - add it with the set value
                //and if exist - set the value.
                if (!calculateFunction.ContainsKey(name))
                {
                    calculateFunction.Add(name, value);
                }
                else
                {
                    calculateFunction[name] = value;
                }
            }
        }

        public List<string> getAllMissions()
        {
            List<string> functionList = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                functionList.Add(calculateFunction.Keys.ElementAt(i));
            }
            return functionList;
        }
    }
}
