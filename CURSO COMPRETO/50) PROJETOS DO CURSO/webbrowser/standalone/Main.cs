// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2008 Novell, Inc.
//
// Authors:
//	Andreia Gaita (avidigal@novell.com)



using System;
using System.Drawing;
using System.Windows.Forms;
using Mono.WebBrowser;
using Mono.WebBrowser.DOM;
using System.ComponentModel;

namespace standalone
{
	public class MainForm : Form
	{
		public static void Main ()
		{
			Application.Run (new MainForm ());
		}
		
		public MainForm ()
		{
			helper = new Page (this);
			gui ();
			loadWebHost ();	
			address.Text = System.IO.Path.Combine ("file://" + AppDomain.CurrentDomain.BaseDirectory, "test.html");
			helper.TextChanged += delegate (string text) {body.AppendText (text + "\r\n");};
			helper.RootNodeChanged += delegate () {
				DomInspector d = new DomInspector(helper, this);
				d.TopNode = helper.lastNodeFetched;
				d.Show ();
			};

			helper.ElementCollectionChanged += delegate () {
				DomInspector d = new DomInspector(helper, this);
				d.ElementCollection = helper.ElementCollection;
				d.Show ();
			};

			helper.AttributeCollectionChanged += delegate () {
				DomInspector d = new DomInspector(helper, this);
				d.AttributeCollection = helper.AttributeCollection;
				d.Show ();
			};

			helper.StylesheetListChanged += delegate () {
				DomInspector d = new DomInspector(helper, this);
				d.StylesheetList = helper.StylesheetList;
				d.Show ();
			};

		}
		
		protected override void OnClosed (EventArgs e)
		{
			base.OnClosed (e);
			webHost.Shutdown ();
		}
		
		private void navigate (object sender, EventArgs e)
		{
			helper.lastNodeFetched = null;
			webHost.Navigation.Go (address.Text);
		}

		private void forward (object sender, EventArgs e)
		{
			helper.lastNodeFetched = null;
			webHost.Navigation.Forward ();
		}

		private void back (object sender, EventArgs e)
		{
			helper.lastNodeFetched = null;
			webHost.Navigation.Back ();
		}

		private void updateInspector ()
		{
			if (helper.document != null)
				domInspector.TopNode = helper.document;
		}
		
		private void openInspector (object sender, EventArgs e)
		{
			updateInspector ();
			if (!domInspector.Visible)
				domInspector.Show ();
		}
	
		private void openEventMonitor (object sender, EventArgs e) {
			if (helper.lastNodeFetched == null)
				return;
			EventMonitor monitor = new EventMonitor(helper.lastNodeFetched);
			monitor.Show ();
		}

