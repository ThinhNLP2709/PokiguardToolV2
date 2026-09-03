/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Channels
{
	[Serializable]
	internal class CrossAppDomainChannel : IChannelSender, IChannelReceiver // TypeDefIndex: 2933
	{
		// Fields
		private static object s_lock; // 0x00
	
		// Properties
		public virtual string ChannelName { get; } // 0x00000001814D8580-0x00000001814D85B0 
		public virtual int ChannelPriority { get; } // 0x0000000180A326B0-0x0000000180A326C0 
		public virtual object ChannelData { get; } // 0x00000001814D84B0-0x00000001814D8580 
	
		// Constructors
		public CrossAppDomainChannel(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static CrossAppDomainChannel(); // 0x00000001814D8440-0x00000001814D84B0
	
		// Methods
		internal static void RegisterCrossAppDomainChannel(); // 0x00000001814D82E0-0x00000001814D8440
		public virtual void StartListening(object data); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual IMessageSink CreateMessageSink(string url, object data, out string uri); // 0x00000001814D8160-0x00000001814D82E0
	}
}
