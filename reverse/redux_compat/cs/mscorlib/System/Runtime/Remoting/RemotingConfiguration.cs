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
	[ComVisible(true)]
	public static class RemotingConfiguration // TypeDefIndex: 2881
	{
		// Fields
		private static string applicationID; // 0x00
		private static string applicationName; // 0x08
		private static string processGuid; // 0x10
		private static bool defaultConfigRead; // 0x18
		private static bool defaultDelayedConfigRead; // 0x19
		private static CustomErrorsModes _errorMode; // 0x1C
		private static Hashtable wellKnownClientEntries; // 0x20
		private static Hashtable activatedClientEntries; // 0x28
		private static Hashtable wellKnownServiceEntries; // 0x30
		private static Hashtable activatedServiceEntries; // 0x38
		private static Hashtable channelTemplates; // 0x40
		private static Hashtable clientProviderTemplates; // 0x48
		private static Hashtable serverProviderTemplates; // 0x50
	
		// Properties
		public static string ApplicationName { get; set; } // 0x00000001814C0C20-0x00000001814C0C70 0x00000001814C0D10-0x00000001814C0D80
		public static string ProcessId { get; } // 0x00000001814C0C70-0x00000001814C0D10 
	
		// Constructors
		static RemotingConfiguration(); // 0x00000001814C0950-0x00000001814C0C20
	
		// Methods
		internal static void LoadDefaultDelayedChannels(); // 0x00000001814BED70-0x00000001814BF0A0
		public static bool IsActivationAllowed(Type svrType); // 0x00000001814BE940-0x00000001814BEA70
		public static ActivatedClientTypeEntry IsRemotelyActivatedClientType(Type svrType); // 0x00000001814BEA70-0x00000001814BEBF0
		public static WellKnownClientTypeEntry IsWellKnownClientType(Type svrType); // 0x00000001814BEBF0-0x00000001814BED70
		public static void RegisterActivatedClientType(ActivatedClientTypeEntry entry); // 0x00000001814BF0A0-0x00000001814BF300
		public static void RegisterActivatedServiceType(ActivatedServiceTypeEntry entry); // 0x00000001814BF300-0x00000001814BF430
		public static void RegisterWellKnownClientType(WellKnownClientTypeEntry entry); // 0x00000001814C0350-0x00000001814C05B0
		public static void RegisterWellKnownServiceType(WellKnownServiceTypeEntry entry); // 0x00000001814C05B0-0x00000001814C0730
		internal static void RegisterChannelTemplate(ChannelData channel); // 0x00000001814BF430-0x00000001814BF4B0
		internal static void RegisterClientProviderTemplate(ProviderData prov); // 0x00000001814BFDB0-0x00000001814BFE30
		internal static void RegisterServerProviderTemplate(ProviderData prov); // 0x00000001814BFE30-0x00000001814BFEB0
		internal static void RegisterChannels(ArrayList channels, bool onlyDelayed); // 0x00000001814BF4B0-0x00000001814BFDB0
		internal static void RegisterTypes(ArrayList types); // 0x00000001814BFEB0-0x00000001814C0350
		public static bool CustomErrorsEnabled(bool isLocalRequest); // 0x00000001814BE8D0-0x00000001814BE940
		internal static void SetCustomErrorsMode(string mode); // 0x00000001814C0730-0x00000001814C0950
	}
}
