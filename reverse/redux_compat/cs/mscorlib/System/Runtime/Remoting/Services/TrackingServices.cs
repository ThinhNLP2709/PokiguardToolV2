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
using System.Runtime.Remoting;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Services
{
	[ComVisible(true)]
	public class TrackingServices // TypeDefIndex: 2902
	{
		// Fields
		private static ArrayList _handlers; // 0x00
	
		// Constructors
		static TrackingServices(); // 0x00000001814C8FD0-0x00000001814C9050
	
		// Methods
		internal static void NotifyMarshaledObject(object obj, ObjRef or); // 0x00000001814C8980-0x00000001814C8CA0
		internal static void NotifyUnmarshaledObject(object obj, ObjRef or); // 0x00000001814C8CA0-0x00000001814C8FD0
		internal static void NotifyDisconnectedObject(object obj); // 0x00000001814C8660-0x00000001814C8980
	}
}
