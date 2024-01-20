using CsvHelper.Configuration;

namespace TAICodingExercise.DTO
{
    public class InsuredReadMap : ClassMap<Insured>
    {
        public InsuredReadMap()
        {
            Map(m => m.ID);
            Map(m => m.FirstName);
            Map(m => m.LastName);
            Map(m => m.Gender);
            Map(m => m.DateOfBirth).TypeConverterOption.Format("yyyyMMdd");
            Map(m => m.RiskAmount).Ignore();
        }
    }
    public class InsuredWriteMap : ClassMap<Insured>
    {
        public InsuredWriteMap()
        {
            Map(m => m.ID);
            Map(m => m.FirstName);
            Map(m => m.LastName);
            Map(m => m.Gender);
            Map(m => m.DateOfBirth).TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.RiskAmount);
        }
    }
    public class PolicyReadMap: ClassMap<Policy>
    {
        public PolicyReadMap()
        {
            Map(m => m.PolicyNumber).Ignore();
            Map(m => m.FaceAmount);
            Map(m => m.CashValue);
        }
    }
}
