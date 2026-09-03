/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using Mono;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Proxies
{
	internal class TransparentProxy // TypeDefIndex: 2904
	{
		// Fields
		public RealProxy _rp; // 0x10
		private RuntimeRemoteClassHandle _class; // 0x18
		private bool _custom_type_info; // 0x20
	
		// Properties
		private bool IsContextBoundObject { get; } // 0x00000001814C9840-0x00000001814C98E0 
		private Context TargetContext { get; } // 0x00000001814C98E0-0x00000001814C9900 
	
		// Constructors
		public TransparentProxy(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal RuntimeType GetProxyType(); // 0x00000001814C9050-0x00000001814C90F0
		private bool InCurrentContext(); // 0x00000001814C90F0-0x00000001814C91D0
		internal object LoadRemoteFieldNew(IntPtr classPtr, IntPtr fieldPtr); // 0x00000001814C91D0-0x00000001814C9500
		internal void StoreRemoteField(IntPtr classPtr, IntPtr fieldPtr, object arg); // 0x00000001814C9500-0x00000001814C9840
	}
}
