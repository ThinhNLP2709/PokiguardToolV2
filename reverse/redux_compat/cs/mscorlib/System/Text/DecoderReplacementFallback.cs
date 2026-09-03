/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Text
{
	[Serializable]
	public sealed class DecoderReplacementFallback : DecoderFallback, ISerializable // TypeDefIndex: 2701
	{
		// Fields
		private string _strDefault; // 0x10
	
		// Properties
		public string DefaultString { get; } // 0x0000000180377550-0x0000000180377560 
		public override int MaxCharCount { get; } // 0x0000000181463040-0x0000000181463060 
	
		// Constructors
		public DecoderReplacementFallback(); // 0x000000018167FE10-0x000000018167FFC0
		internal DecoderReplacementFallback(SerializationInfo info, StreamingContext context); // 0x000000018167FFC0-0x0000000181680080
		public DecoderReplacementFallback(string replacement); // 0x0000000181680080-0x0000000181680210
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018167FDB0-0x000000018167FE10
		public override DecoderFallbackBuffer CreateFallbackBuffer(); // 0x000000018167FCC0-0x000000018167FD40
		public override bool Equals(object value); // 0x000000018167FD40-0x000000018167FDB0
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
	}
}
