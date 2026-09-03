/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using UnityEngine;
using UnityEngine.Bindings;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct ConverterKey : IEquatable<Unity.Properties.ConverterKey> // TypeDefIndex: 14519
	{
		// Fields
		public readonly Type SourceType; // 0x00
		public readonly Type DestinationType; // 0x08
	
		// Constructors
		public ConverterKey(Type source, Type destination); // 0x0000000180CC3FE0-0x0000000180CC4020
	
		// Methods
		[CompilerGenerated]
		public override string ToString(); // 0x00000001822DA5C0-0x00000001822DA6F0
		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder); // 0x00000001822DA520-0x00000001822DA5C0
		[CompilerGenerated]
		public override int GetHashCode(); // 0x00000001822DA480-0x00000001822DA520
		[CompilerGenerated]
		public override bool Equals(object obj); // 0x00000001822DA3F0-0x00000001822DA480
		[CompilerGenerated]
		public bool Equals(ConverterKey other); // 0x00000001822DA340-0x00000001822DA3F0
	}
}
