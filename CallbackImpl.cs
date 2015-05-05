using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CommonParts;
using System.Windows.Forms;

  using MonoMac.Foundation;
using MonoMac.AppKit;
  using MonoMac.ObjCRuntime;

namespace techchat
{
	public class CallbackImpl : IDataOutputCallback
	{
//		Form2 clientForm;
		int counter;

		vbWindowController virtualWindowController;

		ServerWindowController serverWindowController;
		AppDelegate1 serverDelegate;

		public delegate void InitializeHandler ( object CallbackImpl, UserListArgs userList );
		public static InitializeHandler InitializeEvent;

		#region IDataOutputCallback Members

		public void SendDataPacket(string data)
		{
			;
		}


		public void InitializeClient(List<string> usernames)
		{
			counter = 0;

			UserListArgs userList = new UserListArgs (usernames);

			virtualWindowController = new vbWindowController ();
			virtualWindowController.ShowWindow (null);


			if (InitializeEvent != null) {
				  InitializeEvent (this, userList);
			}

			string[] args = {"0", "1"};

			NSApplication.Init ();
			NSApplication.SharedApplication.Delegate = new AppDelegate1 ();
			NSApplication.Main ( args );

	//		serverDelegate = new AppDelegate1();

//			serverWindowController = new ServerWindowController ();
/*
			NSApplication NSApplication1 = NSApplication.SharedApplication;

			NSApplication1.Delegate = null;
			NSApplication1.Run ();
*/

//			NSApplication.Init ();
//			NSApplication1.SharedApplication.Delegate = new AppDelegate1( );




			/*
            clientForm = new Form2();
            clientForm.ClientSize = new System.Drawing.Size(1032, 510);

			//			clientForm = new ClientFormR();
						clientForm.Activate();
						clientForm.Visible = true;

			*/
			/*

			// 
			// lstBox
			// 
			clientForm.lstBox.BackColor = System.Drawing.SystemColors.Control;
			clientForm.lstBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			clientForm.lstBox.ColumnWidth = 50;
			clientForm.lstBox.FormattingEnabled = true;
			clientForm.lstBox.HorizontalExtent = 400;
			clientForm.lstBox.Location = new System.Drawing.Point(576, 66);
			clientForm.lstBox.MultiColumn = true;
			clientForm.lstBox.Name = "lstUsers";
			clientForm.lstBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			clientForm.lstBox.Size = new System.Drawing.Size(414, 13);
			clientForm.lstBox.TabIndex = 21;

			clientForm.Controls.Add(clientForm.lstBox);
			*/
			//			clientForm.lstUsers.DataSource = usernames;

		}

		public void UpdateStatus(List<string> usernames)
		{
			//			clientForm.lstUsers.DataSource = usernames;
		}

		public void ChatData(ChatMessage chatmessage)
		{
			//			clientForm.InsertMessage(chatmessage);
		}

		public void printCallback(printChoice pChoice)
		{
			switch (pChoice)
			{
			case printChoice.Visible:
//				clientForm.printText();
				break;

			case printChoice.All:
//				clientForm.printAllText();
				break;

			case printChoice.Graph:
//				clientForm.printGraph();
				break;
			}
		}

		public void narrateCallback()
		{
//			clientForm.narrate = !clientForm.narrate;
			;
		}




		#endregion
	}

	public class UserListArgs : EventArgs
	{
		public List <string> userList;

		public UserListArgs( List <string> UserList )
		{
			this.userList = UserList;
		}
	}
}


