using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime dateThatFlightLeaves = new DateTime(2015, 3, 18);
		private readonly DateTime dateThatFlightReturns = new DateTime(2015, 3, 19);

        private readonly int miles = 100;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dateThatFlightLeaves, dateThatFlightReturns, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectMilesForAOneHundredMileFlight()
        {
            var target = new Flight(dateThatFlightLeaves, dateThatFlightReturns, miles);
            Assert.AreEqual(100, target.Miles);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForAOneDayFlight()
        {
            var target = new Flight(dateThatFlightLeaves, dateThatFlightReturns, miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForATwoDayFlight()
        {
            var target = new Flight(dateThatFlightLeaves, new DateTime(2015, 3, 20), miles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForAThreeDayFlight()
        {
            var target = new Flight(dateThatFlightLeaves, new DateTime(2015, 3, 21), miles);
            Assert.AreEqual(260, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(dateThatFlightLeaves, dateThatFlightReturns, -5);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(dateThatFlightLeaves, new DateTime(2015, 3, 1), miles);
        }
	}
}
