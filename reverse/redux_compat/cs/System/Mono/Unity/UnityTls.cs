/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Unity
{
	internal static class UnityTls // TypeDefIndex: 8483
	{
		// Fields
		private static unitytls_interface_struct marshalledInterface; // 0x00
	
		// Properties
		public static bool IsSupported { get; } // 0x0000000181827640-0x0000000181827660 
		public static unitytls_interface_struct NativeInterface { get; } // 0x0000000181827660-0x0000000181827730 
	
		// Nested types
		public enum unitytls_error_code : uint // TypeDefIndex: 8484
		{
			UNITYTLS_SUCCESS = 0,
			UNITYTLS_INVALID_ARGUMENT = 1,
			UNITYTLS_INVALID_FORMAT = 2,
			UNITYTLS_INVALID_PASSWORD = 3,
			UNITYTLS_INVALID_STATE = 4,
			UNITYTLS_BUFFER_OVERFLOW = 5,
			UNITYTLS_OUT_OF_MEMORY = 6,
			UNITYTLS_INTERNAL_ERROR = 7,
			UNITYTLS_NOT_SUPPORTED = 8,
			UNITYTLS_ENTROPY_SOURCE_FAILED = 9,
			UNITYTLS_STREAM_CLOSED = 10,
			UNITYTLS_DER_PARSE_ERROR = 11,
			UNITYTLS_KEY_PARSE_ERROR = 12,
			UNITYTLS_SSL_ERROR = 13,
			UNITYTLS_USER_CUSTOM_ERROR_START = 1048576,
			UNITYTLS_USER_WOULD_BLOCK = 1048577,
			UNITYTLS_USER_WOULD_BLOCK_READ = 1048578,
			UNITYTLS_USER_WOULD_BLOCK_WRITE = 1048579,
			UNITYTLS_USER_READ_FAILED = 1048580,
			UNITYTLS_USER_WRITE_FAILED = 1048581,
			UNITYTLS_USER_UNKNOWN_ERROR = 1048582,
			UNITYTLS_SSL_NEEDS_VERIFY = 1048583,
			UNITYTLS_HANDSHAKE_STEP = 1048584,
			UNITYTLS_USER_CUSTOM_ERROR_END = 2097152
		}
	
		public enum unitytls_log_level : uint // TypeDefIndex: 8485
		{
			UNITYTLS_LOGLEVEL_MIN = 0,
			UNITYTLS_LOGLEVEL_FATAL = 0,
			UNITYTLS_LOGLEVEL_ERROR = 1,
			UNITYTLS_LOGLEVEL_WARN = 2,
			UNITYTLS_LOGLEVEL_INFO = 3,
			UNITYTLS_LOGLEVEL_DEBUG = 4,
			UNITYTLS_LOGLEVEL_TRACE = 5,
			UNITYTLS_LOGLEVEL_MAX = 5
		}
	
		public struct unitytls_errorstate // TypeDefIndex: 8486
		{
			// Fields
			private uint magic; // 0x00
			public unitytls_error_code code; // 0x04
			private ulong reserved; // 0x08
		}
	
		public struct unitytls_key // TypeDefIndex: 8487
		{
		}
	
		public struct unitytls_key_ref // TypeDefIndex: 8488
		{
			// Fields
			public ulong handle; // 0x00
		}
	
		public struct unitytls_x509_ref // TypeDefIndex: 8489
		{
			// Fields
			public ulong handle; // 0x00
		}
	
		public struct unitytls_x509list // TypeDefIndex: 8490
		{
		}
	
		public struct unitytls_x509list_ref // TypeDefIndex: 8491
		{
			// Fields
			public ulong handle; // 0x00
		}
	
		[Flags]
		public enum unitytls_x509verify_result : uint // TypeDefIndex: 8492
		{
			UNITYTLS_X509VERIFY_SUCCESS = 0,
			UNITYTLS_X509VERIFY_FLAG_EXPIRED = 1,
			UNITYTLS_X509VERIFY_FLAG_REVOKED = 2,
			UNITYTLS_X509VERIFY_FLAG_CN_MISMATCH = 4,
			UNITYTLS_X509VERIFY_FLAG_NOT_TRUSTED = 8,
			UNITYTLS_X509VERIFY_FLAG_BADCRL_NOT_TRUSTED = 16,
			UNITYTLS_X509VERIFY_FLAG_BADCRL_EXPIRED = 32,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_MISSING = 64,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_SKIP_VERIFY = 128,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_OTHER = 256,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_FUTURE = 512,
			UNITYTLS_X509VERIFY_FLAG_BADCRL_FUTURE = 1024,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_KEY_USAGE = 2048,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_EXT_KEY_USAGE = 4096,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_NS_CERT_TYPE = 8192,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_BAD_MD = 16384,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_BAD_PK = 32768,
			UNITYTLS_X509VERIFY_FLAG_BADCERT_BAD_KEY = 65536,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR1 = 65536,
			UNITYTLS_X509VERIFY_FLAG_BADCRL_BAD_MD = 131072,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR2 = 131072,
			UNITYTLS_X509VERIFY_FLAG_BADCRL_BAD_PK = 262144,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR3 = 262144,
			UNITYTLS_X509VERIFY_FLAG_BADCRL_BAD_KEY = 524288,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR4 = 524288,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR5 = 1048576,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR6 = 2097152,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR7 = 4194304,
			UNITYTLS_X509VERIFY_FLAG_USER_ERROR8 = 8388608,
			UNITYTLS_X509VERIFY_FLAG_UNKNOWN_ERROR = 134217728,
			UNITYTLS_X509VERIFY_NOT_DONE = 2147483648,
			UNITYTLS_X509VERIFY_FATAL_ERROR = 4294967295
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate unitytls_x509verify_result unitytls_x509verify_callback(void* userData, unitytls_x509_ref cert, unitytls_x509verify_result result, unitytls_errorstate* errorState); // TypeDefIndex: 8493; 0x000000018043A200-0x000000018043A220
	
		public struct unitytls_tlsctx // TypeDefIndex: 8494
		{
		}
	
		public struct unitytls_x509name // TypeDefIndex: 8495
		{
		}
	
		public enum unitytls_ciphersuite : uint // TypeDefIndex: 8496
		{
			UNITYTLS_CIPHERSUITE_INVALID = 16777215
		}
	
		public enum unitytls_protocol : uint // TypeDefIndex: 8497
		{
			UNITYTLS_PROTOCOL_TLS_1_0 = 0,
			UNITYTLS_PROTOCOL_TLS_1_1 = 1,
			UNITYTLS_PROTOCOL_TLS_1_2 = 2,
			UNITYTLS_PROTOCOL_TLS_1_3 = 3,
			UNITYTLS_PROTOCOL_INVALID = 4
		}
	
		public struct unitytls_tlsctx_protocolrange // TypeDefIndex: 8498
		{
			// Fields
			public unitytls_protocol min; // 0x00
			public unitytls_protocol max; // 0x04
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate IntPtr unitytls_tlsctx_write_callback(void* userData, byte* data, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8499; 0x000000018043A200-0x000000018043A220
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate IntPtr unitytls_tlsctx_read_callback(void* userData, byte* buffer, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8500; 0x000000018043A200-0x000000018043A220
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void unitytls_tlsctx_trace_callback(void* userData, unitytls_tlsctx* ctx, byte* traceMessage, IntPtr traceMessageLen); // TypeDefIndex: 8501; 0x000000018043A200-0x000000018043A220
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void unitytls_tlsctx_certificate_callback(void* userData, unitytls_tlsctx* ctx, byte* cn, IntPtr cnLen, unitytls_x509name* caList, IntPtr caListLen, unitytls_x509list_ref* chain, unitytls_key_ref* key, unitytls_errorstate* errorState); // TypeDefIndex: 8502; 0x0000000181828BB0-0x0000000181828C20
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate unitytls_x509verify_result unitytls_tlsctx_x509verify_callback(void* userData, unitytls_x509list_ref chain, unitytls_errorstate* errorState); // TypeDefIndex: 8503; 0x0000000180A72B30-0x0000000180A72B50
	
		public struct unitytls_tlsctx_callbacks // TypeDefIndex: 8504
		{
			// Fields
			public unitytls_tlsctx_read_callback read; // 0x00
			public unitytls_tlsctx_write_callback write; // 0x08
			public unsafe void* data; // 0x10
		}
	
		public class unitytls_interface_struct // TypeDefIndex: 8505
		{
			// Fields
			public readonly ulong UNITYTLS_INVALID_HANDLE; // 0x10
			public readonly unitytls_tlsctx_protocolrange UNITYTLS_TLSCTX_PROTOCOLRANGE_DEFAULT; // 0x18
			public unitytls_errorstate_create_t unitytls_errorstate_create; // 0x20
			public unitytls_errorstate_raise_error_t unitytls_errorstate_raise_error; // 0x28
			public unitytls_key_get_ref_t unitytls_key_get_ref; // 0x30
			public unitytls_key_parse_der_t unitytls_key_parse_der; // 0x38
			public unitytls_key_parse_pem_t unitytls_key_parse_pem; // 0x40
			public unitytls_key_free_t unitytls_key_free; // 0x48
			public unitytls_x509_export_der_t unitytls_x509_export_der; // 0x50
			public unitytls_x509list_get_ref_t unitytls_x509list_get_ref; // 0x58
			public unitytls_x509list_get_x509_t unitytls_x509list_get_x509; // 0x60
			public unitytls_x509list_create_t unitytls_x509list_create; // 0x68
			public unitytls_x509list_append_t unitytls_x509list_append; // 0x70
			public unitytls_x509list_append_der_t unitytls_x509list_append_der; // 0x78
			public unitytls_x509list_append_der_t unitytls_x509list_append_pem; // 0x80
			public unitytls_x509list_free_t unitytls_x509list_free; // 0x88
			public unitytls_x509verify_default_ca_t unitytls_x509verify_default_ca; // 0x90
			public unitytls_x509verify_explicit_ca_t unitytls_x509verify_explicit_ca; // 0x98
			public unitytls_tlsctx_create_server_t unitytls_tlsctx_create_server; // 0xA0
			public unitytls_tlsctx_create_client_t unitytls_tlsctx_create_client; // 0xA8
			public unitytls_tlsctx_server_require_client_authentication_t unitytls_tlsctx_server_require_client_authentication; // 0xB0
			public unitytls_tlsctx_set_certificate_callback_t unitytls_tlsctx_set_certificate_callback; // 0xB8
			public unitytls_tlsctx_set_trace_callback_t unitytls_tlsctx_set_trace_callback; // 0xC0
			public unitytls_tlsctx_set_x509verify_callback_t unitytls_tlsctx_set_x509verify_callback; // 0xC8
			public unitytls_tlsctx_set_supported_ciphersuites_t unitytls_tlsctx_set_supported_ciphersuites; // 0xD0
			public unitytls_tlsctx_get_ciphersuite_t unitytls_tlsctx_get_ciphersuite; // 0xD8
			public unitytls_tlsctx_get_protocol_t unitytls_tlsctx_get_protocol; // 0xE0
			public unitytls_tlsctx_process_handshake_t unitytls_tlsctx_process_handshake; // 0xE8
			public unitytls_tlsctx_read_t unitytls_tlsctx_read; // 0xF0
			public unitytls_tlsctx_write_t unitytls_tlsctx_write; // 0xF8
			public unitytls_tlsctx_notify_close_t unitytls_tlsctx_notify_close; // 0x100
			public unitytls_tlsctx_free_t unitytls_tlsctx_free; // 0x108
			public unitytls_random_generate_bytes_t unitytls_random_generate_bytes; // 0x110
			public unitytls_x509verify_result_to_string_t unitytls_x509verify_result_to_string; // 0x118
			public unitytls_tlsctx_set_trace_level_t unitytls_tlsctx_set_trace_level; // 0x120
	
			// Nested types
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate unitytls_errorstate unitytls_errorstate_create_t(); // TypeDefIndex: 8506; 0x0000000180E68B70-0x0000000180E68BA0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_errorstate_raise_error_t(unitytls_errorstate* errorState, unitytls_error_code errorCode); // TypeDefIndex: 8507; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_key_ref unitytls_key_get_ref_t(unitytls_key* key, unitytls_errorstate* errorState); // TypeDefIndex: 8508; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_key* unitytls_key_parse_der_t(byte* buffer, IntPtr bufferLen, byte* password, IntPtr passwordLen, unitytls_errorstate* errorState); // TypeDefIndex: 8509; 0x000000018122C800-0x000000018122C820
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_key* unitytls_key_parse_pem_t(byte* buffer, IntPtr bufferLen, byte* password, IntPtr passwordLen, unitytls_errorstate* errorState); // TypeDefIndex: 8510; 0x000000018122C800-0x000000018122C820
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_key_free_t(unitytls_key* key); // TypeDefIndex: 8511; 0x00000001804A78A0-0x00000001804A78B0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate IntPtr unitytls_x509_export_der_t(unitytls_x509_ref cert, byte* buffer, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8512; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_x509list_ref unitytls_x509list_get_ref_t(unitytls_x509list* list, unitytls_errorstate* errorState); // TypeDefIndex: 8513; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_x509_ref unitytls_x509list_get_x509_t(unitytls_x509list_ref list, IntPtr index, unitytls_errorstate* errorState); // TypeDefIndex: 8514; 0x0000000180A72B30-0x0000000180A72B50
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_x509list* unitytls_x509list_create_t(unitytls_errorstate* errorState); // TypeDefIndex: 8515; 0x00000001804A78A0-0x00000001804A78B0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_x509list_append_t(unitytls_x509list* list, unitytls_x509_ref cert, unitytls_errorstate* errorState); // TypeDefIndex: 8516; 0x0000000180A72B30-0x0000000180A72B50
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_x509list_append_der_t(unitytls_x509list* list, byte* buffer, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8517; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_x509list_free_t(unitytls_x509list* list); // TypeDefIndex: 8518; 0x00000001804A78A0-0x00000001804A78B0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_x509verify_result unitytls_x509verify_default_ca_t(unitytls_x509list_ref chain, byte* cn, IntPtr cnLen, unitytls_x509verify_callback cb, void* userData, unitytls_errorstate* errorState); // TypeDefIndex: 8519; 0x0000000180ED8BF0-0x0000000180ED8C10
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_x509verify_result unitytls_x509verify_explicit_ca_t(unitytls_x509list_ref chain, unitytls_x509list_ref trustCA, byte* cn, IntPtr cnLen, unitytls_x509verify_callback cb, void* userData, unitytls_errorstate* errorState); // TypeDefIndex: 8520; 0x00000001818295E0-0x0000000181829600
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_tlsctx* unitytls_tlsctx_create_server_t(unitytls_tlsctx_protocolrange supportedProtocols, unitytls_tlsctx_callbacks callbacks, ulong certChain, ulong leafCertificateKey, unitytls_errorstate* errorState); // TypeDefIndex: 8521; 0x0000000181828D00-0x0000000181828D60
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_tlsctx* unitytls_tlsctx_create_client_t(unitytls_tlsctx_protocolrange supportedProtocols, unitytls_tlsctx_callbacks callbacks, byte* cn, IntPtr cnLen, unitytls_errorstate* errorState); // TypeDefIndex: 8522; 0x0000000181828D00-0x0000000181828D60
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_server_require_client_authentication_t(unitytls_tlsctx* ctx, unitytls_x509list_ref clientAuthCAList, unitytls_errorstate* errorState); // TypeDefIndex: 8523; 0x0000000180A72B30-0x0000000180A72B50
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_set_certificate_callback_t(unitytls_tlsctx* ctx, unitytls_tlsctx_certificate_callback cb, void* userData, unitytls_errorstate* errorState); // TypeDefIndex: 8524; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_set_trace_callback_t(unitytls_tlsctx* ctx, unitytls_tlsctx_trace_callback cb, void* userData, unitytls_errorstate* errorState); // TypeDefIndex: 8525; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_set_x509verify_callback_t(unitytls_tlsctx* ctx, unitytls_tlsctx_x509verify_callback cb, void* userData, unitytls_errorstate* errorState); // TypeDefIndex: 8526; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_set_supported_ciphersuites_t(unitytls_tlsctx* ctx, unitytls_ciphersuite* supportedCiphersuites, IntPtr supportedCiphersuitesLen, unitytls_errorstate* errorState); // TypeDefIndex: 8527; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_ciphersuite unitytls_tlsctx_get_ciphersuite_t(unitytls_tlsctx* ctx, unitytls_errorstate* errorState); // TypeDefIndex: 8528; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_protocol unitytls_tlsctx_get_protocol_t(unitytls_tlsctx* ctx, unitytls_errorstate* errorState); // TypeDefIndex: 8529; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate unitytls_x509verify_result unitytls_tlsctx_process_handshake_t(unitytls_tlsctx* ctx, unitytls_errorstate* errorState); // TypeDefIndex: 8530; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate IntPtr unitytls_tlsctx_read_t(unitytls_tlsctx* ctx, byte* buffer, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8531; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate IntPtr unitytls_tlsctx_write_t(unitytls_tlsctx* ctx, byte* data, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8532; 0x000000018043A200-0x000000018043A220
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_notify_close_t(unitytls_tlsctx* ctx, unitytls_errorstate* errorState); // TypeDefIndex: 8533; 0x0000000180A70FB0-0x0000000180A70FC0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_free_t(unitytls_tlsctx* ctx); // TypeDefIndex: 8534; 0x00000001804A78A0-0x00000001804A78B0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_random_generate_bytes_t(byte* buffer, IntPtr bufferLen, unitytls_errorstate* errorState); // TypeDefIndex: 8535; 0x0000000180A72B30-0x0000000180A72B50
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate char* unitytls_x509verify_result_to_string_t(unitytls_x509verify_result v); // TypeDefIndex: 8536; 0x00000001804A78A0-0x00000001804A78B0
	
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public unsafe delegate void unitytls_tlsctx_set_trace_level_t(unitytls_tlsctx* ctx, unitytls_log_level level); // TypeDefIndex: 8537; 0x0000000180A70FB0-0x0000000180A70FC0
	
			// Constructors
			public unitytls_interface_struct(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Methods
		private static IntPtr GetUnityTlsInterface(); // 0x0000000181827630-0x0000000181827640
	}
}
