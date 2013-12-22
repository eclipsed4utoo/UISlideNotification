using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace UISlideNotification
{
	public enum UISlideNotificationPosition
	{
		Top,
		Bottom
	}

	public class UISlideNotification
	{
		private UIView _parentView;
		private UIViewController _parentController;
		private string _notificationText;
		private UIColor _backgroundColor = UIColor.Black;
		private UIColor _textColor = UIColor.White;
		private UITextAlignment _textAlignment = UITextAlignment.Center;
		private float _labelAlpha = 0.8f;
		private UIActivityIndicatorViewStyle _activityIndicatorViewStyle = UIActivityIndicatorViewStyle.White;
		private float _activityIndicatorViewAlpha = 1.0f;
		private PointF _activityIndicatorViewCenter = new PointF (15, 15);
		private bool _showActivitySpinner;
		private int _notificationDuration = 3000;
		private UISlideNotificationPosition _position = UISlideNotificationPosition.Bottom;

		private int labelHeight = 30;
		private int statusBarHeight = 20;
		private int toolbarHeight = 44;

		/// <summary>
		/// Gets or sets the duration of the notification.
		/// </summary>
		/// <value>The duration of the notification in milliseconds</value>
		public int NotificationDuration
		{
			get { return _notificationDuration; }
			set { _notificationDuration = value; }
		}

		public PointF ActivityIndicatorViewCenter
		{
			get { return _activityIndicatorViewCenter; }
			set { _activityIndicatorViewCenter = value; }
		}

		public float ActivityIndicatorViewAlpha
		{
			get { return _activityIndicatorViewAlpha; }
			set { _activityIndicatorViewAlpha = value; }
		}

		public UIActivityIndicatorViewStyle ActivityIndicatorViewStyle
		{
			get { return _activityIndicatorViewStyle; }
			set { _activityIndicatorViewStyle = value; }
		}

		public UIColor BackgroundColor
		{
			get { return _backgroundColor; }
			set { _backgroundColor = value; }
		}

		public UIColor TextColor
		{
			get { return _textColor; }
			set { _textColor = value; }
		}

		public UITextAlignment TextAlignment
		{
			get { return _textAlignment; }
			set { _textAlignment = value; }
		}

		public float Alpha
		{
			get { return _labelAlpha; }
			set { _labelAlpha = value; }
		}

		private float NotificationLabelTop
		{
			get
			{
				_parentController = _parentView.GetParentUIViewController ();

				if (_parentController != null)
				{
					if (_position == UISlideNotificationPosition.Bottom)
					{
						if ((_parentController.ToolbarItems != null && _parentController.ToolbarItems.Length > 0) ||
							(_parentController.NavigationController != null && !_parentController.NavigationController.ToolbarHidden))
						{
							return (iOSHelpers.IsIOS7) ? _parentView.Frame.Bottom - toolbarHeight : _parentView.Frame.Bottom;
						}
					}
					else if (_position == UISlideNotificationPosition.Top)
					{
						if (_parentController.NavigationController != null && !_parentController.NavigationController.NavigationBarHidden)
						{
							return (iOSHelpers.IsIOS7) ? _parentView.Frame.Top + labelHeight : _parentView.Frame.Top - labelHeight;
						}

						return (iOSHelpers.IsIOS7) ? _parentView.Frame.Top + statusBarHeight - labelHeight : _parentView.Frame.Top - labelHeight;
					}
				}

				return (_position == UISlideNotificationPosition.Bottom) ? _parentView.Frame.Bottom : _parentView.Frame.Top;
			}
		}

		public UISlideNotification (UIView parentView, string notificationText, bool showActivitySpinner, UISlideNotificationPosition position)
		{
			_parentView = parentView;
			_notificationText = notificationText;
			_showActivitySpinner = showActivitySpinner;
			_position = position;
		}

		private UILabel notificationLabel = null;
		private UIActivityIndicatorView activityView = null;
		private void SetupUI()
		{
			notificationLabel = new UILabel (new RectangleF (0, this.NotificationLabelTop, _parentView.Frame.Width, labelHeight));
			notificationLabel.Text = _notificationText;
			notificationLabel.BackgroundColor = this.BackgroundColor;
			notificationLabel.TextColor = this.TextColor;
			notificationLabel.TextAlignment = this.TextAlignment;
			notificationLabel.Alpha = _labelAlpha;
			notificationLabel.Hidden = true;

			if (_showActivitySpinner)
			{
				activityView = new UIActivityIndicatorView (this.ActivityIndicatorViewStyle);
				activityView.Alpha = this.ActivityIndicatorViewAlpha;
				activityView.HidesWhenStopped = false;
				activityView.Center = this.ActivityIndicatorViewCenter;
				notificationLabel.AddSubview (activityView);
			}
		}

		public void ShowNotification()
		{
			SetupUI ();
			_parentView.AddSubview (notificationLabel);
			notificationLabel.Hidden = false;

			if (_showActivitySpinner)
				activityView.StartAnimating ();

			var newFrame = new RectangleF (notificationLabel.Frame.X, notificationLabel.Frame.Y, notificationLabel.Frame.Width, notificationLabel.Frame.Height);

			if (_position == UISlideNotificationPosition.Bottom)
				newFrame.Y -= labelHeight;
			else
				newFrame.Y += labelHeight;

			UIView.Transition(notificationLabel, 0.3f, UIViewAnimationOptions.CurveEaseInOut, () => {

				notificationLabel.Frame = newFrame;

			}, () => {

				var ctx = TaskScheduler.FromCurrentSynchronizationContext();
				Task.Delay(_notificationDuration).ContinueWith((task) => HideNotification(), ctx);

			});
		}

		private void HideNotification()
		{
			var newFrame = new RectangleF (notificationLabel.Frame.X, notificationLabel.Frame.Y, notificationLabel.Frame.Width, notificationLabel.Frame.Height);

			if (_position == UISlideNotificationPosition.Bottom)
				newFrame.Y += labelHeight;
			else
				newFrame.Y -= labelHeight;

			UIView.Transition(notificationLabel, 0.3f, UIViewAnimationOptions.CurveEaseInOut, () => {

				notificationLabel.Frame = newFrame;

			}, () => {

				if (_showActivitySpinner)
					activityView.StopAnimating();

				notificationLabel.Hidden = true;
				notificationLabel.RemoveFromSuperview ();

			});
		}
	}
}

