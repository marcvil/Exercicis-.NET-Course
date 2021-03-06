﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace A3_DbContext
{
	public class Repository<T> where T : Entity
	{
		public static Dictionary<Guid, T> DbSet  { get; set; } = new Dictionary<Guid, T>();

        public IQueryable<T> QueryAll()
        {
            return DbSet.Values.AsQueryable<T>();
        }

        public T Find(Guid id)
        {
            return DbSet[id];

        }

        public virtual SaveValidation<T> Add(T entity)
        {
            var output = new SaveValidation<T>(true);
            
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if (DbSet.ContainsKey(entity.Id))
            {
                output.SaveValidationSuccesful = false;
                output.SaveValidationMessages.Add("Ya existe con este GUID");
            }
            
            if (output.SaveValidationSuccesful)
            {
                DbSet.Add(entity.Id, entity);
                
            }

           return output;
        }

        public virtual SaveValidation<T> Update(T entity)
        {
            var output = new SaveValidation<T>();

            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if (DbSet.ContainsKey(entity.Id))
            {
                output.SaveValidationSuccesful = false;
                output.SaveValidationMessages.Add("Ya existe con este GUID");
            }

            if (output.SaveValidationSuccesful)
            {
                DbSet[output.Entity.Id] = output.Entity;
            }

            return output;
        }
        public virtual DeleteValidation<T> Delete(T entity)
        {
            var output = new DeleteValidation<T>();

            if (DbSet.ContainsKey(entity.Id))
            {
                output.DeleteValidationSuccesful = false;
                output.DeleteValidationMessages.Add("No existe el ID");
            }

            if (output.DeleteValidationSuccesful)
            {
                DbSet.Remove(output.Entity.Id);
            }

            return output;
        }
    }
}
