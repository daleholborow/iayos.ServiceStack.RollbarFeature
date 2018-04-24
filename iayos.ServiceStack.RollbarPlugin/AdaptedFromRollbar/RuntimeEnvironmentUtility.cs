﻿using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace iayos.ServiceStack.RollbarPlugin.AdaptedFromRollbar
{
	/// <summary>
	/// A utility class aiding discovery of the current runtime environment.
	/// </summary>
	public static class RuntimeEnvironmentUtility
	{
		/// <summary>
		/// Gets the type assembly version.
		/// </summary>
		/// <param name="theType">The type.</param>
		/// <returns></returns>
		public static string GetTypeAssemblyVersion(Type theType)
		{
			return theType.Assembly.GetName().Version.ToString(3);
		}

		/// <summary>
		/// Gets the assembly target frameworks.
		/// </summary>
		/// <param name="typeFromAssembly">The type from assembly.</param>
		/// <returns></returns>
		public static string[] GetAssemblyTargetFrameworks(Type typeFromAssembly)
		{
			return RuntimeEnvironmentUtility.GetAssemblyTargetFrameworks(typeFromAssembly.Assembly);
		}

		/// <summary>
		/// Gets the assembly target frameworks.
		/// </summary>
		/// <param name="theAssembly">The assembly.</param>
		/// <returns></returns>
		public static string[] GetAssemblyTargetFrameworks(Assembly theAssembly)
		{
			var attributes = theAssembly
				.GetCustomAttributes(typeof(TargetFrameworkAttribute), false)
				.Cast<TargetFrameworkAttribute>()
				.ToArray();

			var targetFrameworks = attributes
				.Select(a => a.FrameworkName)
				.ToArray();

			return targetFrameworks;
		}
	}
}