namespace Unity.IntegerTime;

[Extension]
public static class RationalTimeExtensions
{

	[Extension]
	[FreeFunction("IntegerTime::RationalTime::ConvertRate", IsFreeFunction = True, ThrowsException = True)]
	public static RationalTime Convert(RationalTime time, TicksPerSecond rate) { }

	private static void Convert_Injected(in RationalTime time, in TicksPerSecond rate, out RationalTime ret) { }

}

