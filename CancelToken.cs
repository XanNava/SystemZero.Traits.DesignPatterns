// Author : Alexander Nava
// License : MIT license.

namespace Levels.Core {
	public struct CancelToken {
		public static CancelToken True = new CancelToken { isCancelled = true };
		public static CancelToken False = new CancelToken { isCancelled = false };

		public bool isCancelled;
	}
}

