/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Lifetime
{
	[ComVisible(true)]
	public sealed class LifetimeServices // TypeDefIndex: 2914
	{
		// Fields
		private static TimeSpan _leaseManagerPollTime; // 0x00
		private static TimeSpan _leaseTime; // 0x08
		private static TimeSpan _renewOnCallTime; // 0x10
		private static TimeSpan _sponsorshipTimeout; // 0x18
		private static LeaseManager _leaseManager; // 0x20
	
		// Properties
		public static TimeSpan LeaseManagerPollTime { get; set; } // 0x00000001814BBC40-0x00000001814BBC90 0x00000001814BBD80-0x00000001814BBE00
		public static TimeSpan LeaseTime { get; set; } // 0x00000001814BBC90-0x00000001814BBCE0 0x00000001814BBE00-0x00000001814BBE60
		public static TimeSpan RenewOnCallTime { get; set; } // 0x00000001814BBCE0-0x00000001814BBD30 0x00000001814BBE60-0x00000001814BBEC0
		public static TimeSpan SponsorshipTimeout { get; set; } // 0x00000001814BBD30-0x00000001814BBD80 0x00000001814BBEC0-0x00000001814BBF20
	
		// Constructors
		static LifetimeServices(); // 0x00000001814BBAD0-0x00000001814BBC40
	
		// Methods
		internal static void TrackLifetime(ServerIdentity identity); // 0x00000001814BBA60-0x00000001814BBAD0
	}
}
