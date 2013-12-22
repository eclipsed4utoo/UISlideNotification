using System;
using MonoTouch.UIKit;

namespace UISlideNotification
{
	public static class Extensions
	{
		public static UIViewController GetParentUIViewController(this UIView view)
		{
			var nextResponder = view.NextResponder;
			if (nextResponder is UIViewController)
				return (UIViewController)nextResponder;
			else if (nextResponder is UIView)
				return ((UIView)nextResponder).GetParentUIViewController ();
			else
				return null;



//			id nextResponder = [self nextResponder];
//			if ([nextResponder isKindOfClass:[UIViewController class]]) {
//				return nextResponder;
//			} else if ([nextResponder isKindOfClass:[UIView class]]) {
//				return [nextResponder traverseResponderChainForUIViewController];
//			} else {
//				return nil;
//			}
		}
	}
}

