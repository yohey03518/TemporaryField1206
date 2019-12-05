using System;
using System.Collections.Generic;
using System.Linq;

namespace TemporaryField
{
    public class Estimator
    {
        private readonly TimeSpan _defaultEstimate;
        private IList<TimeSpan> _durations;
        private TimeSpan _average;
        private TimeSpan _standardDeviation;

        public Estimator(TimeSpan defaultEstimate)
        {
            _defaultEstimate = defaultEstimate;
        }

        public TimeSpan CalculateEstimate(
            IList<TimeSpan> durations)
        {
            if (durations == null)
                throw new ArgumentNullException(nameof(durations));

            if (durations.Count == 0)
                return _defaultEstimate;

            _durations = durations;
            CalculateAverage();
            CalculateStandardDeviation();

            var margin = TimeSpan.FromTicks(_standardDeviation.Ticks * 3);
            return _average + margin;
        }

        private void CalculateAverage()
        {
            _average =
                TimeSpan.FromTicks(
                    (long)_durations.Average(ts => ts.Ticks));
        }

        private void CalculateStandardDeviation()
        {
            var variance =
                _durations.Average(ts =>
                    Math.Pow(
                        (ts - _average).Ticks,
                        2));
            _standardDeviation =
                TimeSpan.FromTicks((long)Math.Sqrt(variance));
        }
    }
}