﻿using System;
using System.Collections.Generic;


namespace A3_DbContext
{
	public class SaveValidation<T> where T: Entity
	{
		public ValidationResult Validation { get; set; } = new ValidationResult();

		public bool SaveValidationSuccesful
		{
			get
			{
				return Validation.ValidationSuccesful;
			}

			set
			{
				Validation.ValidationSuccesful = value;
			}
		}
		public List<string> SaveValidationMessages { get; set; } = new List<string>();

		public T Entity { get; set; }


		//constructor para que sea true por defecto
		public SaveValidation()
		{
			
		}
		public SaveValidation(bool initTrue)
		{
			this.SaveValidationSuccesful = initTrue;
		}



		public SaveValidation<TOut> Cast<TOut>() where TOut : Entity
		{
			var output = new SaveValidation<TOut>
			{
				Entity = this.Entity as TOut,
				Validation = this.Validation
			};

			return output;
		}
	}
}