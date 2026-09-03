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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	[Serializable]
	public class RegexMatchTimeoutException : TimeoutException, ISerializable // TypeDefIndex: 8713
	{
		// Fields
		[CompilerGenerated]
		private readonly string _Input_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly string _Pattern_k__BackingField; // 0x98
		[CompilerGenerated]
		private readonly TimeSpan _MatchTimeout_k__BackingField; // 0xA0
	
		// Properties
		public string Input { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public string Pattern { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public TimeSpan MatchTimeout { [CompilerGenerated] get; } // 0x00000001805B5990-0x00000001805B59A0 
	
		// Constructors
		public RegexMatchTimeoutException(string regexInput, string regexPattern, TimeSpan matchTimeout); // 0x0000000181B790E0-0x0000000181B79200
		public RegexMatchTimeoutException(); // 0x0000000181B79370-0x0000000181B79420
		protected RegexMatchTimeoutException(SerializationInfo info, StreamingContext context); // 0x0000000181B79200-0x0000000181B79370
	
		// Methods
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181B78FF0-0x0000000181B790E0
	}
}
