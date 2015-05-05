using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace techchat
{
	public delegate void InitializeEventHandler( object sender, InitializeEventArgs e );

	public class InitializeEventArgs : System.EventArgs
	{
		private List<string> _usernames;

		public List<string> usernames
		{
			get {
				return this._usernames;
			}
		}

		private InitializeEventArgs ()
		{
		}

		public InitializeEventArgs( List<string> usernames )
		{
			this._usernames = usernames;
		}
	}
}

