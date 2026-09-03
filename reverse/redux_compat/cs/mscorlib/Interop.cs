/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

internal static class Interop // TypeDefIndex: 2028
{
	// Nested types
	internal static class Kernel32 // TypeDefIndex: 2029
	{
		// Nested types
		internal struct WIN32_FIND_DATA // TypeDefIndex: 2030
		{
			// Fields
			internal uint dwFileAttributes; // 0x00
			internal FILE_TIME ftCreationTime; // 0x04
			internal FILE_TIME ftLastAccessTime; // 0x0C
			internal FILE_TIME ftLastWriteTime; // 0x14
			internal uint nFileSizeHigh; // 0x1C
			internal uint nFileSizeLow; // 0x20
			internal uint dwReserved0; // 0x24
			internal uint dwReserved1; // 0x28
			private unsafe fixed /* 0x00000000-0x00000000 */ char _cFileName[0]; // 0x2C
			private unsafe fixed /* 0x00000000-0x00000000 */ char _cAlternateFileName[0]; // 0x234

			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct __cFileName_e__FixedBuffer // TypeDefIndex: 2031
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			[CompilerGenerated]
			[UnsafeValueType]
			public struct __cAlternateFileName_e__FixedBuffer // TypeDefIndex: 2032
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			// Methods
			internal void SetFileName(string fileName); // 0x0000000181441CE0-0x0000000181441E80
		}

		internal struct REG_TZI_FORMAT // TypeDefIndex: 2033
		{
			// Fields
			internal int Bias; // 0x00
			internal int StandardBias; // 0x04
			internal int DaylightBias; // 0x08
			internal SYSTEMTIME StandardDate; // 0x0C
			internal SYSTEMTIME DaylightDate; // 0x1C

			// Constructors
			internal REG_TZI_FORMAT([IsReadOnly] in TIME_ZONE_INFORMATION tzi); // 0x0000000181432E80-0x0000000181432EB0
		}

		internal struct SYSTEMTIME // TypeDefIndex: 2034
		{
			// Fields
			internal ushort Year; // 0x00
			internal ushort Month; // 0x02
			internal ushort DayOfWeek; // 0x04
			internal ushort Day; // 0x06
			internal ushort Hour; // 0x08
			internal ushort Minute; // 0x0A
			internal ushort Second; // 0x0C
			internal ushort Milliseconds; // 0x0E

			// Methods
			internal bool Equals([IsReadOnly] in SYSTEMTIME other); // 0x0000000181433930-0x0000000181433990
		}

		internal struct TIME_DYNAMIC_ZONE_INFORMATION // TypeDefIndex: 2035
		{
			// Fields
			internal int Bias; // 0x00
			internal unsafe fixed /* 0x00000000-0x00000000 */ char StandardName[0]; // 0x04
			internal SYSTEMTIME StandardDate; // 0x44
			internal int StandardBias; // 0x54
			internal unsafe fixed /* 0x00000000-0x00000000 */ char DaylightName[0]; // 0x58
			internal SYSTEMTIME DaylightDate; // 0x98
			internal int DaylightBias; // 0xA8
			internal unsafe fixed /* 0x00000000-0x00000000 */ char TimeZoneKeyName[0]; // 0xAC
			internal byte DynamicDaylightTimeDisabled; // 0x1AC

			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _StandardName_e__FixedBuffer // TypeDefIndex: 2036
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			[CompilerGenerated]
			[UnsafeValueType]
			public struct _DaylightName_e__FixedBuffer // TypeDefIndex: 2037
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			[CompilerGenerated]
			[UnsafeValueType]
			public struct _TimeZoneKeyName_e__FixedBuffer // TypeDefIndex: 2038
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			// Methods
			internal string GetTimeZoneKeyName(); // 0x000000018143D7A0-0x000000018143D7C0
		}

		internal struct TIME_ZONE_INFORMATION // TypeDefIndex: 2039
		{
			// Fields
			internal int Bias; // 0x00
			internal unsafe fixed /* 0x00000000-0x00000000 */ char StandardName[0]; // 0x04
			internal SYSTEMTIME StandardDate; // 0x44
			internal int StandardBias; // 0x54
			internal unsafe fixed /* 0x00000000-0x00000000 */ char DaylightName[0]; // 0x58
			internal SYSTEMTIME DaylightDate; // 0x98
			internal int DaylightBias; // 0xA8

			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _StandardName_e__FixedBuffer // TypeDefIndex: 2040
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			[CompilerGenerated]
			[UnsafeValueType]
			public struct _DaylightName_e__FixedBuffer // TypeDefIndex: 2041
			{
				// Fields
				public char FixedElementField; // 0x00
			}

