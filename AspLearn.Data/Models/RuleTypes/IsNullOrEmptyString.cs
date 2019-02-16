using System;
using System.Collections.Generic;
using System.Text;

namespace AspLearn.Data.Models.RuleTypes {
    public class IsNullOrEmptyString {

        public string Value { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="value"></param>
        public IsNullOrEmptyString(string value) {
            Value = Validate(value);
        }

        private string Validate(string value) {
            if (!string.IsNullOrEmpty(value)) {
                return value;
            }

            throw new Exception();
        }
    }
}
