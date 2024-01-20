//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using TAICodingExercise.DTO;

namespace TAICodingExercise
{
    public class InsuredProcessor
    {
        public List<Insured> FilterInsuredList(List<Insured> insuredList, decimal riskThreshold)
        {
            return insuredList.Where(x => x.RiskAmount > riskThreshold).OrderByDescending(x => x.RiskAmount).ToList();
        }
    }
}
