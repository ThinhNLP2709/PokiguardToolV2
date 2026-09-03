/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public class ConverterGroup // TypeDefIndex: 3827
	{
		// Fields
		[CompilerGenerated]
		private readonly string _id_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly string _displayName_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly string _description_k__BackingField; // 0x20
		private ConversionRegistry m_Registry; // 0x28
	
		// Properties
		internal ConversionRegistry registry { get; } // 0x0000000180C46B90-0x0000000180C46BA0 
		internal ref ConversionRegistry registerRef { get; } // 0x0000000181FC2D50-0x0000000181FC2D60 
	
		// Constructors
		public ConverterGroup(string id, string displayName = null, string description = null); // 0x0000000182384BA0-0x0000000182384C30
	
		// Methods
		public bool TryConvert<TSource, TDestination>(ref ref TSource source, out ref TDestination destination);
		public bool TrySetValue<TContainer, TValue>(ref ref TContainer container, [IsReadOnly] in PropertyPath path, TValue value, out VisitReturnCode returnCode);
	}
}
