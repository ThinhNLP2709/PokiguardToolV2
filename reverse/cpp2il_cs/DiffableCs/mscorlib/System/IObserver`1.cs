namespace System;

public interface IObserver
{

	public void OnCompleted() { }

	public void OnError(Exception error) { }

	public void OnNext(T value) { }

}

