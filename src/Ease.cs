namespace Between {
    public delegate float EaseFunc(float percent);

    public interface IEase {
        float In(float percent);

        float Out(float percent);

        float InOut(float percent);
    }

    public static class Ease {
        public static readonly IEase Quad = Generic.CreateFromIn(QuadraticImpl.In);

        public static readonly IEase Cubic = Generic.CreateFromIn(CubicImpl.In);

        public static readonly IEase Quart = Generic.CreateFromIn(QuarticImpl.In);

        public static readonly IEase Quint = Generic.CreateFromIn(QuinticImpl.In);

        public static readonly IEase Sine = Generic.CreateFromOut(SineImpl.Out);

        public static readonly IEase Expo = Generic.CreateFromOut(ExponentialImpl.Out);

        public static readonly IEase Circ = Generic.CreateFromOut(CircImpl.Out);

        public static readonly IEase Back = Generic.CreateFromIn(BackImpl.In);

        public static readonly IEase Elastic = Generic.CreateFromOut(ElasticImpl.Out);

        public static readonly IEase Bounce = Generic.CreateFromOut(BounceImpl.Out);

        public static float Linear(float percent) {
            return percent;
        }

        public static class Generic {
            public static float Reverse(float percent, EaseFunc easeFunc) {
                return 1 - easeFunc(1 - percent);
            }

            public static float InOut(float percent, EaseFunc Out) {
                if (percent < 0.5)
                {
                    return Reverse(percent * 2, Out) / 2;
                }

                return (Out(percent * 2 - 1) / 2) + 0.5f;
            }

            public static IEase CreateFromIn(EaseFunc easeInFunc, EaseFunc easeInOutFunc = null) {
                return GenericEaseImpl.FromIn(easeInFunc, easeInOutFunc);
            }

            public static IEase CreateFromOut(EaseFunc easeOutFunc, EaseFunc easeInOutFunc = null) {
                return GenericEaseImpl.FromOut(easeOutFunc, easeInOutFunc);
            }

            public static IEase Create(EaseFunc easeInFunc, EaseFunc easeOutFunc, EaseFunc easeInOutFunc = null) {
                return GenericEaseImpl.From(easeInFunc, easeOutFunc, easeInOutFunc);
            }
        }
    }
}