			// Constructors
			internal unsafe TIME_ZONE_INFORMATION([IsReadOnly] in TIME_DYNAMIC_ZONE_INFORMATION dtzi); // 0x000000018143D7E0-0x000000018143D900

			// Methods
			internal string GetStandardName(); // 0x000000018143D7D0-0x000000018143D7E0
			internal string GetDaylightName(); // 0x000000018143D7C0-0x000000018143D7D0
		}

		internal enum FILE_INFO_BY_HANDLE_CLASS : uint // TypeDefIndex: 2042
		{
			FileBasicInfo = 0,
			FileStandardInfo = 1,
			FileNameInfo = 2,
			FileRenameInfo = 3,
			FileDispositionInfo = 4,
			FileAllocationInfo = 5,
			FileEndOfFileInfo = 6,
			FileStreamInfo = 7,
			FileCompressionInfo = 8,
			FileAttributeTagInfo = 9,
			FileIdBothDirectoryInfo = 10,
			FileIdBothDirectoryRestartInfo = 11,
			FileIoPriorityHintInfo = 12,
			FileRemoteProtocolInfo = 13,
			FileFullDirectoryInfo = 14,
			FileFullDirectoryRestartInfo = 15
		}

		internal struct FILE_TIME // TypeDefIndex: 2043
		{
			// Fields
			internal uint dwLowDateTime; // 0x00
			internal uint dwHighDateTime; // 0x04
		}

		internal enum FINDEX_INFO_LEVELS : uint // TypeDefIndex: 2044
		{
			FindExInfoStandard = 0,
			FindExInfoBasic = 1,
			FindExInfoMaxInfoLevel = 2
		}

		internal enum FINDEX_SEARCH_OPS : uint // TypeDefIndex: 2045
		{
			FindExSearchNameMatch = 0,
			FindExSearchLimitToDirectories = 1,
			FindExSearchLimitToDevices = 2,
			FindExSearchMaxSearchOp = 3
		}

		internal enum GET_FILEEX_INFO_LEVELS : uint // TypeDefIndex: 2046
		{
			GetFileExInfoStandard = 0,
			GetFileExMaxInfoLevel = 1
		}

		internal struct SECURITY_ATTRIBUTES // TypeDefIndex: 2047
		{
			// Fields
			internal uint nLength; // 0x00
			internal IntPtr lpSecurityDescriptor; // 0x08
			internal BOOL bInheritHandle; // 0x10
		}

		internal struct WIN32_FILE_ATTRIBUTE_DATA // TypeDefIndex: 2048
		{
			// Fields
			internal int dwFileAttributes; // 0x00
			internal FILE_TIME ftCreationTime; // 0x04
			internal FILE_TIME ftLastAccessTime; // 0x0C
			internal FILE_TIME ftLastWriteTime; // 0x14
			internal uint nFileSizeHigh; // 0x1C
			internal uint nFileSizeLow; // 0x20

			// Methods
			internal void PopulateFrom(ref WIN32_FIND_DATA findData); // 0x0000000181441CB0-0x0000000181441CE0
		}

