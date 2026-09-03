/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Channels
{
	internal class CADSerializer // TypeDefIndex: 2936
	{
		// Methods
		internal static IMessage DeserializeMessage(MemoryStream mem, IMethodCallMessage msg); // 0x00000001814D3150-0x00000001814D3190
		internal static MemoryStream SerializeMessage(IMessage msg); // 0x00000001814D3340-0x00000001814D3440
		internal static object DeserializeObjectSafe(byte[] mem); // 0x00000001814D3190-0x00000001814D32A0
		internal static MemoryStream SerializeObject(object obj); // 0x00000001814D3440-0x00000001814D3540
		internal static object DeserializeObject(MemoryStream mem); // 0x00000001814D32A0-0x00000001814D3340
	}
}
