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
	internal sealed class DataRelationPropertyDescriptor : PropertyDescriptor // TypeDefIndex: 11237
	{
		// Fields
		[CompilerGenerated]
		private readonly DataRelation _Relation_k__BackingField; // 0x88
	
		// Properties
		internal DataRelation Relation { [CompilerGenerated] get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public override Type ComponentType { get; } // 0x0000000181869EF0-0x0000000181869F30 
		public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override Type PropertyType { get; } // 0x000000018186CF40-0x000000018186CF80 
	
		// Constructors
		internal DataRelationPropertyDescriptor(DataRelation dataRelation); // 0x000000018186CED0-0x000000018186CF40
	
		// Methods
		public override bool Equals(object other); // 0x000000018186CDA0-0x000000018186CE40
		public override int GetHashCode(); // 0x0000000181869A70-0x0000000181869AA0
		public override bool CanResetValue(object component); // 0x00000001802E7840-0x00000001802E7850
		public override object GetValue(object component); // 0x000000018186CE40-0x000000018186CED0
		public override void ResetValue(object component); // 0x00000001802E76C0-0x00000001802E76D0
		public override void SetValue(object component, object value); // 0x00000001802E76C0-0x00000001802E76D0
		public override bool ShouldSerializeValue(object component); // 0x00000001802E7840-0x00000001802E7850
	}
}