		// Methods
		internal static extern bool FreeLibrary(IntPtr hModule); // 0x000000018142F310-0x000000018142F3A0
		internal static extern SafeLibraryHandle LoadLibraryEx(string libFilename, IntPtr reserved, int flags); // 0x000000018142F980-0x000000018142FA70
		internal static extern bool GetFileMUIPath(uint flags, string filePath, out StringBuilder language, ref int languageLength, out StringBuilder fileMuiPath, ref int fileMuiPathLength, ref long enumerator); // 0x000000018142F680-0x000000018142F7B0
		internal static extern uint GetDynamicTimeZoneInformation(out TIME_DYNAMIC_ZONE_INFORMATION pTimeZoneInformation); // 0x000000018142F3A0-0x000000018142F430
		internal static extern uint GetTimeZoneInformation(out TIME_ZONE_INFORMATION lpTimeZoneInformation); // 0x000000018142F8F0-0x000000018142F980
		internal static extern bool CloseHandle(IntPtr handle); // 0x000000018142EA90-0x000000018142EB20
		private static extern bool CreateDirectoryPrivate(string path, ref SECURITY_ATTRIBUTES lpSecurityAttributes); // 0x000000018142EB20-0x000000018142EBC0
		internal static bool CreateDirectory(string path, ref SECURITY_ATTRIBUTES lpSecurityAttributes); // 0x000000018142EBC0-0x000000018142ECA0
		private static unsafe extern IntPtr CreateFilePrivate(string lpFileName, int dwDesiredAccess, FileShare dwShareMode, SECURITY_ATTRIBUTES* securityAttrs, FileMode dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile); // 0x000000018142ECA0-0x000000018142ED80
		internal static IntPtr CreateFile_IntPtr(string lpFileName, int dwDesiredAccess, FileShare dwShareMode, FileMode dwCreationDisposition, int dwFlagsAndAttributes); // 0x000000018142ED80-0x000000018142EE90
		private static extern bool DeleteFilePrivate(string path); // 0x000000018142EE90-0x000000018142EF20
		internal static bool DeleteFile(string path); // 0x000000018142EF20-0x000000018142EFF0
		private static extern SafeFindHandle FindFirstFileExPrivate(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, ref WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, IntPtr lpSearchFilter, int dwAdditionalFlags); // 0x000000018142EFF0-0x000000018142F100
		internal static SafeFindHandle FindFirstFile(string fileName, ref WIN32_FIND_DATA data); // 0x000000018142F100-0x000000018142F230
		private static unsafe extern int FormatMessage(int dwFlags, IntPtr lpSource, uint dwMessageId, int dwLanguageId, char* lpBuffer, int nSize, IntPtr[] arguments); // 0x000000018142F230-0x000000018142F310
		internal static string GetMessage(int errorCode); // 0x000000018142F8E0-0x000000018142F8F0
		internal static string GetMessage(IntPtr moduleHandle, int errorCode); // 0x000000018142F7B0-0x000000018142F8E0
		private static bool TryGetErrorMessage(IntPtr moduleHandle, int errorCode, Span<char> buffer, out string errorMsg); // 0x000000018142FB10-0x000000018142FD40
		private static extern bool GetFileAttributesExPrivate(string name, GET_FILEEX_INFO_LEVELS fileInfoLevel, ref WIN32_FILE_ATTRIBUTE_DATA lpFileInformation); // 0x000000018142F430-0x000000018142F4E0
		internal static bool GetFileAttributesEx(string name, GET_FILEEX_INFO_LEVELS fileInfoLevel, ref WIN32_FILE_ATTRIBUTE_DATA lpFileInformation); // 0x000000018142F4E0-0x000000018142F5D0
		public static extern bool GetFileInformationByHandleEx(IntPtr hFile, FILE_INFO_BY_HANDLE_CLASS FileInformationClass, IntPtr lpFileInformation, uint dwBufferSize); // 0x000000018142F5D0-0x000000018142F680
		internal static extern bool SetThreadErrorMode(uint dwNewMode, out uint lpOldMode); // 0x000000018142FA70-0x000000018142FB10
	}

	internal class BCrypt // TypeDefIndex: 2049
	{
		// Nested types
		internal enum NTSTATUS : uint // TypeDefIndex: 2050
		{
			STATUS_SUCCESS = 0,
			STATUS_INVALID_PARAMETER = 3221225485,
			STATUS_NO_MEMORY = 3221225495,
			STATUS_NOT_FOUND = 3221226021
		}

		// Methods
		internal static unsafe extern NTSTATUS BCryptGenRandom(IntPtr hAlgorithm, byte* pbBuffer, int cbBuffer, int dwFlags); // 0x000000018142DA50-0x000000018142DB00
	}

	internal class User32 // TypeDefIndex: 2051
	{
		// Methods
		internal static extern int LoadString(SafeLibraryHandle handle, int id, out StringBuilder buffer, int bufferLength); // 0x0000000181441B80-0x0000000181441CB0
	}

	internal enum BOOL // TypeDefIndex: 2052
	{
		FALSE = 0,
		TRUE = 1
	}

	internal enum BOOLEAN : byte // TypeDefIndex: 2053
	{
		FALSE = 0,
		TRUE = 1
	}

	internal struct LongFileTime // TypeDefIndex: 2054
	{
		// Fields
		internal long TicksSince1601; // 0x00
	}

