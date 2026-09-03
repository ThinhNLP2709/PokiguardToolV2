/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal class XmlTypeMapMember // TypeDefIndex: 6983
	{
		// Fields
		private string _name; // 0x10
		private int _index; // 0x18
		private int _globalIndex; // 0x1C
		private int _specifiedGlobalIndex; // 0x20
		private TypeData _typeData; // 0x28
		private MemberInfo _member; // 0x30
		private MemberInfo _specifiedMember; // 0x38
		private MethodInfo _shouldSerialize; // 0x40
		private object _defaultValue; // 0x48
		private int _flags; // 0x50
	
		// Properties
		public string Name { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public object DefaultValue { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public TypeData TypeData { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public int Index { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public int GlobalIndex { get; set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public bool IsOptionalValueType { get; set; } // 0x00000001814F5280-0x00000001814F5290 0x0000000181ADD3D0-0x0000000181ADD400
		public bool IsReturnValue { get; set; } // 0x00000001814F5260-0x00000001814F5270 0x0000000181ADD400-0x0000000181ADD430
	
		// Constructors
		public XmlTypeMapMember(); // 0x0000000181ADB750-0x0000000181ADB7B0
	
		// Methods
		public bool IsReadOnly(Type type); // 0x0000000181ADCCD0-0x0000000181ADCDA0
		public static object GetValue(object ob, string name); // 0x0000000181ADC8D0-0x0000000181ADCA40
		public object GetValue(object ob); // 0x0000000181ADC780-0x0000000181ADC8D0
		public void SetValue(object ob, object value); // 0x0000000181ADD0D0-0x0000000181ADD240
		public static void SetValue(object ob, string name, object value); // 0x0000000181ADD240-0x0000000181ADD3D0
		private void InitMember(Type type); // 0x0000000181ADCA40-0x0000000181ADCCD0
		public void CheckOptionalValueType(Type type); // 0x0000000181ADC430-0x0000000181ADC4B0
		public bool GetValueSpecified(object ob); // 0x0000000181ADC4B0-0x0000000181ADC780
		public void SetValueSpecified(object ob, bool value); // 0x0000000181ADCDA0-0x0000000181ADD0D0
	}
}
