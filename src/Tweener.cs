using System;

namespace Between {
    public delegate float EaseFunc(float percent);

    public delegate T LerpFunc<T>(T start, T end, float percent);

    public class Tweener<T> {

        public Tweener(T start, T end, float duration, EaseFunc easeFunc = null, LerpFunc<T> lerpFunc = null) {
            _elapsed = 0.0f;
            _start = start;
            _end = end;
            _duration = duration;

            // If there's no ease function specified, use Linear
            _easeFunc = easeFunc ?? Ease.Linear;

            // If there's no lerp function specified, use Generic Default
            _lerpFunc = lerpFunc;// ?? LerpFuncDefault;

            Value = _start;z
            Running = true;
        }

        public Tweener(T start, T end, TimeSpan duration, EaseFunc easeFunc = null, LerpFunc<T> lerpFunc = null) : this(start, end, (float)duration.TotalSeconds, easeFunc, lerpFunc) {
        }

        public T Value { get; private set; }

        public bool Running { get; private set; }

        private T _start;
        private T _end;
        private float _elapsed;
        private float _duration;
        private EaseFunc _easeFunc;
        private LerpFunc<T> _lerpFunc;

        public delegate void OnEndHandler(object sender, EventArgs e);

        public event OnEndHandler OnEnd;

        public void Update(float deltaTime) {

            if (!Running) return;

            _elapsed += deltaTime;

            if (_elapsed >= _duration)
            {
                _elapsed = _duration;
                Value = Calculate(_start, _end, 1, _easeFunc, _lerpFunc);

                Stop();
                Ended();

                return;
            }

            Value = Calculate(_start, _end, _elapsed / _duration, _easeFunc, _lerpFunc);
        }


        //        private static T LerpFuncDefault(T start, T end, float percent) {

        //        }

        private static T Calculate(T start, T end, float percent, EaseFunc easeFunc, LerpFunc<T> lerpFunc) {
            float scaledPercent = easeFunc(percent);
            return lerpFunc(start, end, scaledPercent);
        }

        private void Ended() {
            if (OnEnd != null)
            {
                OnEnd(this, EventArgs.Empty);
            }
        }

        public void Start() {
            Running = true;
        }

        public void Stop() {
            Running = false;
        }

        public void Reset() {
            _elapsed = 0.0f;
            Value = _start;
        }

        public void Reset(T to) {
            _elapsed = 0.0f;
            _start = Value;
            _end = to;
        }

        public void Reverse() {
            _elapsed = 0.0f;

            T tmp = _end;
            _end = _start;
            _start = tmp;
        }

        public override string ToString() {
            return String.Format("{0}.{1}.\n{2}.{3}.\nTween {4} -> {5} in {6}s. _elapsed {7:##0.##}s",
                    (_easeFunc.Method.DeclaringType != null) ? _easeFunc.Method.DeclaringType.Name : "null",
                    _easeFunc.Method.Name,
                    (_lerpFunc.Method.DeclaringType != null) ? _lerpFunc.Method.DeclaringType.Name : "null",
                    _lerpFunc.Method.Name,
                    _start,
                    _end,
                    _duration,
                    _elapsed);
        }
    }
}
