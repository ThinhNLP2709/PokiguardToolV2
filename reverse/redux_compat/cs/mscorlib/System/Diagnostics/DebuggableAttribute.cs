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

namespace System.Diagnostics
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module, AllowMultiple = false)]
	[ComVisible(true)]
	public sealed class DebuggableAttribute : Attribute // TypeDefIndex: 3462
	{
		// Fields
		private DebuggingModes m_debuggingModes; // 0x10
	
		// Nested types
		[ComVisible(true)]
		[Flags]
		public enum DebuggingModes // TypeDefIndex: 3463
		{
			None = 0,
			Default = 1,
			IgnoreSymbolStoreSequencePoints = 2,
			EnableEditAndContinue = 4,
			DisableOptimizations = 256
		}
	
		// Constructors
		public DebuggableAttribute(bool isJITTrackingEnabled, bool isJITOptimizerDisabled); // 0x0000000181598D50-0x0000000181598DA0
		public DebuggableAttribute(DebuggingModes modes); // 0x0000000181380310-0x0000000181380340
	}
}
