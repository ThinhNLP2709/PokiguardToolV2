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
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Proxies
{
	[AttributeUsage(AttributeTargets.Class)]
	[ComVisible(true)]
	public class ProxyAttribute : Attribute, IContextAttribute // TypeDefIndex: 2903
	{
		// Methods
		public virtual MarshalByRefObject CreateInstance(Type serverType); // 0x00000001814BD260-0x00000001814BD380
		public virtual RealProxy CreateProxy(ObjRef objRef, Type serverType, object serverObject, Context serverContext); // 0x00000001814BD380-0x00000001814BD3F0
		[ComVisible(true)]
		public void GetPropertiesForNewContext(IConstructionCallMessage msg); // 0x00000001802E76C0-0x00000001802E76D0
		[ComVisible(true)]
		public bool IsContextOK(Context ctx, IConstructionCallMessage msg); // 0x00000001802E7990-0x00000001802E79A0
	}
}
