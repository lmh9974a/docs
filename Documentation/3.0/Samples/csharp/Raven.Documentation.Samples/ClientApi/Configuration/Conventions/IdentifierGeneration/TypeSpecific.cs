﻿namespace Raven.Documentation.Samples.ClientApi.Configuration.Conventions.IdentifierGeneration
{
	using System;
	using System.Threading.Tasks;
	using Abstractions.Util;
	using Client.Connection;
	using Client.Connection.Async;
	using Client.Document;
	using CodeSamples.Orders;

	public class TypeSpecific
	{
		public interface IFoo
		{
			#region register_id_convention_method
			DocumentConvention RegisterIdConvention<TEntity>(Func<string, IDatabaseCommands, TEntity, string> func);
			#endregion

			#region register_id_convention_method_async
			DocumentConvention RegisterAsyncIdConvention<TEntity>(Func<string, IAsyncDatabaseCommands, TEntity,
														Task<string>> func);
			#endregion
		}

		public class EmployeeManager : Employee
		{

		}

		public TypeSpecific()
		{
			var store = new DocumentStore();

			#region eployees_custom_convention
			store.Conventions.RegisterIdConvention<Employee>(
				(dbname, commands, employee) => string.Format("employees/{0}/{1}", employee.LastName, employee.FirstName));
			#endregion

			#region eployees_custom_async_convention
			store.Conventions.RegisterAsyncIdConvention<Employee>(
				(dbname, commands, employee) => new CompletedTask<string>(
					string.Format("employees/{0}/{1}", employee.LastName, employee.FirstName)));
			#endregion

			#region eployees_custom_convention_example
			using (var session = store.OpenSession())
			{
				session.Store(new Employee
				{
					FirstName = "James",
					LastName = "Bond"
				});

				session.SaveChanges();
			}
			#endregion

			#region eployees_custom_convention_inheritance
			using (var session = store.OpenSession())
			{
				session.Store(new Employee // employees/Smith/Adam
				{
					FirstName = "Adam",
					LastName = "Smith"
				});

				session.Store(new EmployeeManager // employees/Jones/David
				{
					FirstName = "David",
					LastName = "Jones"
				});

				session.SaveChanges();
			}
			#endregion


			#region custom_convention_inheritance_2
			store.Conventions.RegisterIdConvention<Employee>(
				(dbname, commands, employee) => string.Format("employees/{0}/{1}", employee.LastName, employee.FirstName));

			store.Conventions.RegisterIdConvention<EmployeeManager>(
				(dbname, commands, employee) => string.Format("managers/{0}/{1}", employee.LastName, employee.FirstName));

			using (var session = store.OpenSession())
			{
				session.Store(new Employee // employees/Smith/Adam
				{
					FirstName = "Adam",
					LastName = "Smith"
				});

				session.Store(new EmployeeManager // managers/Jones/David
				{
					FirstName = "David",
					LastName = "Jones"
				});

				session.SaveChanges();
			}
			#endregion
		}
	}
}