	internal struct UNICODE_STRING // TypeDefIndex: 2055
	{
		// Fields
		internal ushort Length; // 0x00
		internal ushort MaximumLength; // 0x02
		internal IntPtr Buffer; // 0x08
	}

	internal class NtDll // TypeDefIndex: 2056
	{
		// Nested types
		public struct FILE_FULL_DIR_INFORMATION // TypeDefIndex: 2057
		{
			// Fields
			public uint NextEntryOffset; // 0x00
			public uint FileIndex; // 0x04
			public LongFileTime CreationTime; // 0x08
			public LongFileTime LastAccessTime; // 0x10
			public LongFileTime LastWriteTime; // 0x18
			public LongFileTime ChangeTime; // 0x20
			public long EndOfFile; // 0x28
			public long AllocationSize; // 0x30
			public FileAttributes FileAttributes; // 0x38
			public uint FileNameLength; // 0x3C
			public uint EaSize; // 0x40
			private char _fileName; // 0x44

			// Properties
			public ReadOnlySpan<char> FileName { get; } // 0x000000018142E930-0x000000018142E980 

			// Methods
			public static unsafe FILE_FULL_DIR_INFORMATION* GetNextInfo(FILE_FULL_DIR_INFORMATION* info); // 0x000000018142E910-0x000000018142E930
		}

		public enum FILE_INFORMATION_CLASS : uint // TypeDefIndex: 2058
		{
			FileDirectoryInformation = 1,
			FileFullDirectoryInformation = 2,
			FileBothDirectoryInformation = 3,
			FileBasicInformation = 4,
			FileStandardInformation = 5,
			FileInternalInformation = 6,
			FileEaInformation = 7,
			FileAccessInformation = 8,
			FileNameInformation = 9,
			FileRenameInformation = 10,
			FileLinkInformation = 11,
			FileNamesInformation = 12,
			FileDispositionInformation = 13,
			FilePositionInformation = 14,
			FileFullEaInformation = 15,
			FileModeInformation = 16,
			FileAlignmentInformation = 17,
			FileAllInformation = 18,
			FileAllocationInformation = 19,
			FileEndOfFileInformation = 20,
			FileAlternateNameInformation = 21,
			FileStreamInformation = 22,
			FilePipeInformation = 23,
			FilePipeLocalInformation = 24,
			FilePipeRemoteInformation = 25,
			FileMailslotQueryInformation = 26,
			FileMailslotSetInformation = 27,
			FileCompressionInformation = 28,
			FileObjectIdInformation = 29,
			FileCompletionInformation = 30,
			FileMoveClusterInformation = 31,
			FileQuotaInformation = 32,
			FileReparsePointInformation = 33,
			FileNetworkOpenInformation = 34,
			FileAttributeTagInformation = 35,
			FileTrackingInformation = 36,
			FileIdBothDirectoryInformation = 37,
			FileIdFullDirectoryInformation = 38,
			FileValidDataLengthInformation = 39,
			FileShortNameInformation = 40,
			FileIoCompletionNotificationInformation = 41,
			FileIoStatusBlockRangeInformation = 42,
			FileIoPriorityHintInformation = 43,
			FileSfioReserveInformation = 44,
			FileSfioVolumeInformation = 45,
			FileHardLinkInformation = 46,
			FileProcessIdsUsingFileInformation = 47,
			FileNormalizedNameInformation = 48,
			FileNetworkPhysicalNameInformation = 49,
			FileIdGlobalTxDirectoryInformation = 50,
			FileIsRemoteDeviceInformation = 51,
			FileUnusedInformation = 52,
			FileNumaNodeInformation = 53,
			FileStandardLinkInformation = 54,
			FileRemoteProtocolInformation = 55,
			FileRenameInformationBypassAccessCheck = 56,
			FileLinkInformationBypassAccessCheck = 57,
			FileVolumeNameInformation = 58,
			FileIdInformation = 59,
			FileIdExtdDirectoryInformation = 60,
			FileReplaceCompletionInformation = 61,
			FileHardLinkFullIdInformation = 62,
			FileIdExtdBothDirectoryInformation = 63,
			FileDispositionInformationEx = 64,
			FileRenameInformationEx = 65,
			FileRenameInformationExBypassAccessCheck = 66,
			FileDesiredStorageClassInformation = 67,
			FileStatInformation = 68
		}

