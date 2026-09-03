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
	internal class SystemVersionPropertyBag : ContainerPropertyBag<Version> // TypeDefIndex: 14585
	{
		// Nested types
		private class MajorProperty : Property<Version, int> // TypeDefIndex: 14586
		{
			// Properties
			public override string Name { get; } // 0x00000001822DAE00-0x00000001822DAE30 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MajorProperty(); // 0x00000001822DAD90-0x00000001822DAE00
	
			// Methods
			public override int GetValue(ref Version container); // 0x00000001822DAD70-0x00000001822DAD90
			public override void SetValue(ref Version container, int value); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		private class MinorProperty : Property<Version, int> // TypeDefIndex: 14587
		{
			// Properties
			public override string Name { get; } // 0x00000001822DAEC0-0x00000001822DAEF0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public MinorProperty(); // 0x00000001822DAE50-0x00000001822DAEC0
	
			// Methods
			public override int GetValue(ref Version container); // 0x00000001822DAE30-0x00000001822DAE50
			public override void SetValue(ref Version container, int value); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		private class BuildProperty : Property<Version, int> // TypeDefIndex: 14588
		{
			// Properties
			public override string Name { get; } // 0x00000001822D9650-0x00000001822D9680 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public BuildProperty(); // 0x00000001822D95E0-0x00000001822D9650
	
			// Methods
			public override int GetValue(ref Version container); // 0x00000001822D95C0-0x00000001822D95E0
			public override void SetValue(ref Version container, int value); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		private class RevisionProperty : Property<Version, int> // TypeDefIndex: 14589
		{
			// Properties
			public override string Name { get; } // 0x00000001822E26B0-0x00000001822E26E0 
			public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
			// Constructors
			public RevisionProperty(); // 0x00000001822E2640-0x00000001822E26B0
	
			// Methods
			public override int GetValue(ref Version container); // 0x00000001822E2620-0x00000001822E2640
			public override void SetValue(ref Version container, int value); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public SystemVersionPropertyBag(); // 0x00000001822E2710-0x00000001822E2990
	}
}
