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
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Activation
{
	[ComVisible(true)]
	public interface IConstructionCallMessage : IMethodCallMessage // TypeDefIndex: 2951
	{
		// Properties
		Type ActivationType { get; }
		string ActivationTypeName { get; }
		IActivator Activator { get; set; }
		object[] CallSiteActivationAttributes { get; }
		IList ContextProperties { get; }
	}
}
