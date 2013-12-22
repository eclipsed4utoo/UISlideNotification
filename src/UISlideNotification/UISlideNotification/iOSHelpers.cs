using System;
using MonoTouch.UIKit;

namespace UISlideNotification
{
	public static class iOSHelpers
	{
		public static bool IsIOS7
		{
			get
			{
				return UIDevice.CurrentDevice.CheckSystemVersion(7, 0);
			}
		}
	}
}

