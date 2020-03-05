using System;
using System.Collections.Generic;


namespace A3_DbContext
{
	public class DeleteValidation<T>
	{
		public T ValidatedDeleteResult { get; set; }

		public bool DeleteValidationSuccesful { get; set; }

		public List<string> DeleteResultMessages { get; set; } = new List<string>();

	}
}