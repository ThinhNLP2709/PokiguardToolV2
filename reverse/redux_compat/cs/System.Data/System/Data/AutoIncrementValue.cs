/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal abstract class AutoIncrementValue // TypeDefIndex: 11189
	{
		// Fields
		[CompilerGenerated]
		private bool _Auto_k__BackingField; // 0x10
	
		// Properties
		internal bool Auto { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		internal abstract object Current { get; set; }
		internal abstract long Seed { get; set; }
		internal abstract long Step { get; set; }
		internal abstract Type DataType { get; }
	
		// Constructors
		protected AutoIncrementValue(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal abstract void SetCurrent(object value, IFormatProvider formatProvider);
		internal abstract void SetCurrentAndIncrement(object value);
		internal abstract void MoveAfter();
		internal AutoIncrementValue Clone(); // 0x0000000181842920-0x0000000181842A60
	}
}
