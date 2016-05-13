using System;

namespace Between {
    internal class GenericEaseImpl : IEase {
        private readonly EaseFunc _easeInFunc;
        private readonly EaseFunc _easeOutFunc;
        private readonly EaseFunc _easeInOutFunc;

        private GenericEaseImpl(EaseFunc easeInFunc, EaseFunc easeOutFunc, EaseFunc easeInOutFunc) {
            if (easeInFunc == null && easeOutFunc == null)
            {
                throw new Exception("Both in and out arguments none, this should not happen! This is bad.");
            }

            _easeInFunc = easeInFunc    ?? GenericIn;
            _easeOutFunc = easeOutFunc   ?? GenericOut;
            _easeInOutFunc = easeInOutFunc ?? GenericInOut;
        }

        public static GenericEaseImpl FromOut(EaseFunc easeOutFunc, EaseFunc easeInOutFunc = null) {
            return new GenericEaseImpl(null, easeOutFunc, easeInOutFunc);
        }

        public static GenericEaseImpl FromIn(EaseFunc easeInFunc, EaseFunc easeInOutFunc = null) {
            return new GenericEaseImpl(easeInFunc, null, easeInOutFunc);
        }

        public static GenericEaseImpl From(EaseFunc easeInFunc, EaseFunc easeOutFunc, EaseFunc easeInOutFunc = null) {
            return new GenericEaseImpl(easeInFunc, easeOutFunc, easeInOutFunc);
        }

        private float GenericIn(float percent) {
            return Ease.Generic.Reverse(percent, Out);
        }

        private float GenericOut(float percent) {
            return Ease.Generic.Reverse(percent, In);
        }

        private float GenericInOut(float percent) {
            return Ease.Generic.InOut(percent, Out);
        }

        public float In(float percent) {
            return _easeInFunc(percent);
        }

        public float Out(float percent) {
            return _easeOutFunc(percent);
        }

        public float InOut(float percent) {
            return _easeInOutFunc(percent);
        }
    }
}