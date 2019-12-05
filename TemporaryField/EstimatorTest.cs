using NUnit.Framework;
using System;
using System.Collections.Generic;
using TemporaryField;

namespace Tests
{
    public class EstimatorTest
    {
        [Test]
        public void Case1()
        {
            var estimator = new Estimator(new TimeSpan(0, 0, 10));
            var calculateEstimate = estimator.CalculateEstimate(new List<TimeSpan>
            {
                new TimeSpan(0, 0, 2),
                new TimeSpan(0, 0, 4),
                new TimeSpan(0, 0, 6),
            });
            Assert.AreEqual(8, calculateEstimate.Seconds);
        }

        [Test]
        public void Case2()
        {
            var estimator = new Estimator(new TimeSpan(0, 0, 10));
            var calculateEstimate = estimator.CalculateEstimate(new List<TimeSpan>
            {
                new TimeSpan(0, 0, 2),
                new TimeSpan(0, 0, 5),
                new TimeSpan(0, 0, 8),
            });
            Assert.AreEqual(123484691, calculateEstimate.Ticks);
        }

        [Test]
        public void EmptyInput_GetDefaultValue()
        {
            var estimator = new Estimator(new TimeSpan(0, 0, 10));
            var calculateEstimate = estimator.CalculateEstimate(new List<TimeSpan>());
            Assert.AreEqual(10, calculateEstimate.Seconds);
        }
    }
}