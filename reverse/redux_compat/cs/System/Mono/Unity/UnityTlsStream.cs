/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Net.Security;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Unity
{
	internal class UnityTlsStream : MobileAuthenticatedStream // TypeDefIndex: 8541
	{
		// Constructors
		public UnityTlsStream(Stream innerStream, bool leaveInnerStreamOpen, SslStream owner, MonoTlsSettings settings, MobileTlsProvider provider); // 0x0000000181827470-0x0000000181827630
	
		// Methods
		protected override MobileTlsContext CreateContext(MonoSslAuthenticationOptions options); // 0x0000000181827400-0x0000000181827470
	}
}
