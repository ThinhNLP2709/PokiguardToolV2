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
	internal sealed class AutoIncrementBigInteger : AutoIncrementValue // TypeDefIndex: 11191
	{
		// Fields
		private BigInteger _current; // 0x18
		private long _seed; // 0x28
		private BigInteger _step; // 0x30
	
		// Properties
		internal override object Current { get; set; } // 0x00000001818420F0-0x0000000181842140 0x00000001818421E0-0x0000000181842260
		internal override Type DataType { get; } // 0x0000000181842140-0x0000000181842180 
		internal override long Seed { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181842260-0x0000000181842340
		internal override long Step { get; set; } // 0x0000000181842180-0x00000001818421E0 0x0000000181842340-0x00000001818424B0
	
		// Constructors
		public AutoIncrementBigInteger(); // 0x0000000181842080-0x00000001818420F0
	
		// Methods
		internal override void MoveAfter(); // 0x0000000181841ED0-0x0000000181841F60
		internal override void SetCurrent(object value, IFormatProvider formatProvider); // 0x0000000181842050-0x0000000181842080
		internal override void SetCurrentAndIncrement(object value); // 0x0000000181841F60-0x0000000181842050
		private bool BoundaryCheck(BigInteger value); // 0x0000000181841DD0-0x0000000181841ED0
	}
}
