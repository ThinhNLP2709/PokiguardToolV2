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

namespace Mono.Btls
{
	internal class MonoBtlsStream : MobileAuthenticatedStream // TypeDefIndex: 8613
	{
		// Constructors
		public MonoBtlsStream(Stream innerStream, bool leaveInnerStreamOpen, SslStream owner, MonoTlsSettings settings, MobileTlsProvider provider); // 0x0000000181B4A9E0-0x0000000181B4AA70
	
		// Methods
		protected override MobileTlsContext CreateContext(MonoSslAuthenticationOptions options); // 0x0000000181B4A970-0x0000000181B4A9E0
	}
}
