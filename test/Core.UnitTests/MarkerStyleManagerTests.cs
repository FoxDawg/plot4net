using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using FluentAssertions;

using Xunit;

namespace plot4net.Core.UnitTests
{
    [Trait("Category", "Unit")]
    public class MarkerStyleManagerTests
    {
        private readonly MarkerStyleManager unitUnderTest;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerStyleManagerTests" /> class.
        /// </summary>
        public MarkerStyleManagerTests()
        {
            this.unitUnderTest = new MarkerStyleManager();
        }

        [Fact]
        public void Wraps_Around_Colors()
        {
            //Arrange
            var expected = this.unitUnderTest.LineColors;
            var results = new List<Color>();

            //Act
            for (var i = 0; i <= expected.Count; i++)
            {
                results.Add(this.unitUnderTest.Next());
            }

            //Assert
            for (var i = 0; i < expected.Count; i++)
            {
                results[i].Should().BeEquivalentTo(expected[i]);
            }

            results.Last().Should().BeEquivalentTo(expected.First());
        }
    }
}