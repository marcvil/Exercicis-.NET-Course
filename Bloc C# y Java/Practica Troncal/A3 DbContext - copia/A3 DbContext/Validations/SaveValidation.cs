using System;
using System.Collections.Generic;


namespace A3_DbContext
{
	public class SaveValidation<T> where T: Entity
	{
		public T EntityValidated { get; set; }

		public bool SaveValidationSuccesful { get; set; }

		public List<string> SaveValidationMessages { get; set; } = new List<string>();

	}
}