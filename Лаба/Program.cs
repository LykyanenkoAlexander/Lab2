using System;
using System.Numerics;
using System.Collections.Generic;
using Лаба;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;



struct DataItem
    {
        public Vector2 Vect2 { get; set; }
        public Complex Compl { get; set; }

        public DataItem(float x, float y)
        {
            Vect2 = new Vector2(x, y);
            Compl = new Complex(x, y);
        }

        public override string ToString()
        { return Vect2 + " , " + Compl; }

        public string ToString(string format)
        {
            string res = Vect2.ToString();
            res = res + " : " + Compl.ToString(format) + Math.Sqrt(Compl.Real*Compl.Real + Compl.Imaginary*Compl.Imaginary).ToString(format);
            return res;
        }

    }

    struct Grid1D
    {
        public float Step { get; set; }
        public int Node { get; set; }

        public Grid1D(float a, int b)
        {
            Step = a;
            Node = b;
        }

        public float GetOXCoord(int ox_coord)
        {
            
            return ox_coord*Step;
        }

        public float GetOYCoord(int oy_coord)
        {

            return oy_coord*Step;
        }

    public override string ToString()
        { return "Step = " + Step + ", " + "Node = " + Node; }

        public string ToString(string format)
        {
            string res;
            res = "Step = " +  Step.ToString(format) + " ,Node = " + Node.ToString(format);
            return res;
        }

}

    abstract class V2Data : IEnumerable<DataItem>
{
        public string Indef { get; set; }
        public double Freq { get; set; }

        public V2Data(string a, double b)
        {
            Indef = a;
            Freq = b;
        }

        public abstract Complex[] NearAverage(float eps);

        public abstract string ToLongString();

        public override string ToString()
        { return "V2Data: " + Indef + "," + Freq; }

        public abstract string ToLongString(string format);

        public abstract IEnumerator<DataItem> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

}

   

class Res
{
    static void Main()
    {
        try
        {
            //file data      
            V2DataCollection Lab_2_Data_Coll = new V2DataCollection("data_1.txt");
            Console.WriteLine(Lab_2_Data_Coll.ToLongString());

            //Linq testing
            V2MainCollection Lab_2_Main_Coll = new V2MainCollection();
            Lab_2_Main_Coll.AddDefaults();
            Lab_2_Main_Coll.ToLongString();

            Console.WriteLine("\nMiddle module value:");
            Console.WriteLine(Lab_2_Main_Coll.Mid_Value);
            Console.WriteLine("\nMaxFarAway values:");

            foreach (DataItem item in Lab_2_Main_Coll.Max_Far_Away)
            {
                Console.WriteLine(item.ToString());
            }

            /*Console.WriteLine("\nMoreThenOne values:");
            foreach (Vector2 item in Lab_2_Main_Coll.More_then_one)
            {
                Console.WriteLine(item.ToString("f5"));
            }
            */

        }
        catch (Exception e) 
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
    }
}
