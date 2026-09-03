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

namespace System.Text
{
	public abstract class EncodingProvider // TypeDefIndex: 2715
	{
		// Fields
		private static object s_InternalSyncObject; // 0x00
		private static EncodingProvider[] s_providers; // 0x08
	
		// Constructors
		static EncodingProvider(); // 0x00000001814654D0-0x0000000181465540
	
		// Methods
		public abstract Encoding GetEncoding(string name);
		public abstract Encoding GetEncoding(int codepage);
		public virtual Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback); // 0x00000001814653B0-0x00000001814654D0
		internal static Encoding GetEncodingFromProvider(int codepage); // 0x00000001814651D0-0x00000001814652C0
		internal static Encoding GetEncodingFromProvider(string encodingName); // 0x00000001814652C0-0x00000001814653B0
		internal static Encoding GetEncodingFromProvider(int codepage, EncoderFallback enc, DecoderFallback dec); // 0x00000001814650D0-0x00000001814651D0
	}
}
