using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using System.Drawing;
using System.Windows.Forms;

using System.ServiceModel;
using CommonParts;


//	using System.ServiceModel;
//	using CommonParts;

namespace techchat
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{

		string _usrName;
		string _IRN;

		bool _blackboard = false;

		int screenHeight;
		int screenWidth;
		int upperBound;

		public IServerWithCallback srv;

		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}

		public MainWindowController ( bool blackboard ) : base ("Blackboard" )
		{
			_blackboard = blackboard;
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{
			CreateMenu ();
			CreateWindow ();
		}

		#endregion

		void CreateMenu ()
		{
			var mainMenu = new NSMenu (string.Empty);
			var appMenu = new NSMenu ("DemoApp");

			var about = new NSMenuItem ("Über DemoApp", OnAbout);
			appMenu.AddItem (about);

			appMenu.AddItem (NSMenuItem.SeparatorItem);

			var quit = new NSMenuItem ("DemoApp beenden", "q", OnQuit);
			appMenu.AddItem (quit);

			var dummy = new NSMenuItem (string.Empty);
			dummy.Submenu = appMenu;

			mainMenu.AddItem(dummy);
			NSApplication.SharedApplication.SetMainMenu (mainMenu);
		}

		void CreateWindow ()
		{
			Screen[] screens =  Screen.AllScreens;
			upperBound = screens.GetUpperBound(0);
			screenHeight = screens[0].WorkingArea.Height;
			screenWidth = screens[0].WorkingArea.Width;

			Window = new NSWindow (new RectangleF (100, 600, 500, 300), 
				NSWindowStyle.Titled | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable | NSWindowStyle.Resizable, 
				NSBackingStore.Buffered, false) {
				Title = "Register for Class",
				ReleasedWhenClosed = true,
				AcceptsMouseMovedEvents = true
			};

			if (!_blackboard) {

				var button = new NSButton (new RectangleF (200, 100, 90, 33)) {
					Title = "Submit"
				};

				var userName = new NSTextField (new RectangleF (50, 220, 150, 33)) {

				};

				var irn = new NSTextField (new RectangleF (300, 220, 150, 33)) {
				};

				var textBox = new NSTextView (new System.Drawing.RectangleF (10, 10, screenWidth - 700, 110));

				textBox.TextDidChange += (object sender, EventArgs e) => {

					string newText = textBox.Value;

					if ((newText.LastIndexOf ('\u000a') == -1) ||
					    (newText.LastIndexOf ('\u000a') != (newText.Length - 1))) {
						Window.MakeFirstResponder (textBox);
						return;
					} else {

						;
					}

				};

				button.Activated += (sender, e) => {

					_usrName = userName.StringValue;
					_IRN = irn.StringValue;

					var binding = new NetTcpBinding ();
					binding.Security.Mode = SecurityMode.None;
					var address = new EndpointAddress ("net.tcp://www.techiechat.net:22222/WCFService/RF.WCF.Callback.Server");
					DuplexChannelFactory<IServerWithCallback> cf = 
						new DuplexChannelFactory<IServerWithCallback> (
							new CallbackImpl (),
							binding,
							address);

					srv = cf.CreateChannel ();

					srv.NewUser (
						new Person () { Username = _usrName,
							UserID = _IRN
						});


					NSView[] ourViews = Window.ContentView.Subviews; 

					for (int i = 0; i < 3; i++)
						ourViews [i].RemoveFromSuperview ();

					Window.SetFrame (new System.Drawing.RectangleF (10, 160, screenWidth - 670, 150), true);
					Window.Title = "chat";
					Window.ContentView.AddSubview (textBox);

//				NSApplication.SharedApplication.Terminate (this);

				};

				button.SetButtonType (NSButtonType.MomentaryPushIn);
				button.BezelStyle = NSBezelStyle.Rounded;

//			userName.Bordered = false;

				Window.ContentView.AddSubview (userName);
				Window.ContentView.AddSubview (irn);
				Window.ContentView.AddSubview (button);
				Window.MakeFirstResponder (button);

			} else {

				CallbackImpl.InitializeEvent += (sender, e) => { 

					Window.SetFrame( new System.Drawing.RectangleF(10, 600, 500,300), true );

					//				Window.SetFrame( new System.Drawing.RectangleF(100, 600, 500, 300), true );
				};


			}
		}

		public void createVBWindow( )
		{

		}

		void OnAbout (object sender, EventArgs e)
		{
			using (var alert = NSAlert.WithMessage("Info", "Ok", null, null, "Cocoa mit MonoMac"))
			{
				alert.RunModal();
			}
		}

		void OnQuit (object sender, EventArgs e)
		{
			NSApplication.SharedApplication.Terminate(this);
		}

/*
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
*/
	}
}

