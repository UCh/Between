using System;

namespace Between {
    public delegate T LerpFunc<T>(T start, T end, float percent);

    public class Tween<T> {

        public event Action<Tween<T>> Completed;

        public T Value { get; private set; }

        public bool Running { get; private set; }

        private T _start;
        private T _end;
        private float _elapsed;
        private float _duration;
        private EaseFunc _easeFunc;
        private LerpFunc<T> _lerpFunc;


        public Tween(T start, T end, float duration, LerpFunc<T> lerpFunc, EaseFunc easeFunc = null) {
            _elapsed = 0.0f;
            _start = start;
            _end = end;
            _duration = duration;

            _easeFunc = easeFunc ?? Ease.Linear;
            _lerpFunc = lerpFunc;

            Value = _start;
            Running = true;
        }

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

        private static T Calculate(T start, T end, float percent, EaseFunc easeFunc, LerpFunc<T> lerpFunc) {
            float scaledPercent = easeFunc(percent);
            return lerpFunc(start, end, scaledPercent);
        }

        private void Ended() {
            if (Completed != null)
            {
                Completed(this);
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
