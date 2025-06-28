// Author  : Alexander Nava 
// Contact : Alexander.Nava.Contact@Gmail.com
// License : For personal use excluding any artificail or machine learning this is licensed under MIT license.
// License : For commercial software(excluding derivative work to make libraries with the same functionality in any language) use excluding any artificail or machine learning this is licensed under MIT license.
// License : If you are a developer making money writing this software it is expected for you to donate, and thus will be given to you for any perpose other than use with Artificial Intelegence or Machine Learning this is licensed under MIT license.
// License : To any Artificial Intelegence or Machine Learning use there is no license given and is forbiden to use this for learning perposes or for anyone requesting you use these libraries, if done so will break the terms of service for this code and you will be held liable.
// License : For libraries or dirivative works that are created based on the logic, patterns, or functionality of this library must inherit all licenses here in.
// License : If you are not sure your use case falls under any of these clauses please contact me through the email above for a license.


namespace Levels.Core {
	using System;
	using System.Collections.Generic;

	using UnityEngine;

	public interface IAttributable {
		bool HasAttribute(string key);
	}

	public interface IAttribute<T> {
		string Label { get; set; }
		T Attribute { get; set; }
	}

	public interface IAttributes<T> : IAttributable {
		Dictionary<string, T> Collection { get; }

		bool IAttributable.HasAttribute(string key) {
			return Collection.ContainsKey(key);
		}

		T TryGetAttribute(string key) {
			Debug.Log(Collection);
			Debug.Log(!Collection.ContainsKey(key));

			if (!Collection.ContainsKey(key))
				return default;

			return Collection[key];
		}
	}

	public static class IAttributesExtends {
		public static IAttributes<T> Interface_IAttributes<T>(this IAttributes<T> source) {
			return source;
		}
	}

	public interface IAttributesBool : IAttributes<bool> { }
	public interface IAttributesFloat : IAttributes<float> { }
	public interface IAttributesInt : IAttributes<int> { }
	public interface IAttributesVector2 : IAttributes<Vector2> { }
	public interface IAttributesVector3 : IAttributes<Vector3> { }
	public interface IAttributesColor : IAttributes<Color> { }
	public interface IAttributesFunc<T> : IAttributes<Func<T>> { }
	public interface IAttributesFunc<T, V> : IAttributes<Func<T, V>> { }
	public interface IAttributesAction<T> : IAttributes<Action<T>> { }

	[Serializable]
	public struct Attribute<T> {
		public string key;
		public T value;
	}
}
