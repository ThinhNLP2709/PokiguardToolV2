/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	[ComVisible(true)]
	public class Object // TypeDefIndex: 2478
	{
		// Constructors
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public Object(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		public virtual bool Equals(object obj); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool Equals(object objA, object objB); // 0x0000000181524F10-0x0000000181524F40
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		~Object(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual int GetHashCode(); // 0x0000000181657540-0x0000000181657550
		public Type GetType(); // 0x00000001816240F0-0x0000000181624100
		protected object MemberwiseClone(); // 0x000000018164E330-0x000000018164E340
		public virtual string ToString(); // 0x0000000181657550-0x0000000181657580
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static bool ReferenceEquals(object objA, object objB); // 0x0000000180A29AB0-0x0000000180A29AC0
		internal static int InternalGetHashCode(object o); // 0x0000000181657540-0x0000000181657550
		private void FieldGetter(string typeName, string fieldName, ref object val); // 0x00000001802E76C0-0x00000001802E76D0
		private void FieldSetter(string typeName, string fieldName, object val); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
