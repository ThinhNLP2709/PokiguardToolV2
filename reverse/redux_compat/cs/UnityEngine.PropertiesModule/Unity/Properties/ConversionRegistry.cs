/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct ConversionRegistry : IEqualityComparer<Unity.Properties.ConversionRegistry> // TypeDefIndex: 14521
	{
		// Fields
		private readonly Dictionary<ConverterKey, Delegate> m_Converters; // 0x00
		private readonly Dictionary<ConverterKey, Func<Delegate>> m_LazyConverters; // 0x08
	
		// Constructors
		private ConversionRegistry(Dictionary<ConverterKey, Delegate> storage); // 0x00000001822DA0C0-0x00000001822DA190
	
		// Methods
		public static ConversionRegistry Create(); // 0x00000001822D9A40-0x00000001822D9B90
		public void Clear(); // 0x00000001822D9A00-0x00000001822D9A40
		public void Register(Type source, Type destination, Delegate converter); // 0x00000001822D9E30-0x00000001822D9F30
		public void LazyRegister(Type source, Type destination, Func<Delegate> converter); // 0x00000001822D9D20-0x00000001822D9E30
		public void Apply(ConversionRegistry registry); // 0x00000001822D9820-0x00000001822D9A00
		public Delegate GetConverter(Type source, Type destination); // 0x00000001822D9BA0-0x00000001822D9D00
		public bool TryGetConverter(Type source, Type destination, out Delegate converter); // 0x00000001822D9F30-0x00000001822DA0C0
		public bool Equals(ConversionRegistry x, ConversionRegistry y); // 0x00000001822D9B90-0x00000001822D9BA0
		public int GetHashCode(ConversionRegistry obj); // 0x00000001822D9D00-0x00000001822D9D20
	}
}
