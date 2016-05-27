using UnityEngine;

namespace Between {
    public static class LerpFunction {

        public static int IntLerp(int start, int end, float percent) {
            return Mathf.FloorToInt(Mathf.LerpUnclamped((float)start, (float)end, percent));
        }
    }
}