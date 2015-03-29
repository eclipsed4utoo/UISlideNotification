// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace UISlideNotification.Demo
{
	[Register ("SlideNotificationViewController")]
	partial class SlideNotificationViewController
	{
		[Outlet]
		UIKit.UIButton ShowActivityNotificationButton { get; set; }

		[Outlet]
		UIKit.UIButton ShowNotificationButton { get; set; }

		[Outlet]
		UIKit.UIButton ShowTopNotificationButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ShowNotificationButton != null) {
				ShowNotificationButton.Dispose ();
				ShowNotificationButton = null;
			}

			if (ShowTopNotificationButton != null) {
				ShowTopNotificationButton.Dispose ();
				ShowTopNotificationButton = null;
			}

			if (ShowActivityNotificationButton != null) {
				ShowActivityNotificationButton.Dispose ();
				ShowActivityNotificationButton = null;
			}
		}
	}
}