		public struct IO_STATUS_BLOCK // TypeDefIndex: 2059
		{
			// Fields
			public IO_STATUS Status; // 0x00
			public IntPtr Information; // 0x08

			// Nested types
			public struct IO_STATUS // TypeDefIndex: 2060
			{
				// Fields
				public uint Status; // 0x00
				public IntPtr Pointer; // 0x00
			}
		}

		public struct OBJECT_ATTRIBUTES // TypeDefIndex: 2061
		{
			// Fields
			public uint Length; // 0x00
			public IntPtr RootDirectory; // 0x08
			public unsafe UNICODE_STRING* ObjectName; // 0x10
			public ObjectAttributes Attributes; // 0x18
			public unsafe void* SecurityDescriptor; // 0x20
			public unsafe void* SecurityQualityOfService; // 0x28

			// Constructors
			public unsafe OBJECT_ATTRIBUTES(UNICODE_STRING* objectName, ObjectAttributes attributes, IntPtr rootDirectory); // 0x0000000181432E50-0x0000000181432E70
		}

		[Flags]
		public enum ObjectAttributes : uint // TypeDefIndex: 2062
		{
			OBJ_INHERIT = 2,
			OBJ_PERMANENT = 16,
			OBJ_EXCLUSIVE = 32,
			OBJ_CASE_INSENSITIVE = 64,
			OBJ_OPENIF = 128,
			OBJ_OPENLINK = 256
		}

		public enum CreateDisposition : uint // TypeDefIndex: 2063
		{
			FILE_SUPERSEDE = 0,
			FILE_OPEN = 1,
			FILE_CREATE = 2,
			FILE_OPEN_IF = 3,
			FILE_OVERWRITE = 4,
			FILE_OVERWRITE_IF = 5
		}

		public enum CreateOptions : uint // TypeDefIndex: 2064
		{
			FILE_DIRECTORY_FILE = 1,
			FILE_WRITE_THROUGH = 2,
			FILE_SEQUENTIAL_ONLY = 4,
			FILE_NO_INTERMEDIATE_BUFFERING = 8,
			FILE_SYNCHRONOUS_IO_ALERT = 16,
			FILE_SYNCHRONOUS_IO_NONALERT = 32,
			FILE_NON_DIRECTORY_FILE = 64,
			FILE_CREATE_TREE_CONNECTION = 128,
			FILE_COMPLETE_IF_OPLOCKED = 256,
			FILE_NO_EA_KNOWLEDGE = 512,
			FILE_RANDOM_ACCESS = 2048,
			FILE_DELETE_ON_CLOSE = 4096,
			FILE_OPEN_BY_FILE_ID = 8192,
			FILE_OPEN_FOR_BACKUP_INTENT = 16384,
			FILE_NO_COMPRESSION = 32768,
			FILE_OPEN_REQUIRING_OPLOCK = 65536,
			FILE_DISALLOW_EXCLUSIVE = 131072,
			FILE_SESSION_AWARE = 262144,
			FILE_RESERVE_OPFILTER = 1048576,
			FILE_OPEN_REPARSE_POINT = 2097152,
			FILE_OPEN_NO_RECALL = 4194304
		}

		[Flags]
		public enum DesiredAccess : uint // TypeDefIndex: 2065
		{
			FILE_READ_DATA = 1,
			FILE_LIST_DIRECTORY = 1,
			FILE_WRITE_DATA = 2,
			FILE_ADD_FILE = 2,
			FILE_APPEND_DATA = 4,
			FILE_ADD_SUBDIRECTORY = 4,
			FILE_CREATE_PIPE_INSTANCE = 4,
			FILE_READ_EA = 8,
			FILE_WRITE_EA = 16,
			FILE_EXECUTE = 32,
			FILE_TRAVERSE = 32,
			FILE_DELETE_CHILD = 64,
			FILE_READ_ATTRIBUTES = 128,
			FILE_WRITE_ATTRIBUTES = 256,
			DELETE = 65536,
			READ_CONTROL = 131072,
			STANDARD_RIGHTS_READ = 131072,
			STANDARD_RIGHTS_WRITE = 131072,
			STANDARD_RIGHTS_EXECUTE = 131072,
			WRITE_DAC = 262144,
			WRITE_OWNER = 524288,
			FILE_ALL_ACCESS = 983551,
			SYNCHRONIZE = 1048576,
			FILE_GENERIC_EXECUTE = 536870912,
			FILE_GENERIC_WRITE = 1073741824,
			FILE_GENERIC_READ = 2147483648
		}

