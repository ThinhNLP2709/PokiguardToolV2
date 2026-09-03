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

namespace System.Runtime.Remoting.Activation
{
	internal class AppDomainLevelActivator : IActivator // TypeDefIndex: 2947
	{
		// Fields
		private string _activationUrl; // 0x10
		private IActivator _next; // 0x18
	
		// Properties
		public IActivator NextActivator { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public AppDomainLevelActivator(string activationUrl, IActivator next); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		public IConstructionReturnMessage Activate(IConstructionCallMessage ctorCall); // 0x00000001814CF530-0x00000001814CF7E0
	}
}
