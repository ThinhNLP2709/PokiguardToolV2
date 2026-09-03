/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class AutoIncrementInt64 : AutoIncrementValue // TypeDefIndex: 11190
	{
		// Fields
		private long _current; // 0x18
		private long _seed; // 0x20
		private long _step; // 0x28
	
		// Properties
		internal override object Current { get; set; } // 0x0000000181842750-0x0000000181842780 0x00000001818427C0-0x0000000181842800
		internal override Type DataType { get; } // 0x0000000181842780-0x00000001818427C0 
		internal override long Seed { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181842800-0x0000000181842890
		internal override long Step { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181842890-0x0000000181842920
	
		// Constructors
		public AutoIncrementInt64(); // 0x0000000181842740-0x0000000181842750
	
		// Methods
		internal override void MoveAfter(); // 0x00000001818425A0-0x00000001818425B0
		internal override void SetCurrent(object value, IFormatProvider formatProvider); // 0x00000001818426D0-0x0000000181842740
		internal override void SetCurrentAndIncrement(object value); // 0x00000001818425B0-0x00000001818426D0
		private bool BoundaryCheck(BigInteger value); // 0x00000001818424B0-0x00000001818425A0
	}
}
