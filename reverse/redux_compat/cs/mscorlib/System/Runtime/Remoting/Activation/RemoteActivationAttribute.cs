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
using System.Runtime.Remoting.Contexts;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Activation
{
	internal class RemoteActivationAttribute : Attribute, IContextAttribute // TypeDefIndex: 2953
	{
		// Fields
		private IList _contextProperties; // 0x10
	
		// Constructors
		public RemoteActivationAttribute(IList contextProperties); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		public bool IsContextOK(Context ctx, IConstructionCallMessage ctor); // 0x00000001802E7840-0x00000001802E7850
		public void GetPropertiesForNewContext(IConstructionCallMessage ctor); // 0x00000001814E97C0-0x00000001814E9AE0
	}
}
