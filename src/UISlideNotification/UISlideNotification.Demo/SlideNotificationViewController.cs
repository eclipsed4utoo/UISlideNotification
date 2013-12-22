using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace UISlideNotification.Demo
{
	public partial class SlideNotificationViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public SlideNotificationViewController ()
			: base (UserInterfaceIdiomIsPhone ? "SlideNotificationViewController_iPhone" : "SlideNotificationViewController_iPad", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			this.ShowNotificationButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				var noti = new UISlideNotification(this.View, "Test Notification");
				noti.ShowNotification();
			};	

			this.ShowActivityNotificationButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				var noti = new UISlideNotification(this.View, "Test Notification", true);
				noti.ShowNotification();
			};

			this.ShowTopNotificationButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				var noti = new UISlideNotification(this.View, "Test Notification", UISlideNotificationPosition.Top);
				noti.ShowNotification();
			};
		}
	}
}

