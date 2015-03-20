using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace IdeaSoftware.Utils.Linq.Tests
{
    [TestFixture]
    public class EnumerationsShould
    {
        private readonly List<string> _someList = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

        [Test]
        public void CallDelegateCorrectAmountOfTimes_OneEachWithIndex()
        {
            var count = 0;
            _someList.Each((str, i) =>
            {
                count++;
            });
            count.Should().Be(_someList.Count);
        }
        [Test]
        public void ProvideCorrectIndex_OneEachWithIndex()
        {
            var index = 0;
            _someList.Each((str, i) =>
            {
                i.Should().Be(index);
                index++;
            });
        }




        [Test]
        public void CallDelegateCorrectAmountOfTimes_OneEachWithMeta()
        {
            var count = 0;
            _someList.Each(meta =>
            {
                count++;
            });
            count.Should().Be(_someList.Count);
        }
        [Test]
        public void ProvideCorrectIndex_OneEachWithMeta()
        {
            var index = 0;
            _someList.Each(meta =>
            {
                meta.Index.Should().Be(index);
                index++;
            });
        }
        [Test]
        public void IndicateFirstItemCorrectly_OneEachWithMeta()
        {
            _someList.Each(meta =>
            {
                if (meta.Index == 0)
                    meta.IsFirst.Should().BeTrue();
                else
                    meta.IsFirst.Should().BeFalse();
            });
        }
        [Test]
        public void IndicateLasItemCorrectly_OneEachWithMeta()
        {
            _someList.Each(meta =>
            {
                if (meta.Index == _someList.Count - 1)
                    meta.IsLast.Should().BeTrue();
                else
                    meta.IsLast.Should().BeFalse();
            });
        }

    }
}
