using JobApplicationTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplicationTracker.Practice
{
	public static class GenericMethods
	{
		// G1: Generic Method
		public static T? FindById<T>(IEnumerable<T> items, int id)
			where T : class, IEntity
		{
			foreach (T item in items)
			{
				if (item.Id == id)
				{
					return item;
				}
			}

			return null;
		}

		// G1: Generic class => DataStore at proj :))


	}
}

