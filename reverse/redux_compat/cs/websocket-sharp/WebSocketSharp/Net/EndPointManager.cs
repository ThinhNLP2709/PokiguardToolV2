/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal sealed class EndPointManager // TypeDefIndex: 13273
	{
		// Fields
		private static readonly Dictionary<IPEndPoint, EndPointListener> _endpoints; // 0x00
	
		// Constructors
		static EndPointManager(); // 0x00000001825F57C0-0x00000001825F5850
		private EndPointManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private static void addPrefix(string uriPrefix, HttpListener listener); // 0x00000001825F5850-0x00000001825F5E60
		private static IPAddress convertToIPAddress(string hostname); // 0x00000001825F5E60-0x00000001825F5F30
		private static void removePrefix(string uriPrefix, HttpListener listener); // 0x00000001825F5F30-0x00000001825F6150
		internal static bool RemoveEndPoint(IPEndPoint endpoint); // 0x00000001825F5200-0x00000001825F5340
		public static void AddListener(HttpListener listener); // 0x00000001825F4BA0-0x00000001825F50F0
		public static void AddPrefix(string uriPrefix, HttpListener listener); // 0x00000001825F50F0-0x00000001825F5200
		public static void RemoveListener(HttpListener listener); // 0x00000001825F5340-0x00000001825F56B0
		public static void RemovePrefix(string uriPrefix, HttpListener listener); // 0x00000001825F56B0-0x00000001825F57C0
	}
}
