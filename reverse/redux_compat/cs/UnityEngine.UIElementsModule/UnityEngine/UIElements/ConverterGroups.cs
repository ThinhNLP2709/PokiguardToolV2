/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public static class ConverterGroups // TypeDefIndex: 3828
	{
		// Fields
		private static readonly ConverterGroup s_GlobalConverters; // 0x00
		private static readonly Dictionary<string, ConverterGroup> s_BindingConverterGroups; // 0x08
	
		// Nested types
		internal struct Unsafe // TypeDefIndex: 3829
		{
			// Methods
			public static void LazyRegisterGlobal(Type source, Type destination, Func<Delegate> converterDelegate); // 0x00000001823938F0-0x00000001823939B0
		}
	
		// Constructors
		static ConverterGroups(); // 0x0000000182384C30-0x0000000182384D30
	
		// Methods
		public static bool TryConvert<TSource, TDestination>(ref ref TSource source, out ref TDestination destination);
	}
}
