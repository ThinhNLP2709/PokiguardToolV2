namespace Unity.Properties.Internal;

internal class Vector3PropertyBag : ContainerPropertyBag<Vector3>
{
	private class XProperty : Property<Vector3, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public XProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Vector3 container) { }

		public virtual void SetValue(ref Vector3 container, float value) { }

	}

	private class YProperty : Property<Vector3, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public YProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Vector3 container) { }

		public virtual void SetValue(ref Vector3 container, float value) { }

	}

	private class ZProperty : Property<Vector3, Single>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public ZProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual float GetValue(ref Vector3 container) { }

		public virtual void SetValue(ref Vector3 container, float value) { }

	}


	public Vector3PropertyBag() { }

}

