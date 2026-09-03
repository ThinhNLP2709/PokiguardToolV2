/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties.Internal
{
	internal class Vector2PropertyBag : ContainerPropertyBag<Vector2> // TypeDefIndex: 14550
	{
		// Nested types
		private class XProperty : Property<Vector2, float> // TypeDefIndex: 14551
		{
			// Properties
			public override string Name { get; } // 0x00000001822E5C60-0x00000001822E5C90 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public XProperty(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override float GetValue(ref Vector2 container); // 0x00000001822E1A10-0x00000001822E1A20
			public override void SetValue(ref Vector2 container, float value); // 0x00000001822E1A20-0x00000001822E1A30
		}
	
		private class YProperty : Property<Vector2, float> // TypeDefIndex: 14552
		{
			// Properties
			public override string Name { get; } // 0x00000001822E5FF0-0x00000001822E6020 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public YProperty(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override float GetValue(ref Vector2 container); // 0x00000001822DA840-0x00000001822DA850
			public override void SetValue(ref Vector2 container, float value); // 0x00000001822DA850-0x00000001822DA860
		}
	
		// Constructors
		public Vector2PropertyBag(); // 0x00000001822E54B0-0x00000001822E55A0
	}
}
