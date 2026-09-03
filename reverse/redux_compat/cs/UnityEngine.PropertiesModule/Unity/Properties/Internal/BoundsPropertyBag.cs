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
	internal class BoundsPropertyBag : ContainerPropertyBag<Bounds> // TypeDefIndex: 14579
	{
		// Nested types
		private class CenterProperty : Property<Bounds, Vector3> // TypeDefIndex: 14580
		{
			// Properties
			public override string Name { get; } // 0x00000001822D96A0-0x00000001822D96D0 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public CenterProperty(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override Vector3 GetValue(ref Bounds container); // 0x0000000180F61100-0x0000000180F61120
			public override void SetValue(ref Bounds container, Vector3 value); // 0x00000001822D9680-0x00000001822D96A0
		}
	
		private class ExtentsProperty : Property<Bounds, Vector3> // TypeDefIndex: 14581
		{
			// Properties
			public override string Name { get; } // 0x00000001822DA730-0x00000001822DA760 
			public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public ExtentsProperty(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override Vector3 GetValue(ref Bounds container); // 0x00000001822DA6F0-0x00000001822DA710
			public override void SetValue(ref Bounds container, Vector3 value); // 0x00000001822DA710-0x00000001822DA730
		}
	
		// Constructors
		public BoundsPropertyBag(); // 0x00000001822D94D0-0x00000001822D95C0
	}
}
