using System;

namespace d20 {
    public class Utils {
        public static void Push<T>(ref T[] array, T element) {
            Array.Resize(ref array, array.Length + 1);
            array[array.GetUpperBound(0)] = element;
        }

        public static void PushUnique<T>(ref T[] array, T element) {
            if (Array.IndexOf(array, element) == -1) {
                Push<T>(ref array, element);
            }
        }
    }
}