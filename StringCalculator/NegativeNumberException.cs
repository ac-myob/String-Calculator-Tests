using System;
namespace StringCalculator {
    public class NegativeNumberException : Exception {
        public NegativeNumberException(string errorMsg) : base(errorMsg) {}
    }
}