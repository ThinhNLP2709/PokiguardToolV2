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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Channels
{
	[ComVisible(true)]
	public sealed class ChannelServices // TypeDefIndex: 2931
	{
		// Fields
		private static ArrayList registeredChannels; // 0x00
		private static ArrayList delayedClientChannels; // 0x08
		private static CrossContextChannel _crossContextSink; // 0x10
		internal static string CrossContextUrl; // 0x18
		private static IList oldStartModeTypes; // 0x20
	
		// Properties
		internal static CrossContextChannel CrossContextChannel { get; } // 0x00000001814D63D0-0x00000001814D6420 
	
		// Constructors
		static ChannelServices(); // 0x00000001814D61D0-0x00000001814D63D0
	
		// Methods
		internal static IMessageSink CreateClientChannelSinkChain(string url, object remoteChannelData, out string objectUri); // 0x00000001814D3D80-0x00000001814D43C0
		internal static IMessageSink CreateClientChannelSinkChain(IChannelSender sender, string url, object[] channelDataArray, out string objectUri); // 0x00000001814D3C60-0x00000001814D3D80
		[Obsolete("Use RegisterChannel(IChannel,Boolean)")]
		public static void RegisterChannel(IChannel chnl); // 0x00000001814D5F40-0x00000001814D5F90
		public static void RegisterChannel(IChannel chnl, bool ensureSecurity); // 0x00000001814D58C0-0x00000001814D5F40
		internal static void RegisterChannelConfig(ChannelData channel); // 0x00000001814D4A80-0x00000001814D58C0
		private static object CreateProvider(ProviderData prov); // 0x00000001814D43C0-0x00000001814D46E0
		public static IMessage SyncDispatchMessage(IMessage msg); // 0x00000001814D5F90-0x00000001814D61D0
		private static ReturnMessage CheckIncomingMessage(IMessage msg); // 0x00000001814D3920-0x00000001814D3B00
		internal static IMessage CheckReturnMessage(IMessage callMsg, IMessage retMsg); // 0x00000001814D3B00-0x00000001814D3C60
		private static bool IsLocalCall(IMessage callMsg); // 0x00000001802E7990-0x00000001802E79A0
		internal static object[] GetCurrentChannelInfo(); // 0x00000001814D46E0-0x00000001814D4A80
	}
}
