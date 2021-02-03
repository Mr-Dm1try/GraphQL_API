using GraphQL_API.DatabaseHelper;

using NUnit.Framework;

using System.Collections.Generic;

namespace GraphQL_API.Test.DatabaseHelperTests
{
    public class DeviceAdapterTest
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
                { 1, 79992222221},
                { 3, 79992222222},
                { 4, 79991111111},
                { 5, 79991111112},
                { 6, 79993333331},
            };

            var actual = Repository.deviceAdapter.GetNumbers(ids);
            actual.Wait();

            Assert.IsTrue(TestHelper.CompareIdNumberDictionary(expected, (IDictionary<int, long>)actual.Result));
        }

        [Test]
        public void GetTariffTest()
        {
            var ids = new List<int> { 1, 3, 4, 5, 6 };
            var nums = new List<long>
            {
                79992222221,
                79992222222,
                79991111111,
                79991111112,
                79993333331
            };
            var expTP = new List<string>
            {
                "Абонент2",
                "Абонент2",
                "Абонент1",
                "Абонент1",
                "Абонент3"
            };

            var tpByIds = Repository.deviceAdapter.GetTariffsByIds(ids);
            var tpByNums = Repository.deviceAdapter.GetTariffsByNums(nums);
            tpByIds.Wait();
            tpByNums.Wait();

            for (int i = 0; i < ids.Count; i++)
                Assert.IsTrue(tpByNums.Result[nums[i]] == expTP[i]
                    && tpByIds.Result[ids[i]] == expTP[i]);
        }

        [Test]
        public void GetImsisTest()
        {
            var ids = new List<int> { 1, 3, 4, 5, 6 };
            var nums = new List<long>
            {
                79992222221,
                79992222222,
                79991111111,
                79991111112,
                79993333331
            };
            var expImsis = new List<long>
            {
                222221,
                222222,
                111111,
                111112,
                333331
            };

            var imsiByIds = Repository.deviceAdapter.GetImsisByIds(ids);
            var imsiByNums = Repository.deviceAdapter.GetImsisByNums(nums);
            imsiByIds.Wait();
            imsiByNums.Wait();

            for (int i = 0; i < ids.Count; i++)
                Assert.IsTrue(imsiByNums.Result[nums[i]] == expImsis[i]
                    && imsiByIds.Result[ids[i]] == expImsis[i]);
        }
    }
}
