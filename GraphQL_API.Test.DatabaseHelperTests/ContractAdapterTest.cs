using GraphQL_API.DatabaseHelper;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_API.Test.DatabaseHelperTests
{
    public class ContractAdapterTest
    {
        [SetUp]
        public void Setup()
        {
            Repository.CreateSingletonForEachAdapter(null, "Server=localhost;Port=5432;User Id=postgres;Password=super123;Database=graphql;");
        }

        [Test]
        public void GetNumbersTest()
        {
            var ids = new List<int> { 1, 2, 3, 4, 5, 6 };
            var expected = new Dictionary<int, long>
            {
                { 1, 111111111},
                { 3, 111111112},
                { 4, 222222221},
                { 5, 222222222},
                { 6, 333333331},
            };

            var actual = Repository.contractAdapter.GetNumbers(ids);
            actual.Wait();

            Assert.IsTrue(TestHelper.CompareIdNumberDictionary(expected, (IDictionary<int, long>)actual.Result));
        }

        [Test]
        public void GetAccountIdsTest()
        {
            var ids = new List<int> { 1, 3, 4, 5, 6 };
            var nums = new List<long> { 111111111, 111111112, 222222221, 222222222, 333333331 };           
            var expAccounts = new List<int> { 2, 3, 1, 4, 5 };

            var accByIds = Repository.contractAdapter.GetAccountIdsByIds(ids);
            var accByNums = Repository.contractAdapter.GetAccountIdsByNums(nums);
            accByIds.Wait();
            accByNums.Wait();

            for (int i = 0; i < ids.Count; i++)            
                Assert.IsTrue(accByIds.Result[ids[i]].Contains(expAccounts[i])
                    && accByNums.Result[nums[i]].Contains(expAccounts[i]));            
        }

        [Test]
        public void GetIdsTest()
        {
            var nums = new List<long> { 111111111, 111111112, 222222221, 222222222, 333333331 };
            var expectedIds = new List<int> { 1, 3, 4, 5, 6 };

            var actualIds = Repository.contractAdapter.GetIds(nums);
            actualIds.Wait();

            for (int i = 0; i < nums.Count; i++)
                Assert.AreEqual(expectedIds[i], actualIds.Result[nums[i]]);
        }
    }
}