		// Methods
		private static unsafe extern int NtCreateFile(out IntPtr FileHandle, DesiredAccess DesiredAccess, ref OBJECT_ATTRIBUTES ObjectAttributes, out IO_STATUS_BLOCK IoStatusBlock, long* AllocationSize, FileAttributes FileAttributes, FileShare ShareAccess, CreateDisposition CreateDisposition, CreateOptions CreateOptions, void* EaBuffer, uint EaLength); // 0x0000000181432BC0-0x0000000181432CC0
		internal static ValueTuple<int, IntPtr> CreateFile(ReadOnlySpan<char> path, IntPtr rootDirectory, CreateDisposition createDisposition, DesiredAccess desiredAccess = DesiredAccess.SYNCHRONIZE | DesiredAccess.FILE_GENERIC_READ /* Metadata: 0x0064E193 */, FileShare shareAccess = FileShare.None | FileShare.Read | FileShare.Write | FileShare.ReadWrite | FileShare.Delete /* Metadata: 0x0064E198 */, FileAttributes fileAttributes =  /* Metadata: 0x0064E199 */, CreateOptions createOptions = CreateOptions.FILE_SYNCHRONOUS_IO_NONALERT /* Metadata: 0x0064E19A */, ObjectAttributes objectAttributes = ObjectAttributes.OBJ_CASE_INSENSITIVE /* Metadata: 0x0064E19B */); // 0x0000000181432950-0x0000000181432BC0
		public static unsafe extern int NtQueryDirectoryFile(IntPtr FileHandle, IntPtr Event, IntPtr ApcRoutine, IntPtr ApcContext, out IO_STATUS_BLOCK IoStatusBlock, IntPtr FileInformation, uint Length, FILE_INFORMATION_CLASS FileInformationClass, BOOLEAN ReturnSingleEntry, UNICODE_STRING* FileName, BOOLEAN RestartScan); // 0x0000000181432CC0-0x0000000181432DD0
		public static extern uint RtlNtStatusToDosError(int Status); // 0x0000000181432DD0-0x0000000181432E50
	}

	internal class Advapi32 // TypeDefIndex: 2066
	{
		// Methods
		internal static extern int RegCloseKey(IntPtr hKey); // 0x000000018142CB30-0x000000018142CBB0
		internal static extern int RegEnumKeyEx(SafeRegistryHandle hKey, int dwIndex, char[] lpName, ref int lpcbName, int[] lpReserved, out StringBuilder lpClass, int[] lpcbClass, long[] lpftLastWriteTime); // 0x000000018142CBB0-0x000000018142CD50
		internal static extern int RegOpenKeyEx(SafeRegistryHandle hKey, string lpSubKey, int ulOptions, int samDesired, out SafeRegistryHandle hkResult); // 0x000000018142CD50-0x000000018142CEC0
		internal static extern int RegQueryInfoKey(SafeRegistryHandle hKey, out StringBuilder lpClass, int[] lpcbClass, IntPtr lpReserved_MustBeZero, ref int lpcSubKeys, int[] lpcbMaxSubKeyLen, int[] lpcbMaxClassLen, ref int lpcValues, int[] lpcbMaxValueNameLen, int[] lpcbMaxValueLen, int[] lpcbSecurityDescriptor, int[] lpftLastWriteTime); // 0x000000018142CEC0-0x000000018142D0F0
		internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, string lpValueName, int[] lpReserved, ref int lpType, out byte[] lpData, ref int lpcbData); // 0x000000018142D330-0x000000018142D4F0
		internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, string lpValueName, int[] lpReserved, ref int lpType, ref int lpData, ref int lpcbData); // 0x000000018142D0F0-0x000000018142D210
		internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, string lpValueName, int[] lpReserved, ref int lpType, ref long lpData, ref int lpcbData); // 0x000000018142D210-0x000000018142D330
		internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, string lpValueName, int[] lpReserved, ref int lpType, out char[] lpData, ref int lpcbData); // 0x000000018142D4F0-0x000000018142D6B0
	}

	// Methods
	internal static unsafe void GetRandomBytes(byte* buffer, int length); // 0x000000018142E980-0x000000018142EA90
}

