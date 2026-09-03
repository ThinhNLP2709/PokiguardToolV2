/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public static class Dns // TypeDefIndex: 9122
	{
		// Nested types
		private delegate IPAddress[] GetHostAddressesCallback(string hostName); // TypeDefIndex: 9123; 0x00000001804A78A0-0x00000001804A78B0
	
		// Methods
		public static IAsyncResult BeginGetHostAddresses(string hostNameOrAddress, AsyncCallback requestCallback, object state); // 0x0000000181C07780-0x0000000181C079A0
		public static IPAddress[] EndGetHostAddresses(IAsyncResult asyncResult); // 0x0000000181C079A0-0x0000000181C07AA0
		private static bool GetHostByName_icall(string host, out string h_name, out string[] h_aliases, out string[] h_addr_list, int hint); // 0x0000000181C07F70-0x0000000181C07F80
		private static bool GetHostByAddr_icall(string addr, out string h_name, out string[] h_aliases, out string[] h_addr_list, int hint); // 0x0000000181C07E30-0x0000000181C07E40
		private static bool GetHostName_icall(out string h_name); // 0x0000000181C08510-0x0000000181C08520
		private static void Error_11001(string hostName); // 0x0000000181C07AA0-0x0000000181C07B10
		private static IPHostEntry hostent_to_IPHostEntry(string originalHostName, string h_name, string[] h_aliases, string[] h_addrlist); // 0x0000000181C08560-0x0000000181C08860
		private static IPHostEntry GetHostByAddressFromString(string address, bool parse); // 0x0000000181C07E40-0x0000000181C07F70
		public static IPHostEntry GetHostEntry(string hostNameOrAddress); // 0x0000000181C08080-0x0000000181C083B0
		public static IPHostEntry GetHostEntry(IPAddress address); // 0x0000000181C083B0-0x0000000181C08510
		public static IPAddress[] GetHostAddresses(string hostNameOrAddress); // 0x0000000181C07C20-0x0000000181C07E30
		[Obsolete("Use GetHostEntry instead")]
		public static IPHostEntry GetHostByName(string hostName); // 0x0000000181C07F80-0x0000000181C08080
		public static string GetHostName(); // 0x0000000181C08520-0x0000000181C08560
		public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress); // 0x0000000181C07B10-0x0000000181C07C20
	}
}
