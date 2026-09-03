/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	internal class ChannelData // TypeDefIndex: 2883
	{
		// Fields
		internal string Ref; // 0x10
		internal string Type; // 0x18
		internal string Id; // 0x20
		internal string DelayLoadAsClientChannel; // 0x28
		private ArrayList _serverProviders; // 0x30
		private ArrayList _clientProviders; // 0x38
		private Hashtable _customProperties; // 0x40
	
		// Properties
		internal ArrayList ServerProviders { get; } // 0x00000001814AEAD0-0x00000001814AEB40 
		public ArrayList ClientProviders { get; } // 0x00000001814AE9F0-0x00000001814AEA60 
		public Hashtable CustomProperties { get; } // 0x00000001814AEA60-0x00000001814AEAD0 
	
		// Constructors
		public ChannelData(); // 0x00000001814AE920-0x00000001814AE9F0
	
		// Methods
		public void CopyFrom(ChannelData other); // 0x00000001814ADFA0-0x00000001814AE920
	}
}
