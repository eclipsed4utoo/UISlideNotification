UISlideNotification
===================
A notification that slides in and out of view for Xamarin.iOS (MonoTouch)

### Simple Usage


    public override void ViewDidLoad()
    {
       this.ShowNotification.TouchUpInside += (object sender, EventArgs e) =>
       {
          var noti = new UISlideNotification(this.View, "Test Notification");
          noti.ShowNotification();
       };
    }
    
### Properties Available

`NotificationDuration` - Determines how long the notification stays visible in milliseconds. Defaults to 3 seconds.  
`NotificationAnimationDuration` - Determines the amount of time it takes for the animation to show the notification in milliseconds. Default is 300ms.  
`BackgroundColor` - Sets the background color of the notification. Default is Black.  
`TextColor` - Sets the text color of the notification's text. Default is White.  
`TextAlignment` - Sets the alignment of the notification's text. Default is Center.  
`Alpha` - Sets the Alpha value of the notification view.  
`ActivityIndicatorViewCenter` - Specifies the center of the activity indicator(if enabled).  
`ActivityIndicatorViewAlpha` - Sets the Alpha value of the activity indicator(if enabled).  
`ActivityIndicatorViewStyle` - Specifies the `UIActivityIndicatorViewStyle` of the activity indicator(if enabled).

### Methods Available

`ShowNotification` - Shows the notification with the properties above.  

With the simplest constructor(as shown in the code above), will show a standard text notification with no activity indicator and will show at the bottom of the view. Additional constructors allow for including an activity indicator, and determining whether to show the notification at the bottom or the top.

### License
> The MIT License (MIT)
> 
> Copyright (c) 2013 Ryan Alford
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy
> of this software and associated documentation files (the "Software"), to deal
> in the Software without restriction, including without limitation the rights
> to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
> copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all
> copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
> IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
> FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
> AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
> LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
> OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
> SOFTWARE.
