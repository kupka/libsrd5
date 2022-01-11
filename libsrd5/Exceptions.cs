using System;

namespace srd5 {
    public class Srd5Exception : Exception {
        public Srd5Exception(string message) : base(message) {

        }
    }

    public class Srd5ArgumentException : Srd5Exception {
        public Srd5ArgumentException(string message) : base(message) {

        }
    }

    public class Srd5FormatException : Srd5Exception {
        public Srd5FormatException(string message) : base(message) {

        }

    }
}