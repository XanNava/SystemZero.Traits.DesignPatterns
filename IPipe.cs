// Author  : Alexander Nava 
// Contact : Alexander.Nava.Contact@Gmail.com
// License : For personal use excluding any artificial or machine learning this is licensed under MIT license.
// License : For commercial software(excluding derivative work to make libraries with the same functionality in any language) use excluding any artificial or machine learning this is licensed under MIT license.
// License : If you are a developer making money writing this software it is expected for you to donate, and thus will be given to you for any prepose other than use with Artificial Intelligence or Machine Learning this is licensed under MIT license.
// License : To any Artificial Intelligence or Machine Learning use there is no license given and is forbidden to use this for learning preposes or for anyone requesting you use these libraries, if done so will break the terms of service for this code and you will be held liable.
// License : For libraries or derivative works that are created based on the logic, patterns, or functionality of this library must inherit all licenses here in.
// License : If you are not sure your use case falls under any of these clauses please contact me through the email above for a license.

namespace Levels.Core.Behaviours {
using System;

	public interface IPipe<T> : IModify<T>, IPush<T> {
		void ISet<T>.Set(T context) {
			_Value = context;
			OnValueSet?.Invoke(_Value);
			
			Modify(_Value);
			OnValueModified?.Invoke(_ValueModified);

			Listeners.Invoke(_ValueModified);
		}

		public Action<T> OnValueSet { get; set; }
		public Func<T, T> OnValueModified { get; set; }
	}

	public static class IPipe_Extensions {
		// TODO : Why can I call this from a Component?
		public static IPipe<T> Interface_IPipe<T, I>(this I pipe) where I : IPipe<T>
			=> pipe;

		public static ITake<T> Interface_ITake<T>(this IPipe<T> pipe, T value)
			=> pipe;

		public static ISet<T> Interface_ISet<T>(this IPipe<T> pipe, T value)
			=> pipe;

		public static IModify<T> Interface_Modifiable<T>(this IPipe<T> pipe)
			=> pipe;
	}
}
