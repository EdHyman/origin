using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.ServiceModel;
using CommonParts;

namespace techchat
{
	public class ServerWindowController : MonoMac.AppKit.NSWindowController
	{
		int screenHeight;
		int screenWidth;
		int upperBound;

		public event InitializeEventHandler InitializeEvent;

		public ServerWindowController () : base ("ServerWindow")
		{
			Initialize ();
		}

		void Initialize()
		{
			CreateWindow ();
		}

		void CreateWindow ()
		{
			Screen[] screens = Screen.AllScreens;
			upperBound = screens.GetUpperBound (0);
			screenHeight = screens [0].WorkingArea.Height;
			screenWidth = screens [0].WorkingArea.Width;

//			NSWindow fullScreenWindow;
			/*	NSWindow fullScreen */
//			Window = new NSWindow (new RectangleF (10, 600, 500, 300), NSWindowStyle.Borderless, NSBackingStore.Buffered, true);

			Window = new NSWindow (new RectangleF (10, 600,  screenWidth-670, 400), 
				NSWindowStyle.Titled | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable | NSWindowStyle.Resizable, 
				NSBackingStore.Buffered, false) {
				Title = "Register for Class",
				ReleasedWhenClosed = true,
				AcceptsMouseMovedEvents = true
			} ;

/*
			InitializeEvent += (object sender, InitializeEventArgs e) => {

			};
*/
			CallbackImpl.InitializeEvent += (sender, e) => { 

				Window.SetFrame( new System.Drawing.RectangleF(10, 160, screenWidth-670,150), true );

//				Window.SetFrame( new System.Drawing.RectangleF(100, 600, 500, 300), true );
			};
		}

/*
		public void InitializeWindow( CallbackImpl ourCallBack )
		{
			ourCallBack.InitializeEvent += new CallbackImpl.InitializeHandler (AdjustUserWindow);
		}
*/
		public void AdjustUserWindow( object ourCallBack, UserListArgs lArgs )
		{
			;

			Window.SetFrame( new System.Drawing.RectangleF(10, 800, screenWidth-670,600), true );
		}
	

//		protected Virtual Void OnInitializeEvent( InitializeEventArgs e) { if ( InitializeEvent != null ) { InitializeEvent(this,e); } } 


	}
}

