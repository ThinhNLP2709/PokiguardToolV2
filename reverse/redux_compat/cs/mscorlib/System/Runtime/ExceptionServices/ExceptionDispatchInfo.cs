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

namespace System.Runtime.ExceptionServices
{
	public sealed class ExceptionDispatchInfo // TypeDefIndex: 3172
	{
		// Fields
		private Exception m_Exception; // 0x10
		private object m_stackTrace; // 0x18
	
		// Properties
		internal object BinaryStackTraceArray { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Exception SourceException { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		private ExceptionDispatchInfo(Exception exception); // 0x000000018150BE20-0x000000018150BF90
	
		// Methods
		public static ExceptionDispatchInfo Capture(Exception source); // 0x000000018150BB90-0x000000018150BDA0
		[StackTraceHidden]
		public void Throw(); // 0x000000018150BDA0-0x000000018150BDF0
		[StackTraceHidden]
		public static void Throw(Exception source); // 0x000000018150BDF0-0x000000018150BE20
	}
}
