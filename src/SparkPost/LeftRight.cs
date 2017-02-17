using System.Linq;
using System.Reflection;

namespace SparkPost
{
    public static class LeftRight
    {
        public static void SetValuesToMatch(object left, object right)
        {
#if NETSTANDARD1_6
            var leftProperties = left.GetType().GetRuntimeProperties();
            var rightProperties = left.GetType().GetRuntimeProperties();
#else
            var leftProperties = left.GetType().GetProperties();
            var rightProperties = left.GetType().GetProperties();
#endif
            foreach (var rightProperty in rightProperties)
            {
                try
                {
                    var leftProperty = leftProperties.FirstOrDefault(x => x.Name == rightProperty.Name);
                    leftProperty?.SetValue(left, rightProperty.GetValue(right));
                }
                catch
                {
                    // ignore
                }
            }
        }
    }
}