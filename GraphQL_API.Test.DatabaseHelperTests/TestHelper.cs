using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL_API.Test.DatabaseHelperTests
{
    internal static class TestHelper
    {
        internal static bool CompareIdNumberDictionary(IDictionary<int, long> a, IDictionary<int, long> b)
        {
            if (a.Count != b.Count)
                return false;

            var flag = true;
            foreach (var row in a)
            {
                if (!flag)
                    break;

                if (!b.ContainsKey(row.Key))
                    flag = false;
                else if (b[row.Key] != row.Value)
                    flag = false;
            }
            return flag;
        }
    }
}
