/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	internal class CADMessageBase // TypeDefIndex: 2972
	{
		// Fields
		protected object[] _args; // 0x10
		protected byte[] _serializedArgs; // 0x18
		protected int _propertyCount; // 0x20
		protected CADArgHolder _callContext; // 0x28
		internal byte[] serializedMethod; // 0x30
	
		// Constructors
		public CADMessageBase(IMethodMessage msg); // 0x00000001814D1C40-0x00000001814D1CF0
	
		// Methods
		internal MethodBase GetMethod(); // 0x00000001814D0030-0x00000001814D01A0
		protected static Type[] GetSignature(MethodBase methodBase, bool load); // 0x00000001814D01A0-0x00000001814D03B0
		internal static int MarshalProperties(IDictionary dict, ref ArrayList args); // 0x00000001814D09E0-0x00000001814D0ED0
		internal static void UnmarshalProperties(IDictionary dict, int count, ArrayList args); // 0x00000001814D1AD0-0x00000001814D1C40
		private static bool IsPossibleToIgnoreMarshal(object obj); // 0x00000001814D03B0-0x00000001814D0540
		protected object MarshalArgument(object arg, ref ArrayList args); // 0x00000001814D0540-0x00000001814D0890
		protected object UnmarshalArgument(object arg, ArrayList args); // 0x00000001814D10A0-0x00000001814D1980
		internal object[] MarshalArguments(object[] arguments, ref ArrayList args); // 0x00000001814D0890-0x00000001814D09E0
		internal object[] UnmarshalArguments(object[] arguments, ArrayList args); // 0x00000001814D1980-0x00000001814D1AD0
		protected void SaveLogicalCallContext(IMethodMessage msg, ref ArrayList serializeList); // 0x00000001814D0ED0-0x00000001814D10A0
		internal LogicalCallContext GetLogicalCallContext(ArrayList args); // 0x00000001814CFFA0-0x00000001814D0030
	}
}
