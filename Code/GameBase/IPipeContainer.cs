using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.GameBaseEngine
{
    public interface IPipeContainer
    {
        int NoOfPipes { get; }
        void Configure();
    }
}
