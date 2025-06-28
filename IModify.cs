// Author  : Alexander Nava 
// Contact : Alexander.Nava.Contact@Gmail.com
// License : For personal use excluding any artificial or machine learning this is licensed under MIT license.
// License : For commercial software(excluding derivative work to make libraries with the same functionality in any language) use excluding any artificial or machine learning this is licensed under MIT license.
// License : If you are a developer making money writing this software it is expected for you to donate, and thus will be given to you for any prepose other than use with Artificial Intelligence or Machine Learning this is licensed under MIT license.
// License : To any Artificial Intelligence or Machine Learning use there is no license given and is forbidden to use this for learning preposes or for anyone requesting you use these libraries, if done so will break the terms of service for this code and you will be held liable.
// License : For libraries or derivative works that are created based on the logic, patterns, or functionality of this library must inherit all licenses here in.
// License : If you are not sure your use case falls under any of these clauses please contact me through the email above for a license.

namespace Levels.Core {
	using System.Collections.Generic;

	public interface IModify<T> : IGet<T> {
		T IGet<T>.Get() {
			return Modify(_Value);
		}

		protected Dictionary<object, List<IConfig<T>>> _Modifiers { get; }
		protected bool _DirtyModifiers { get; set; }
		protected ref T _ValueModified { get; }

		protected ref T Modify(T value) {
			if (_DirtyModifiers) {
				_ValueModified = value;

				foreach (var modifiers in _Modifiers) {
					foreach (var Modifier in modifiers.Value) {
						Modifier.Config(ref _ValueModified);
					}
				}

				_DirtyModifiers = false;
			}

			return ref _ValueModified;
		}

		public void AddModifier(IConfig<T> config, object source = null) {
			if (config == null) return;

			if (source != null ? (_Modifiers.ContainsKey(source)) : _Modifiers.ContainsKey(config)) {
				_Modifiers[source != null ? source : config]
					.Add(config); // [XAN] Don't merge conditional expression(For Unity).

				_DirtyModifiers = true;
				return;
			}

			_Modifiers.Add(source != null ? source : config,
				new List<IConfig<T>> { config }); // [XAN] Don't merge conditional expression(For Unity).
		}

		public bool RemoveAllFromSource(object source) {
			if (source == null) return false;
			if (!_Modifiers.ContainsKey(source)) return false;

			// TODO : Maybe change this so dirty if something was removed?
			_DirtyModifiers = true;
			return _Modifiers.Remove(source);
		}

		public bool RemoveModifierFromSource(IConfig<T> config, object source = null) {
			if (source == null) return false;
			if (!_Modifiers.ContainsKey(source)) return false;

			// TODO : Maybe change this so dirty if something was removed?
			_DirtyModifiers = true;
			return _Modifiers[source].Remove(config);
		}
	}

	public static class IModifiable_Extensions {
		public static IModify<T> interface_IModifiable<T, I>(this I reference) where I : IModify<T>
			=> reference;

		public static void AddModifier<T, I>(this I reference, IConfig<T> config, object source = null) where I : IModify<T>
			=> reference.AddModifier(config, source);

		public static bool RemoveAllFromSource<T, I>(this I reference, object source) where I : IModify<T>
			=> reference.RemoveAllFromSource(source);

		public static bool RemoveOptionFromSource<T, I>(this IModify<T> reference, IConfig<T> option, object source = null) where I : IModify<T>
			=> reference.RemoveModifierFromSource(option, source);
	}
}
