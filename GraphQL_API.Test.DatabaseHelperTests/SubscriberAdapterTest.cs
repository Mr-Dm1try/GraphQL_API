using GraphQL_API.DatabaseHelper;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_API.Test.DatabaseHelperTests
{
    public class SubscriberAdapterTest
    {
        [SetUp]
        public void Setup()
        {
            Repository.CreateSingletonForEachAdapter(null, "Server=localhost;Port=5432;User Id=postgres;Password=super123;Database=graphql;");
        }

        [Test]
        public void GetContractIdsTest()
        {
            var ids = new List<int> { 1, 2, 3, 4 };
            var expected = new Dictionary<int, List<int>>
            {
                {1, new List<int> { 1, 3 } },
                {2, new List<int> { 4, 5 } },
                {3, new List<int> { 6, 7 } },
                {4, new List<int> { 8, 9 } }
            };

            var contracts = Repository.subscriberAdapter.GetContractIds(ids);
            contracts.Wait();

            foreach (var cont in contracts.Result)            
                foreach (var exp in expected[cont.Key])
                    Assert.IsTrue(cont.Value.Contains(exp));            
        }

        [Test]
        public void IsPhysicalTest()
        {
            var ids = new List<int> { 1, 2, 3, 4 };
            var expected = new List<bool> { true, true, false, false };

            for (int i = 0; i < ids.Count; i++)
                Assert.AreEqual(Repository.subscriberAdapter.IsPhysical(ids[i]), expected[i]);
        }

        [Test]
        public void GetFullNamesTest()
        {
            var ids = new List<int> { 2, 3, 4 };
            var expected = new List<string>
            {
                "Иванов Иван Иванович",
                "Петров Петр Петрович",
                "Алексеев Алексей Алексеевич"
            };

            var names = Repository.subscriberAdapter.GetFullNames(ids);
            names.Wait();

            for (int i = 0; i < ids.Count; i++)
                Assert.AreEqual(expected[i], names.Result[ids[i]]);
        }
    }
}
