using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public static class GeneralMetods
    {
        //public static Vector3 GetVectorFromAngle(int angle)
        //{
        //    // angle = 0 -> 360
        //    float angleRad = angle * (Mathf.PI / 180f);
        //    return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        //}

        public static float GetAngleFromVectorFloat(Vector3 direction)
        {
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle < 0) angle += 360;

            return angle;
        }
        public static Vector3 GetVectorFromAngle(float angle)
        {
            // angle = 0 -> 360
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }


        public static int GetAngleFromVectorInt(Vector3 direction)
        {
            direction = direction.normalized;
            int angle = (int)(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            if (angle < 0) angle += 360;

            return angle;
        }
    }
}
