using System;
using System.Collections.Generic;

namespace A3_DbContext
{
    public class ValidationResult<T>
    {
        public T ValidatedResult { get; set; }

        public bool ValidationSuccesful { get; set; }

        public List<string> Messages { get; set; } = new List<string>();


    }
}
