using System;

namespace srd5 {
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

        public static void Remove<T>(ref T[] array, T element) {
            int index = Array.IndexOf(array, element);
            if (index == -1) return;
            for (int i = index; i < array.Length - 1; i++) {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }
    }
}