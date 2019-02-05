using System;
using System.Collections.Generic;
using System.Text;

namespace CygX1.TwoWay.GameBaseEngine
{
    public class PipelineObjectEventArgs
    {
        
        public readonly IPipelineTraveller PipelineTraveller;
        public PipelineObjectEventArgs(IPipelineTraveller traveller)
        {
            PipelineTraveller = traveller;
        }
    }
}
