/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Utilities
{
	public struct NamedValue : IEquatable<UnityEngine.InputSystem.Utilities.NamedValue> // TypeDefIndex: 6615
	{
		// Fields
		public const string Separator = ","; // Metadata: 0x006991B7
		[CompilerGenerated]
		private string _name_k__BackingField; // 0x00
		[CompilerGenerated]
		private PrimitiveValue _value_k__BackingField; // 0x08
	
		// Properties
		public string name { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001808BADD0-0x00000001808BADE0 0x0000000180E02C90-0x0000000180E02CA0
		public PrimitiveValue value { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C57230-0x0000000180C57240 0x0000000181259E20-0x0000000181259E30
		public TypeCode type { get; } // 0x0000000180732D20-0x0000000180732D30 
	
		// Methods
		public NamedValue ConvertTo(TypeCode type); // 0x0000000181CFAAB0-0x0000000181CFAB20
		public static NamedValue From<TValue>(string name, TValue value)
			where TValue : struct;
		public override string ToString(); // 0x0000000181CFB290-0x0000000181CFB310
		public bool Equals(NamedValue other); // 0x0000000181CFAB20-0x0000000181CFABA0
		public override bool Equals(object obj); // 0x0000000181CFABA0-0x0000000181CFAC90
		public override int GetHashCode(); // 0x0000000181CFAC90-0x0000000181CFAD30
		public static bool operator ==(NamedValue left, NamedValue right); // 0x0000000181CFB310-0x0000000181CFB390
		public static bool operator !=(NamedValue left, NamedValue right); // 0x0000000181CFB390-0x0000000181CFB430
		public static NamedValue[] ParseMultiple(string parameterString); // 0x0000000181CFAD30-0x0000000181CFAF30
		public static NamedValue Parse(string str); // 0x0000000181CFB250-0x0000000181CFB290
		private static NamedValue ParseParameter(string parameterString, ref int index); // 0x0000000181CFAF30-0x0000000181CFB250
		public void ApplyToObject(object instance); // 0x0000000181CFA680-0x0000000181CFAAB0
		public static void ApplyAllToObject<TParameterList>(object instance, TParameterList parameters)
			where TParameterList : IEnumerable<NamedValue>;
	}
}
