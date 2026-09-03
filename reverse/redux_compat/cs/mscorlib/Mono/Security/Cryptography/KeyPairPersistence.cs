/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security.Cryptography
{
	internal class KeyPairPersistence // TypeDefIndex: 2126
	{
		// Fields
		private static bool _userPathExists; // 0x00
		private static string _userPath; // 0x08
		private static bool _machinePathExists; // 0x10
		private static string _machinePath; // 0x18
		private CspParameters _params; // 0x10
		private string _keyvalue; // 0x18
		private string _filename; // 0x20
		private string _container; // 0x28
		private static object lockobj; // 0x20
	
		// Properties
		public string Filename { get; } // 0x000000018144A3C0-0x000000018144A6A0 
		public string KeyValue { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x000000018144B000-0x000000018144B020
		private static string UserPath { get; } // 0x000000018144AB70-0x000000018144B000 
		private static string MachinePath { get; } // 0x000000018144A6A0-0x000000018144AB30 
		private bool CanChange { get; } // 0x000000018144A260-0x000000018144A270 
		private bool UseDefaultKeyContainer { get; } // 0x000000018144AB30-0x000000018144AB50 
		private bool UseMachineKeyStore { get; } // 0x000000018144AB50-0x000000018144AB70 
		private string ContainerName { get; } // 0x000000018144A270-0x000000018144A3C0 
	
		// Constructors
		public KeyPairPersistence(CspParameters parameters); // 0x000000018144A130-0x000000018144A260
		public KeyPairPersistence(CspParameters parameters, string keyPair); // 0x000000018144A000-0x000000018144A130
		static KeyPairPersistence(); // 0x0000000181449F90-0x000000018144A000
	
		// Methods
		public bool Load(); // 0x0000000181449710-0x00000001814499A0
		public void Save(); // 0x0000000181449BA0-0x0000000181449D80
		public void Remove(); // 0x0000000181449B80-0x0000000181449BA0
		internal static unsafe bool _CanSecure(char* root); // 0x0000000181449F80-0x0000000181449F90
		internal static unsafe bool _ProtectUser(char* path); // 0x0000000181449F80-0x0000000181449F90
		internal static unsafe bool _ProtectMachine(char* path); // 0x0000000181449F80-0x0000000181449F90
		internal static unsafe bool _IsUserProtected(char* path); // 0x0000000181449F80-0x0000000181449F90
		internal static unsafe bool _IsMachineProtected(char* path); // 0x0000000181449F80-0x0000000181449F90
		private static bool CanSecure(string path); // 0x0000000181449280-0x0000000181449310
		private static bool ProtectUser(string path); // 0x0000000181449A90-0x0000000181449B80
		private static bool ProtectMachine(string path); // 0x00000001814499A0-0x0000000181449A90
		private static bool IsUserProtected(string path); // 0x0000000181449620-0x0000000181449710
		private static bool IsMachineProtected(string path); // 0x0000000181449530-0x0000000181449620
		private CspParameters Copy(CspParameters p); // 0x0000000181449310-0x00000001814493C0
		private void FromXml(string xml); // 0x00000001814493C0-0x0000000181449530
		private string ToXml(); // 0x0000000181449D80-0x0000000181449F80
	}
}
