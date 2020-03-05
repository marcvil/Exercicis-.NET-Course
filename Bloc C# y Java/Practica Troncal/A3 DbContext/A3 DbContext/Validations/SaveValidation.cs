using System;
using System.Collections.Generic;


namespace A3_DbContext
{
	public class SaveValidation<T>
	{
		public T ValidatedSaveResult { get; set; }

		public bool SaveValidationSuccesful { get; set; }

		public List<string> SaveResultMessages { get; set; } = new List<string>();

	}
}