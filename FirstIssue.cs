using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static otusGlazevDELEGATE.Program;

namespace otusGlazevDELEGATE
{

    public static class FirstIssue
    {
        public static Func<object, float> My;

        public static void Work()
        {
            IEnumerable<CustomElement> f = new List<CustomElement>() { new CustomElement() { Value = 2},
                new CustomElement() { Value = 5}, new CustomElement() { Value = -42} };

            My += GetParameter;

            var max = f.GetMax(My);
        }

        public static float GetParameter<T>(T data) where T : class
        {
            if (data is CustomElement)
            {
                var val = data.GetType().GetProperties().First().GetValue(data);

                return float.Parse(val.ToString());
            }
            return 0.0f;
        }
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            if (e.Count() == 0)
            {
                return null;
            }

            T max = e.First();
            foreach (var item in e)
            {
                var res = getParameter.Invoke(item);
                if (getParameter.Invoke(max) < res)
                {
                    max = item;
                }
            }

            return max;
        }
        public class CustomElement
        {
            public int Value { get; set; }
        }
    }



  
}
