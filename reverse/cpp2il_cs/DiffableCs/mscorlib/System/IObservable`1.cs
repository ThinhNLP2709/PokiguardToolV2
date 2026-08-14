namespace System;

public interface IObservable
{

	public IDisposable Subscribe(IObserver<T> observer) { }

}

