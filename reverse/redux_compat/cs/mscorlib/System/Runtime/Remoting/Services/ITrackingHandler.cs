/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	public interface ITrackingHandler // TypeDefIndex: 2901
	{
		// Methods
		void DisconnectedObject(object obj);
		void MarshaledObject(object obj, ObjRef or);
		void UnmarshaledObject(object obj, ObjRef or);
	}
}
