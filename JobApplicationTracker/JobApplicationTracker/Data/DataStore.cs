using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Data
{
	public class DataStore<T> where T : class, IEntity
	{
		private readonly List<T> _items;

		public DataStore()
		{
			_items = new List<T>();
		}

		public bool Add(T entity)
		{
			if (entity == null)
			{
				//Console.WriteLine("Entity is null.");
				return false;
			}
			foreach (var item in _items)
			{
				if (item.Id == entity.Id)
				{
					//Console.WriteLine("Entity with the same ID already exists.");
					return false;
				}
			}

			_items.Add(entity);
			return true;
		}


		public T? GetById(int id)
		{
			foreach (var item in _items)
			{
				if (item.Id == id)
					return item;
			}

			return null;
		}

		public IEnumerable<T> GetAll()
		{
			return new List<T>(_items);
		}

		public bool Update(T entity)
		{
			if (entity == null)
			{
				//Console.WriteLine("Entity is null.");
				return false;
			}

			for (int i = 0; i < _items.Count; i++)
			{
				if (_items[i].Id == entity.Id)
				{
					_items[i] = entity;
					return true;
				}
			}

			//Console.WriteLine("Entity not found.");
			return false;
		}

		public bool RemoveById(int id)
		{
			T? entity = GetById(id);
			if (entity == null)
			{
				//Console.WriteLine("Entity is null.");
				return false;
			}

			_items.Remove(entity);
			return true;
		}

	}
}
			