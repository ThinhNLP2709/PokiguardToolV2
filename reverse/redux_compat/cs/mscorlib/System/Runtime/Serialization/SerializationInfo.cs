/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	[ComVisible(true)]
	public sealed class SerializationInfo // TypeDefIndex: 3051
	{
		// Fields
		internal string[] m_members; // 0x10
		internal object[] m_data; // 0x18
		internal Type[] m_types; // 0x20
		private Dictionary<string, int> m_nameToIndex; // 0x28
		internal int m_currMember; // 0x30
		internal IFormatterConverter m_converter; // 0x38
		private string m_fullTypeName; // 0x40
		private string m_assemName; // 0x48
		private Type objectType; // 0x50
		private bool isFullTypeNameSetExplicit; // 0x58
		private bool isAssemblyNameSetExplicit; // 0x59
		private bool requireSameTokenInPartialTrust; // 0x5A
	
		// Properties
		public string FullTypeName { get; } // 0x0000000180377940-0x0000000180377950 
		public string AssemblyName { get; } // 0x00000001803272B0-0x00000001803272C0 
		public int MemberCount { get; } // 0x000000018033D100-0x000000018033D110 
		public Type ObjectType { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public bool IsFullTypeNameSetExplicit { get; } // 0x0000000181424750-0x0000000181424760 
		public bool IsAssemblyNameSetExplicit { get; } // 0x00000001802E7880-0x00000001802E7890 
	
		// Constructors
		[CLSCompliant(false)]
		public SerializationInfo(Type type, IFormatterConverter converter); // 0x0000000181504380-0x00000001815043A0
		[CLSCompliant(false)]
		public SerializationInfo(Type type, IFormatterConverter converter, bool requireSameTokenInPartialTrust); // 0x00000001815043A0-0x0000000181504620
	
		// Methods
		public void SetType(Type type); // 0x0000000181504000-0x00000001815041C0
		private static bool Compare(byte[] a, byte[] b); // 0x0000000181502E30-0x0000000181502EB0
		internal static void DemandForUnsafeAssemblyNameAssignments(string originalAssemblyName, string newAssemblyName); // 0x0000000181502EB0-0x0000000181502EC0
		internal static bool IsAssemblyNameAssignmentSafe(string originalAssemblyName, string newAssemblyName); // 0x0000000181503E70-0x0000000181504000
		public SerializationInfoEnumerator GetEnumerator(); // 0x00000001815034F0-0x0000000181503590
		private void ExpandArrays(); // 0x0000000181502EC0-0x0000000181502FD0
		public void AddValue(string name, object value, Type type); // 0x0000000181502200-0x00000001815022C0
		public void AddValue(string name, object value); // 0x00000001815023F0-0x00000001815025C0
		public void AddValue(string name, bool value); // 0x0000000181502D00-0x0000000181502E30
		public void AddValue(string name, byte value); // 0x00000001815026F0-0x0000000181502820
		public void AddValue(string name, short value); // 0x0000000181502820-0x0000000181502950
		public void AddValue(string name, int value); // 0x0000000181502AA0-0x0000000181502BD0
		public void AddValue(string name, long value); // 0x00000001815022C0-0x00000001815023F0
		[CLSCompliant(false)]
		public void AddValue(string name, ulong value); // 0x0000000181502BD0-0x0000000181502D00
		public void AddValue(string name, float value); // 0x00000001815025C0-0x00000001815026F0
		public void AddValue(string name, DateTime value); // 0x0000000181502950-0x0000000181502AA0
		internal void AddValueInternal(string name, object value, Type type); // 0x0000000181501F00-0x0000000181502200
		internal void UpdateValue(string name, object value, Type type); // 0x00000001815041C0-0x0000000181504380
		private int FindElement(string name); // 0x0000000181502FD0-0x0000000181503090
		private object GetElement(string name, out Type foundType); // 0x0000000181503320-0x00000001815034F0
		[ComVisible(true)]
		private object GetElementNoThrow(string name, out Type foundType); // 0x00000001815031D0-0x0000000181503320
		public object GetValue(string name, Type type); // 0x0000000181503CA0-0x0000000181503E70
		[ComVisible(true)]
		internal object GetValueNoThrow(string name, Type type); // 0x0000000181503AB0-0x0000000181503CA0
		public bool GetBoolean(string name); // 0x0000000181503090-0x00000001815031D0
		public int GetInt32(string name); // 0x0000000181503590-0x00000001815036D0
		public long GetInt64(string name); // 0x00000001815036D0-0x0000000181503810
		public float GetSingle(string name); // 0x0000000181503810-0x0000000181503960
		public string GetString(string name); // 0x0000000181503960-0x0000000181503AB0
	}
}
