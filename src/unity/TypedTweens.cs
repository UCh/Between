using UnityEngine;

namespace Between.Unity {
    
    public class IntTween : Tween<int> {
        public IntTween(int start, int end, float duration, Between.EaseFunc easeFunc = null) : base(start, end, duration, LerpFunction.IntLerp, easeFunc) {
        }
    }

    public class FloatTween : Tween<float> {
        public FloatTween(float start, float end, float duration, Between.EaseFunc easeFunc = null) : base(start, end, duration, Mathf.Lerp, easeFunc) {
        }
    }

    public class TimerTween : Tween<float> {
        public TimerTween(float duration) : base(0f, duration, duration, Mathf.Lerp) {
        }
    }

    public class Vector2Tween : Tween<Vector2> {

        public Vector2Tween(Vector2 start, Vector2 end, float duration, Between.EaseFunc easeFunc = null) : base(start, end, duration, Vector2.Lerp, easeFunc) {
        }
    }

    public class Vector3Tween : Tween<Vector3> {

        public Vector3Tween(Vector3 start, Vector2 end, float duration, Between.EaseFunc easeFunc = null) : base(start, end, duration, Vector3.Lerp, easeFunc) {
        }
    }

    public class Vector4Tween : Tween<Vector4> {
        public Vector4Tween(Vector4 start, Vector4 end, float duration, Between.EaseFunc easeFunc = null) : base(start, end, duration, Vector4.Lerp, easeFunc) {
        }
    }

    public class QuaternionTween : Tween<Quaternion> {
        public QuaternionTween(Quaternion start, Quaternion end, float duration, Between.EaseFunc easeFunc = null) : base(start, end, duration, Quaternion.Lerp, easeFunc) {
        }
    }


}