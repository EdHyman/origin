using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace techchat
{
	class MainClass
	{
		static void Main (string[] args)
		{
			NSApplication.Init ();

			// Delegate zuweisen, da keine Nib-Datei vorhanden ist.
			NSApplication.SharedApplication.Delegate = new AppDelegate();

			NSApplication.Main (args);
		}
	}
}

