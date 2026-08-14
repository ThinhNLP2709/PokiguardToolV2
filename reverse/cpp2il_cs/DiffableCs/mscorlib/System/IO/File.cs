namespace System.IO;

public static class File
{

	public static void AppendAllText(string path, string contents) { }

	public static void Delete(string path) { }

	public static bool Exists(string path) { }

	public static FileAttributes GetAttributes(string path) { }

	private static string InternalReadAllText(string path, Encoding encoding) { }

	private static void InternalWriteAllBytes(string path, Byte[] bytes) { }

	public static FileStream Open(string path, FileMode mode) { }

	public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share) { }

	public static FileStream OpenRead(string path) { }

	public static StreamReader OpenText(string path) { }

	public static FileStream OpenWrite(string path) { }

	public static Byte[] ReadAllBytes(string path) { }

	private static Byte[] ReadAllBytesUnknownLength(FileStream fs) { }

	public static string ReadAllText(string path) { }

	public static void WriteAllBytes(string path, Byte[] bytes) { }

	public static void WriteAllText(string path, string contents) { }

}

