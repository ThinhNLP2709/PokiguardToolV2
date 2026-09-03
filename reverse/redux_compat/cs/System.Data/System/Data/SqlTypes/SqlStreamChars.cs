/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	internal abstract class SqlStreamChars // TypeDefIndex: 11368
	{
		// Properties
		public abstract long Length { get; }
		public abstract long Position { get; }
	
		// Methods
		public abstract int Read(char[] buffer, int offset, int count);
		public abstract long Seek(long offset, SeekOrigin origin);
	}
}
