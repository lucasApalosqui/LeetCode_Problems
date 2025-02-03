using System;
using System.Globalization;


class WeighingMachine
{
    private double _weight;
    private double _tareAdjus = 5.0;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; private set; }
    public double Weight 
    {
        get { return _weight; }
        set 
        {
            if (value >= 0)
               _weight = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }

    public string DisplayWeight 
    {
        get
        {
            var format = new NumberFormatInfo() { NumberDecimalDigits = Precision };
            return $"{(_weight - _tareAdjus).ToString("f", format)} kg";
        }
    }

    public double TareAdjustment { get { return _tareAdjus; } set { _tareAdjus = value; } }
}
