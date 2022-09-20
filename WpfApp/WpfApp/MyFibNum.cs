using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp;

public class MyFibNum
{
    public List<ulong> FibNums;

    public MyFibNum()
    {
        FibNums = new List<ulong>();

        FibNums.Add(0);

        FibNums.Add(1);
    }

    public ulong CalculateNext()
    {
        ulong lastValue = FibNums[FibNums.Count - 1] + FibNums[FibNums.Count - 2];
        FibNums.Add(lastValue);

        return lastValue;
    }
}