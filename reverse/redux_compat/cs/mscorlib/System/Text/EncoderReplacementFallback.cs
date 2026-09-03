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
	public sealed class EncoderReplacementFallback : EncoderFallback, ISerializable // TypeDefIndex: 2712
	{
		// Fields
		private string _strDefault; // 0x10
	
		// Properties
		public string DefaultString { get; } // 0x0000000180377550-0x0000000180377560 
		public override int MaxCharCount { get; } // 0x0000000181463040-0x0000000181463060 
	
		// Constructors
		public EncoderReplacementFallback(); // 0x0000000181462DB0-0x0000000181462DF0
		internal EncoderReplacementFallback(SerializationInfo info, StreamingContext context); // 0x0000000181462DF0-0x0000000181462EB0
		public EncoderReplacementFallback(string replacement); // 0x0000000181462EB0-0x0000000181463040
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181462D50-0x0000000181462DB0
		public override EncoderFallbackBuffer CreateFallbackBuffer(); // 0x0000000181462C50-0x0000000181462CE0
		public override bool Equals(object value); // 0x0000000181462CE0-0x0000000181462D50
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
	}
}
