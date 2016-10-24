using System;
using System.Reflection;

namespace Orion.Framework
{
	/// <summary>
	/// Provides the base class for a service.
	/// </summary>
	public abstract class Service : IService
	{
		/// <inheritdoc/>
		public string Author { get; }

		/// <inheritdoc/>
		public string Name { get; }

		/// <summary>
		/// Gets the Orion instance that this service belongs to.
		/// </summary>
		protected Orion Orion { get; }

		/// <inheritdoc/>
		public Version Version { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Service"/> class.
		/// </summary>
		/// <param name="orion">The Orion instance that this service belongs to.</param>
		protected Service(Orion orion)
		{
			Orion = orion;

			Type type = GetType();
			var attribute = type.GetCustomAttribute<ServiceAttribute>();
			Author = attribute?.Author ?? Languages.Language.AnonymousAuthor;
			Name = attribute?.Name ?? type.Name;
			Version = Assembly.GetAssembly(type).GetName().Version;
		}

		/// <summary>
		/// Destroys the service, releasing any of its unmanged resources.
		/// </summary>
		~Service()
		{
			/*
			 * All unmanaged service resources must be deallocated in Dispose() regardless of if it's a
			 * managed dispose or a finalizer, HGlobal memory *must* be freed regardless or it will leak.
			 * 
			 * See CA1063 https://msdn.microsoft.com/en-us/library/ms244737.aspx
			 */
			Dispose(false);
		}

		/// <summary>
		/// Disposes the service and any of its unmanaged and managed resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Disposes the service and any of its unmanaged resources, optionally including its managed resources.
		/// </summary>
		/// <param name="disposing">
		/// <c>true</c> if called from a managed disposal and both unmanaged and managed resources must be released,
		/// <c>false</c> if called from a finalizer and only unmanaged resources must be released.
		/// </param>
		/// <remarks>
		/// If your service has unmanaged resources, you must release them here.
		/// </remarks>
		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