		private void loadWebHost () 
		{
			webHost = Manager.GetNewInstance ();
			loaded = webHost.Load (control.Handle, control.Width, control.Height);
			if (!loaded) return;
			
			/*
			webHost.Focus += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: Focus");
			};
			
			webHost.CreateNewWindow += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: CreateNewWindow");
			};
			
			webHost.KeyDown += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: KeyDown");
			};
			webHost.KeyUp += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: KeyUp");
			};
			webHost.KeyPress += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: KeyPress");
			};

			webHost.MouseDown += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: MouseDown");
			};
			webHost.MouseUp += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: MouseUp");
			};
			*/
			webHost.MouseClick += delegate (object sender, Mono.WebBrowser.DOM.NodeEventArgs e) {
				Console.Error.WriteLine ("webHost: MouseClick " + e.Node.GetHashCode());
			};
			/*
			webHost.MouseDoubleClick += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: MouseDoubleClick");
			};
			webHost.MouseEnter += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: MouseEnter");
			};
			webHost.MouseLeave += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: MouseLeave");
			};
			webHost.Generic += delegate (object sender, EventArgs e) {
				Console.Error.WriteLine ("webHost: Generic" + sender);
			};
			*/
			
			webHost.Alert += delegate (object sender, Mono.WebBrowser.AlertEventArgs  e) {
				Console.Error.WriteLine ("alert: " + e.Text);
			};

			webHost.StatusChanged += delegate (object sender, Mono.WebBrowser.StatusChangedEventArgs e) {
				lblStatus.Text = e.Message;
			};

			webHost.LoadStarted += delegate (object sender, LoadStartedEventArgs e) {
				Console.Error.WriteLine ("LoadStarted");
			};
			webHost.LoadCommited += delegate (object sender, LoadCommitedEventArgs e) {
				Console.Error.WriteLine ("LoadCommited");
			};
			webHost.ProgressChanged += delegate (object sender, Mono.WebBrowser.ProgressChangedEventArgs e) {
				Console.Error.WriteLine ("ProgressChanged " + e.Progress + " " + e.MaxProgress);
			};
			webHost.LoadFinished += delegate (object sender, LoadFinishedEventArgs e) {
				Console.Error.WriteLine ("LoadFinished");
				helper.document = webHost.Document;
				updateInspector ();				
			};
			
			webHost.SecurityChanged += delegate (object sender, Mono.WebBrowser.SecurityChangedEventArgs e) {
				Console.Error.WriteLine ("securityChanged " + e.State);
			};
				
		}


