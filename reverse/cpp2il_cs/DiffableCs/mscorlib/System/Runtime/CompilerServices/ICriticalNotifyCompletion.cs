namespace System.Runtime.CompilerServices;

public interface ICriticalNotifyCompletion
{

	public void UnsafeOnCompleted(Action continuation) { }

}

