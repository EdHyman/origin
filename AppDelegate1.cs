using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace techchat
{
	public partial class AppDelegate1 : NSApplicationDelegate
	{
		ServerWindowController serverWindowController;

		public AppDelegate1 ()
		{
//			MonoMac.Foundation.NSObject sender = this;

//			serverWindowController = new ServerWindowController ();
//			showWindow (sender);

		}

		public override void FinishedLaunching (NSObject notification)
		{
      		serverWindowController = new ServerWindowController ();
			serverWindowController.Window.MakeKeyAndOrderFront (this);
		}
/*
		void showWindow (MonoMac.Foundation.NSObject sender){
			MyWindowClass myWindow = new MyWindowClass( );
			myWindow.MakeKeyAndOrderFront(this);
		}
*/

	}
}

