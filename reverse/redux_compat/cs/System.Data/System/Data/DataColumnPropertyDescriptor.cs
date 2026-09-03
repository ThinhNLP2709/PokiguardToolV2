/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class DataColumnPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 11229
	{
		// Fields
		[CompilerGenerated]
		private readonly DataColumn _Column_k__BackingField; // 0x88
	
		// Properties
		public override AttributeCollection Attributes { get; } // 0x0000000181869D30-0x0000000181869EF0 
		internal DataColumn Column { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public override Type ComponentType { get; } // 0x0000000181869EF0-0x0000000181869F30 
		public override bool IsReadOnly { get; } // 0x0000000181869F30-0x0000000181869F50 
		public override Type PropertyType { get; } // 0x0000000181869F50-0x0000000181869F70 
	
		// Constructors
		internal DataColumnPropertyDescriptor(DataColumn dataColumn); // 0x0000000181869CE0-0x0000000181869D30
	
		// Methods
		public override bool Equals(object other); // 0x00000001818699D0-0x0000000181869A70
		public override int GetHashCode(); // 0x0000000181869A70-0x0000000181869AA0
		public override bool CanResetValue(object component); // 0x00000001818698B0-0x00000001818699D0
		public override object GetValue(object component); // 0x0000000181869AA0-0x0000000181869B30
		public override void ResetValue(object component); // 0x0000000181869B30-0x0000000181869BF0
		public override void SetValue(object component, object value); // 0x0000000181869BF0-0x0000000181869CE0
		public override bool ShouldSerializeValue(object component); // 0x00000001802E7840-0x00000001802E7850
	}
}