		private void gui () 
		{
			
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Size = new Size (650, 650);

			menu = new MenuStrip ();

			menu.Items.Add ("Dom Inspector", null, new EventHandler (openInspector));
			menu.Items.Add ("Event Monitor", null, new EventHandler (openEventMonitor));
			
			ToolStripMenuItem menu1 = null;
			ToolStripMenuItem menu2 = null;
			ToolStripMenuItem menu3 = null;
			ToolStripTextBox menutxt = null;

			menu1 = new ToolStripMenuItem ("Browser");
			menu.Items.Add (menu1);

			menu2 = new ToolStripMenuItem ("Render data", null, delegate {
			//    webHost.OpenStream ("file:///", "text/html");
			//    webHost.AppendToStream (body.Text);
			//    webHost.CloseStream ();
			});
			menu1.DropDownItems.Add (menu2);


			menu2 = new ToolStripMenuItem ("Scrollbars");
			menu1.DropDownItems.Add (menu2);

			menu3 = new ToolStripMenuItem ("Enable", null, delegate {
				helper.setScrollbars (true);
			});
			menu2.DropDownItems.Add (menu3);
			
			menu3 = new ToolStripMenuItem ("Disable", null, delegate {
				helper.setScrollbars (false);
			});
			menu2.DropDownItems.Add (menu3);
			
			menu3 = new ToolStripMenuItem ("Get Value", null, delegate {
				helper.getScrollbars ();
			});
			menu2.DropDownItems.Add (menu3);

			menu2 = new ToolStripMenuItem ("RTL");
			menu1.DropDownItems.Add (menu2);

			menu3 = new ToolStripMenuItem ("Enable", null, delegate {
				helper.RightToLeft = true;
			});
			menu2.DropDownItems.Add (menu3);
			
			menu3 = new ToolStripMenuItem ("Disable", null, delegate {
				helper.RightToLeft = false;
			});
			menu2.DropDownItems.Add (menu3);
			
			menu3 = new ToolStripMenuItem ("Get Value", null, delegate {
				bool a = helper.RightToLeft;
			});
			menu2.DropDownItems.Add (menu3);
			
			menu2 = new ToolStripMenuItem ("Windows", null, delegate {
				helper.getWindows ();
			});
			menu1.DropDownItems.Add (menu2);
			
			/*** Document ***/
			
			menu1 = new ToolStripMenuItem ("Document");
			menu.Items.Add (menu1);
			
			menu2 = new ToolStripMenuItem ("Title");	
			menu1.DropDownItems.Add (menu2);
			
			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu3 = new ToolStripMenuItem ("Get", null, delegate{
				helper.getTitle ();
			});
			menu2.DropDownItems.Add (menu3);


			menu3 = new ToolStripMenuItem ("Set", null, delegate(object sender, EventArgs e) {
				helper.setTitle (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});			
			menu2.DropDownItems.Add (menu3);
			
			menu2 = new ToolStripMenuItem ("Get DocumentElement", null, delegate {
				helper.getDocumentElement ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Get Body", null, delegate  {
				helper.getBody ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Get Active Element", null, delegate  {
				helper.getActiveElement ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Get Element");
			menu1.DropDownItems.Add (menu2);

			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);
			
			menu3 = new ToolStripMenuItem ("By ID", null, delegate (object sender, EventArgs e) {
				helper.getElementById (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});
			menu2.DropDownItems.Add (menu3);

			menu3 = new ToolStripMenuItem ("By Location", null, delegate (object sender, EventArgs e) {
				string s = ((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text;
				string[] point = s.Split (',');
				if (point.Length != 2) return;
				int x, y;
				if (!(int.TryParse(point[0], out x))) return;
				if (!(int.TryParse(point[1], out y))) return;
				helper.getElement (x, y);
			});
			menu2.DropDownItems.Add (menu3);

			menu2 = new ToolStripMenuItem ("Encoding");	
			menu1.DropDownItems.Add (menu2);
			
			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu3 = new ToolStripMenuItem ("Get", null, delegate {
				helper.getCharset ();
			});
			menu2.DropDownItems.Add (menu3);


			menu3 = new ToolStripMenuItem ("Set", null, delegate(object sender, EventArgs e) {
				helper.setCharset (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});			
			menu2.DropDownItems.Add (menu3);


			menu2 = new ToolStripMenuItem ("Cookie");	
			menu1.DropDownItems.Add (menu2);
			
			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu3 = new ToolStripMenuItem ("Get", null, delegate {
				helper.getCookie ();
			});
			menu2.DropDownItems.Add (menu3);


			menu3 = new ToolStripMenuItem ("Set", null, delegate(object sender, EventArgs e) {
				helper.setCookie (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});			
			menu2.DropDownItems.Add (menu3);


			menu2 = new ToolStripMenuItem ("Attributes", null, delegate  {
				helper.getAttributes ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Anchors", null, delegate  {
				helper.getAnchors ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Applets", null, delegate  {
				helper.getApplets ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Forms", null, delegate  {
				helper.getForms ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Images", null, delegate  {
				helper.getImages ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Links", null, delegate  {
				helper.getLinks ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Stylesheets", null, delegate  {
				helper.getStylesheets ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Url", null, delegate  {
				helper.getUrl ();
			});
			menu1.DropDownItems.Add (menu2);


			menu2 = new ToolStripMenuItem ("Script");	
			menu1.DropDownItems.Add (menu2);
			
			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu3 = new ToolStripMenuItem ("Invoke", null, delegate(object sender, EventArgs e) {
				body.AppendText (helper.invokeScript (((ToolStripTextBox) ((ToolStripMenuItem) ((ToolStripMenuItem) sender).OwnerItem).DropDownItems[0]).Text));
			});
			menu2.DropDownItems.Add (menu3);
			
			
			/***** Element *********/
			
			menu1 = new ToolStripMenuItem ("Element");
			menu.Items.Add (menu1);
			
			menu2 = new ToolStripMenuItem ("Attribute");	
			menu1.DropDownItems.Add (menu2);
			
			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu3 = new ToolStripMenuItem ("Has", null, delegate(object sender, EventArgs e) {
				helper.hasAttribute (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});
			menu2.DropDownItems.Add (menu3);

			menu3 = new ToolStripMenuItem ("Get", null, delegate(object sender, EventArgs e) {
				helper.getAttribute (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});			
			menu2.DropDownItems.Add (menu3);

			menu3 = new ToolStripMenuItem ("Set", null, delegate(object sender, EventArgs e) {
				helper.setAttribute (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text, 
					((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[ ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems.Count - 1 ]).Text);
			});			
			menu2.DropDownItems.Add (menu3);

			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu2 = new ToolStripMenuItem ("Show Children", null, delegate  {
				helper.getChildren ();
			});
			menu1.DropDownItems.Add (menu2);


			menu2 = new ToolStripMenuItem ("FirstChild", null, delegate  {
				helper.getFirstChild ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("InnerHTML", null, delegate  {
				helper.getInnerHTML ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("InnerText", null, delegate  {
				helper.getInnerText ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("OuterHTML");
			menu1.DropDownItems.Add (menu2);

			menu3 = new ToolStripMenuItem ("Get", null, delegate {
				helper.getOuterHTML ();
			});			
			menu2.DropDownItems.Add (menu3);

			menu3 = new ToolStripMenuItem ("Set", null, delegate {
				helper.setOuterHTML (body.Text);
			});			
			menu2.DropDownItems.Add (menu3);
			
			menu2 = new ToolStripMenuItem ("OuterText", null, delegate  {
				helper.getOuterText ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("LocalName", null, delegate  {
				helper.getLocalName ();
			});
			menu1.DropDownItems.Add (menu2);

			menu2 = new ToolStripMenuItem ("Value", null, delegate  {
				helper.getValue ();
			});
			menu1.DropDownItems.Add (menu2);

			
			menu2 = new ToolStripMenuItem ("Events");	
			menu1.DropDownItems.Add (menu2);
			
			menutxt = new ToolStripTextBox ();
			menu2.DropDownItems.Add (menutxt);

			menu3 = new ToolStripMenuItem ("Fire", null, delegate(object sender, EventArgs e) {
				helper.fireEvent (((ToolStripTextBox)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[0]).Text);
			});
			menu2.DropDownItems.Add (menu3);

			menu2 = new ToolStripMenuItem ("Tab Index");
			menu1.DropDownItems.Add (menu2);

			menu3 = new ToolStripMenuItem ("Get", null, delegate {
				helper.getTabIndex ();
			});			
			menu2.DropDownItems.Add (menu3);

			menu3 = new ToolStripMenuItem ("Set", null, delegate {
				helper.setTabIndex (body.Text);
			});			
			menu2.DropDownItems.Add (menu3);

			
			menu2 = new ToolStripMenuItem ("Style");
			menu1.DropDownItems.Add (menu2);

			menu3 = new ToolStripMenuItem ("Get", null, delegate {
				helper.getStyle ();
			});			
			menu2.DropDownItems.Add (menu3);

			menu3 = new ToolStripMenuItem ("Set", null, delegate {
				helper.setStyle (body.Text);
			});			
			menu2.DropDownItems.Add (menu3);

			this.Controls.Add (menu);

			int top = menu.Height;

			// first line
			cmdBack = new Button ();
			cmdBack.Text = "<";			
			cmdBack.Size = new Size (30, 30);
			cmdBack.Click += new EventHandler (this.back);

			cmdForward = new Button ();
			cmdForward.Text = ">";			
			cmdForward.Size = new Size (30, 30);
			cmdForward.Click += new EventHandler (this.forward);

			
			Button cmdGetOuterHtml = new Button ();
			cmdGetOuterHtml.Text = "<";			
			cmdGetOuterHtml.Size = new Size (30, 30);
			cmdGetOuterHtml.Click += delegate  {
				this.helper.getOuterHTML();
			};

			Button cmdSetOuterHtml = new Button ();
			cmdSetOuterHtml.Text = "<";			
			cmdSetOuterHtml.Size = new Size (30, 30);
			cmdSetOuterHtml.Click += delegate  {
				this.helper.setOuterHTML (this.body.Text);
			};
			

			// second line
			lblBody = new Label ();
			lblBody.Text = "body";
			lblBody.Width = 60;
			
			body = new TextBox ();
			body.Multiline = true;
			body.Width = this.Width - lblBody.Width;
			body.Height = body.Height * 2;
			body.Anchor = (AnchorStyles) (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);


			// third line
			lblAddress = new Label ();
			lblAddress.Text = "address";
			lblAddress.Width = 60;

			cmdNavigate = new Button ();
			cmdNavigate.Text = "Navigate";			
			cmdNavigate.Size = new Size (100, 30);
			cmdNavigate.Click += new EventHandler (this.navigate);

			address = new TextBox ();
			address.Width = this.Width - lblAddress.Width - cmdNavigate.Width;
			address.Anchor = (AnchorStyles) (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Right);

			// fourth line
			control = new Control ();
			control.Size = this.ClientSize;
			this.Size = new Size (this.Width, this.Height - 150);
			control.Anchor = (AnchorStyles) (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right| AnchorStyles.Bottom);
			control.GotFocus += delegate  {
				Console.Error.WriteLine (" Control: GotFocus");
				Console.Error.WriteLine (Environment.StackTrace);
				webHost.FocusIn (FocusOption.FocusFirstElement);
			};
			control.LostFocus += delegate  {
				Console.Error.WriteLine (" Control: LostFocus");
				webHost.FocusOut ();
			};
			control.VisibleChanged += delegate  {
				Console.Error.WriteLine (" Control: VisibleChanged");
				if (webHost != null && control.Visible && !control.Disposing && !control.IsDisposed && loaded) {
					webHost.Activate ();
				} else if (webHost != null && loaded && !control.Visible) {
					webHost.Deactivate ();
				}
			};
			control.MouseClick += delegate (object sender, MouseEventArgs e) {
				Console.Error.WriteLine (" Control: MouseClick");
			};
			control.Resize += delegate  {
				webHost.Resize (control.Width, control.Height);
			};

			// bottom
			lblStatus = new Label ();
			lblStatus.Dock = DockStyle.Bottom;
			

			// positioning
			
			// first line
			cmdBack.Location = new Point (0, top);
			cmdForward.Location = new Point (cmdBack.Right, top);
			cmdGetOuterHtml.Location = new Point (cmdForward.Right, top);
			cmdSetOuterHtml.Location = new Point (cmdGetOuterHtml.Right, top);

			// second line
			top += 30;
			lblBody.Location = new Point (0, top);
			body.Location = new Point (lblBody.Right, top);
			
			// third line
			top += 60;
			lblAddress.Location = new Point (0, top);
			cmdNavigate.Location = new Point (lblAddress.Right, top);
			address.Location = new Point (cmdNavigate.Right, top);

			// fourth line
			top += 30;
			control.Location = new Point (0, top);

			// add
			this.Controls.Add (lblStatus);
			this.Controls.Add (control);			
			this.Controls.Add (cmdNavigate);
			this.Controls.Add (address);
			this.Controls.Add (lblAddress);
			this.Controls.Add (cmdBack);
			this.Controls.Add (cmdForward);
			this.Controls.Add (cmdGetOuterHtml);
			this.Controls.Add (cmdSetOuterHtml);			
			this.Controls.Add (body);
			this.Controls.Add (lblBody);		
			

			domInspector = new DomInspector (helper, this);
			domInspector.Closing += delegate (object sender, CancelEventArgs e) {
				e.Cancel = true;
				((Form)sender).Hide();
			};
		}

		private Label lblBody;
		private TextBox body;

		private Button cmdNavigate;
		private Button cmdForward;
		private Button cmdBack;
		
		private Label lblAddress;
		private TextBox address;

		private Control control;
		public IWebBrowser webHost;

		private Label lblStatus;

		const int BUTTON_WIDTH = 80;
		private Page helper;
		
		private MenuStrip menu;

		private DomInspector domInspector;
		private bool loaded;
	}
}
