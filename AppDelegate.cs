using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace techchat
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;
		MainWindowController serverWindowController;

//		ServerWindowController serverWindowController;

		public AppDelegate ()
		{
		}

		public override void FinishedLaunching (NSObject notification)
		{
			serverWindowController = new MainWindowController (true);
			serverWindowController.Window.MakeKeyAndOrderFront (this);

			mainWindowController = new MainWindowController ();
			mainWindowController.Window.MakeKeyAndOrderFront (this);
/*
			serverWindowController = new ServerWindowController ();
			serverWindowController.Window.MakeKeyAndOrderFront (this);
*/
		}

		public override NSApplicationTerminateReply ApplicationShouldTerminate (NSApplication sender)
		{
			var appWindows = NSApplication.SharedApplication.Windows;
			foreach (var wnd in appWindows)
			{
				wnd.PerformClose(this);
			}

			return NSApplicationTerminateReply.Now;
		}
			

	}
}

