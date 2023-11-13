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
//

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace webbrowser.tests
{	
	struct Handler {
		public string name;
		public EventHandler handler;
		public Handler (string name, EventHandler handler) {
			this.name = name;
			this.handler = handler;
		}
	}
	public class controls : Form
	{
		main main;
		List<Handler> handlers = new List<Handler> ();
		Panel left;
		Splitter splitter;
		Panel right;
		ListView results;
		
		public controls (main main)
		{
			this.main = main;
			this.StartPosition = FormStartPosition.Manual;
			left = new Panel ();
			left.Dock = DockStyle.Left;
			splitter = new Splitter ();
			splitter.Dock = DockStyle.Left;
			right = new Panel ();
			right.Dock = DockStyle.Fill;
			
			results = new ListView();
			results.Dock = DockStyle.Fill;
			results.View = View.Details;
			results.Columns.Add ("");
			right.Controls.Add (results);
			
			setupHandlers ();
			this.Controls.Add (right);
			this.Controls.Add (splitter);
			this.Controls.Add (left);
			
		}
		
		void setupHandlers () {
			handlers.Add (new Handler ("Quit", delegate (object sender, EventArgs e) {Application.Exit ();}));
			handlers.Add (new Handler ("load blank page", new EventHandler (loadBlankPage)));
			handlers.Add (new Handler ("load test page", new EventHandler (loadTestPage)));
			handlers.Add (new Handler ("test CanGoBack", new EventHandler (canGoBack)));
			handlers.Add (new Handler ("test CanGoForward", new EventHandler (canGoForward)));
			handlers.Add (new Handler ("test DocumentText", new EventHandler (documentText)));
			
			Button button;
			
			int x = 0, y = 0, sizeX = 120, sizeY = 30, spacing = 2, colLimit = 10;
			
			foreach (Handler handler in handlers) {
				button = new Button ();
				button.Text = handler.name;
				button.Size = new Size (sizeX - spacing, sizeY - spacing);
				button.Location = new Point(x, y);
				button.Click += handler.handler;
				left.Controls.Add (button);
				y += sizeY;
				if (y > sizeY * colLimit) {
					y = 0;
					x += sizeX;
				}
			}
		}
		
		int loadCount = 0;
		int pos = 0;
		int navigated = 0;
		
		private void loadBlankPage (object sender, EventArgs e) {
			main.webBrowser.Navigate ("about:blank");
			loadCount++;
		}
		
		private void loadTestPage (object sender, EventArgs e) {	
			main.webBrowser.Navigate (System.IO.Path.Combine ("file://" + AppDomain.CurrentDomain.BaseDirectory, "test.html"));
			loadCount++;
		}
		
		private void canGoBack (object sender, EventArgs e) {
			if (pos == 0 && !main.webBrowser.CanGoBack)
				message (sender, "Success - cannot go back");
			else if (pos > 0 && main.webBrowser.CanGoBack)
				message (sender, "Success - can go back");
			else
				message (sender, "Failure");
		}
		
		private void canGoForward (object sender, EventArgs e) {
			if (navigated == 0 && !main.webBrowser.CanGoForward)
				message (sender, "Success: cannot go forward");
			else if (navigated > 0 && main.webBrowser.CanGoForward)
				message (sender, "Success: can go forward");
			else
				message (sender, "Failure");
		}
		
		private void goBack (object sender, EventArgs e) {
			if (pos > 0 && main.webBrowser.CanGoBack) {
				pos--;
				main.webBrowser.GoBack ();
				message (sender, "Success: went forward");
			} else
				message (sender, "Warning: Cannot go back");

		}
		
		private void goForward (object sender, EventArgs e) {
			if (main.webBrowser.CanGoForward) {
				pos++;
				main.webBrowser.GoForward ();
				message (sender, "Success");
			} else
				message (sender, "Warning: Cannot go forward");
		}

		private void documentText (object sender, EventArgs e) {
		}
		
		
		void message (object button, string msg) {
			results.Items.Add(((Button)button).Text + " - " + msg);
		}
	}
}
