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

namespace System
{
	[ComVisible(true)]
	public static class Environment // TypeDefIndex: 2443
	{
		// Fields
		private const string mono_corlib_version = "1A5E0066-58DC-428A-B21C-0AD6CDAE2789"; // Metadata: 0x0064E6A1
		private static string nl; // 0x00
		private static OperatingSystem os; // 0x08
	
		// Properties
		public static string CurrentDirectory { get; } // 0x0000000181651F50-0x0000000181651F60 
		public static int CurrentManagedThreadId { get; } // 0x0000000181651F60-0x0000000181651F90 
		public static bool HasShutdownStarted { get; } // 0x0000000181651F90-0x0000000181651FA0 
		public static string MachineName { get; } // 0x0000000181651FF0-0x0000000181652000 
		public static string NewLine { get; } // 0x0000000181652000-0x0000000181652080 
		internal static PlatformID Platform { [CompilerGenerated] get; } // 0x0000000181652310-0x0000000181652320 
		public static OperatingSystem OSVersion { get; } // 0x0000000181652080-0x0000000181652310 
		public static string StackTrace { get; } // 0x0000000181652330-0x00000001816523A0 
		public static string SystemDirectory { get; } // 0x00000001816523A0-0x0000000181652600 
		public static int TickCount { get; } // 0x0000000181652600-0x0000000181652610 
		public static string UserDomainName { get; } // 0x0000000181651FF0-0x0000000181652000 
		public static string UserName { get; } // 0x0000000181652610-0x0000000181652620 
		public static int ProcessorCount { get; } // 0x0000000181652320-0x0000000181652330 
		internal static bool IsRunningOnWindows { get; } // 0x0000000181651FA0-0x0000000181651FC0 
		internal static bool IsUnix { get; } // 0x0000000181651FC0-0x0000000181651FF0 
	
		// Nested types
		[ComVisible(true)]
		public enum SpecialFolder // TypeDefIndex: 2444
		{
			Desktop = 0,
			Programs = 2,
			MyDocuments = 5,
			Personal = 5,
			Favorites = 6,
			Startup = 7,
			Recent = 8,
			SendTo = 9,
			StartMenu = 11,
			MyMusic = 13,
			MyVideos = 14,
			DesktopDirectory = 16,
			MyComputer = 17,
			NetworkShortcuts = 19,
			Fonts = 20,
			Templates = 21,
			CommonStartMenu = 22,
			CommonPrograms = 23,
			CommonStartup = 24,
			CommonDesktopDirectory = 25,
			ApplicationData = 26,
			PrinterShortcuts = 27,
			LocalApplicationData = 28,
			InternetCache = 32,
			Cookies = 33,
			History = 34,
			CommonApplicationData = 35,
			Windows = 36,
			System = 37,
			ProgramFiles = 38,
			MyPictures = 39,
			UserProfile = 40,
			SystemX86 = 41,
			ProgramFilesX86 = 42,
			CommonProgramFiles = 43,
			CommonProgramFilesX86 = 44,
			CommonTemplates = 45,
			CommonDocuments = 46,
			CommonAdminTools = 47,
			AdminTools = 48,
			CommonMusic = 53,
			CommonPictures = 54,
			CommonVideos = 55,
			Resources = 56,
			LocalizedResources = 57,
			CommonOemLinks = 58,
			CDBurning = 59
		}
	
		public enum SpecialFolderOption // TypeDefIndex: 2445
		{
			None = 0,
			DoNotVerify = 16384,
			Create = 32768
		}
	
		// Methods
		internal static string GetResourceString(string key); // 0x0000000180370C60-0x0000000180370C70
		internal static string GetResourceString(string key, params object[] values); // 0x00000001814338D0-0x0000000181433920
		internal static string GetResourceStringEncodingName(int codePage); // 0x00000001816514D0-0x0000000181651610
		private static string GetNewLine(); // 0x00000001816514A0-0x00000001816514B0
		internal static string GetOSVersionString(); // 0x00000001816514B0-0x00000001816514C0
		internal static Version CreateVersionFromString(string info); // 0x0000000181650D40-0x0000000181650EE0
		public static void Exit(int exitCode); // 0x0000000181650EE0-0x0000000181650EF0
		public static string ExpandEnvironmentVariables(string name); // 0x0000000181650EF0-0x00000001816512C0
		public static string[] GetCommandLineArgs(); // 0x00000001816512E0-0x00000001816512F0
		internal static string internalGetEnvironmentVariable_native(IntPtr variable); // 0x00000001816526E0-0x00000001816526F0
		internal static string internalGetEnvironmentVariable(string variable); // 0x0000000181652620-0x00000001816526E0
		public static string GetEnvironmentVariable(string variable); // 0x0000000181651300-0x0000000181651310
		private static Hashtable GetEnvironmentVariablesNoCase(); // 0x0000000181651310-0x0000000181651400
		public static string GetFolderPath(SpecialFolder folder); // 0x0000000181651400-0x0000000181651440
		private static string GetWindowsFolderPath(int folder); // 0x00000001816516A0-0x00000001816516B0
		public static string GetFolderPath(SpecialFolder folder, SpecialFolderOption option); // 0x0000000181651440-0x0000000181651490
		private static string ReadXdgUserDir(string config_dir, string home_dir, string key, string fallback); // 0x00000001816516B0-0x00000001816519B0
		internal static string UnixGetFolderPath(SpecialFolder folder, SpecialFolderOption option); // 0x00000001816519B0-0x0000000181651F50
		public static void FailFast(string message, Exception exception); // 0x00000001816512C0-0x00000001816512D0
		internal static void FailFast(string message, Exception exception, string errorSource); // 0x00000001816512D0-0x00000001816512E0
		private static string[] GetEnvironmentVariableNames(); // 0x00000001816512F0-0x0000000181651300
		internal static string GetMachineConfigPath(); // 0x0000000181651490-0x00000001816514A0
		internal static string internalGetHome(); // 0x00000001816526F0-0x0000000181652700
		internal static int GetPageSize(); // 0x00000001816514C0-0x00000001816514D0
		internal static string GetStackTrace(Exception e, bool needFileInfo); // 0x0000000181651610-0x00000001816516A0
	}
}
