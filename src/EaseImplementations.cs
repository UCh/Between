using System;

namespace Between {
    internal static class QuadraticImpl {
        public static float In(float percent) {
            return (float)Math.Pow(percent, 2);
        }
    }

    internal static class CubicImpl {
        public static float In(float percent) {
            return (float)Math.Pow(percent, 3);
        }
    }

    internal static class QuarticImpl {
        public static float In(float percent) {
            return (float)Math.Pow(percent, 4);
        }
    }

    internal static class QuinticImpl {
        public static float In(float percent) {
            return (float)Math.Pow(percent, 5);
        }
    }

    internal static class SineImpl {
        public static float Out(float percent) {
            return (float)Math.Sin(percent * (Math.PI / 2));
        }
    }

    internal static class ExponentialImpl {
        public static float Out(float percent) {
            return (float)Math.Pow(2, 10 * (percent - 1));
        }
    }

    internal static class CircImpl {
        public static float Out(float percent) {
            return (float)Math.Sqrt(1 - Math.Pow(percent - 1, 2));
        }
    }

    internal static class BackImpl {
        public static float In(float percent) {
            const float s = 1.70158f;
            return (float)Math.Pow(percent, 2) * ((s + 1) * percent - s);
        }
    }

    internal static class ElasticImpl {
        public static float Out(float percent) {
            return (float)(1 + Math.Pow(2, -10 * percent) * Math.Sin((percent - 0.075) * (2 * Math.PI) / 0.3));
        }
    }

    internal static class BounceImpl {
        public static float Out(float percent) {
            const float s = 7.5625f;
            const float p = 2.75f;

            if (percent < (1 / p))
            {
                return (float)(s * Math.Pow(percent, 2));
            }

            if (percent < (2 / p))
            {
                percent -= (1.5f / p);
                return (float)(s * Math.Pow(percent, 2) + .75);
            }

            if (percent < (2.5f / p))
            {
                percent -= (2.25f / p);
                return (float)(s * Math.Pow(percent, 2) + .9375);
            }

            percent -= (2.625f / p);
            return (float)(s * Math.Pow(percent, 2) + .984375);
        }
    }
}
