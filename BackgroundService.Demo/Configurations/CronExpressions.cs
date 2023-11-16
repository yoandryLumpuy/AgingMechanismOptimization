using Cronos;

namespace BackgroundService.Demo.Configurations
{
    public class CronExpressions: Dictionary<string, CronExpression>
    {
        public CronExpressions(BackgroundServicesOptions backgroundServicesOptions)
        {
            foreach (var keyValuePair in backgroundServicesOptions)
            {
                Add(keyValuePair.Key, CronExpression.Parse(keyValuePair.Value, CronFormat.IncludeSeconds));
            }
        }
    }
}
