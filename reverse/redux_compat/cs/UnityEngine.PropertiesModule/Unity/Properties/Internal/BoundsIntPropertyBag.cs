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
	internal class BoundsIntPropertyBag : ContainerPropertyBag<BoundsInt> // TypeDefIndex: 14582
	{
		// Nested types
		private class PositionProperty : Property<BoundsInt, Vector3Int> // TypeDefIndex: 14583
		{
			// Properties
			public override string Name { get; } // 0x00000001822DB140-0x00000001822DB170 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public PositionProperty(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override Vector3Int GetValue(ref BoundsInt container); // 0x0000000180F61100-0x0000000180F61120
			public override void SetValue(ref BoundsInt container, Vector3Int value); // 0x00000001822D9680-0x00000001822D96A0
		}
	
		private class SizeProperty : Property<BoundsInt, Vector3Int> // TypeDefIndex: 14584
		{
			// Properties
			public override string Name { get; } // 0x00000001822E26E0-0x00000001822E2710 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public SizeProperty(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override Vector3Int GetValue(ref BoundsInt container); // 0x00000001822DA6F0-0x00000001822DA710
			public override void SetValue(ref BoundsInt container, Vector3Int value); // 0x00000001822DA710-0x00000001822DA730
		}
	
		// Constructors
		public BoundsIntPropertyBag(); // 0x00000001822D93E0-0x00000001822D94D0
	}
}
