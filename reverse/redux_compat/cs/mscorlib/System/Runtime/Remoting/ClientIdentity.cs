/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	internal class ClientIdentity : Identity // TypeDefIndex: 2878
	{
		// Fields
		private WeakReference _proxyReference; // 0x48
	
		// Properties
		public MarshalByRefObject ClientProxy { get; set; } // 0x00000001814B35A0-0x00000001814B3630 0x00000001814B3660-0x00000001814B36D0
		public string TargetUri { get; } // 0x00000001814B3630-0x00000001814B3660 
	
		// Constructors
		public ClientIdentity(string objectUri, ObjRef objRef); // 0x00000001814B34C0-0x00000001814B35A0
	
		// Methods
		public override ObjRef CreateObjRef(Type requestedType); // 0x00000001803272A0-0x00000001803272B0
	}
}
