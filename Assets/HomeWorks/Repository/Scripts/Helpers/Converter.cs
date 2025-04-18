using UnityEngine;

namespace DataEngine
{
    public static class Converter
    {
        public static float[] Vector3ToArray(Vector3 vector)
        {
            return new float[] { vector.x, vector.y, vector.z };
        }

        public static Vector3 ArrayToVector3(float[] array)
        {
            if (array == null || array.Length != 3)
                return Vector3.zero;
            
            return new Vector3(array[0], array[1], array[2]);
        }
    }
}