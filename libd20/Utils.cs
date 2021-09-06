using System;

namespace d20 {
    public class Utils {
        public static void Push<T>(ref T[] array, T element) {
            Array.Resize(ref array, array.Length + 1);
            array[array.GetUpperBound(0)] = element;
        }
    }
}