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

namespace System.Runtime.Remoting.Contexts
{
	[ComVisible(true)]
	public interface IContextProperty // TypeDefIndex: 2923
	{
		// Properties
		string Name { get; }
	
		// Methods
		void Freeze(Context newContext);
		bool IsNewContextOK(Context newCtx);
	}
}
