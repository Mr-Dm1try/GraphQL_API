using GraphQL_API.DatabaseHelper;

using NUnit.Framework;

using System.Collections.Generic;

namespace GraphQL_API.Test.DatabaseHelperTests
{
    public class AccountAdapterTest
    {
        [SetUp]
        public void Setup()
        {
            Repository.CreateSingletonForEachAdapter(null, "Server=localhost;Port=5432;User Id=postgres;Password=super123;Database=graphql;");
        }

        [Test]
        public void GetNumbersTest()
        {
            var ids = new List<int> { 1, 2, 3, 24235 };
            var expected = new Dictionary<int, long>
            {
                { 1, 2221},
                { 2, 1111},
                { 3, 1112}
            };

            var actual = Repository.accountAdapter.GetNumbersByIds(ids);
            actual.Wait();

            Assert.IsTrue(TestHelper.CompareIdNumberDictionary(expected, (IDictionary<int, long>)actual.Result));
        }

        [Test]
        public void GetBalancesTest()
        {
            var ids = new List<int> { 1, 2, 3, 4 };
            var nums = new List<long> { 2221, 1111, 1112, 2222 };
            var expBalances = new List<decimal> { 1000, 500, 600, 300 };

            var balancesByIds = Repository.accountAdapter.GetBalancesByIds(ids);
            var balancesByNums = Repository.accountAdapter.GetBalancesByNums(nums);
            balancesByIds.Wait();
            balancesByNums.Wait();

            for (int i = 0; i < ids.Count; i++)            
                Assert.IsTrue(balancesByNums.Result[nums[i]] == expBalances[i]
                    && balancesByIds.Result[ids[i]] == expBalances[i]);            
        }

        [Test]
        public void GetContractNumsTest()
        {
            var ids = new List<int> { 1, 2, 3, 4 };
            var nums = new List<long> { 2221, 1111, 1112, 2222 };
            var expContracts = new List<long> { 222222221, 111111111, 111111112, 222222222 };

            var contByIds = Repository.accountAdapter.GetContractNumsByIds(ids);
            var contByNums = Repository.accountAdapter.GetContractNumsByNums(nums);
            contByIds.Wait();
            contByNums.Wait();

            for (int i = 0; i < ids.Count; i++)            
                Assert.IsTrue(contByIds.Result[ids[i]] == expContracts[i]
                    && contByNums.Result[nums[i]] == expContracts[i]);            
        }        
    }
}