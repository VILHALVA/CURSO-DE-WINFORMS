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
using System.Windows.Forms;
using Mono.WebBrowser.DOM;
using System.Collections;

namespace standalone
{
	public class DomInspector : Form
	{
		private TreeView domTree;
		private INode topNode;
		private IElementCollection elementCollection;
		private IAttributeCollection attributeCollection;
		private IStylesheetList stylesheetList;
		private IWindowCollection windows;
		ArrayList nodeList;
		Page helper;
		MainForm main;
		ContextMenu popupmenu;
		
		public INode TopNode {
			get {return topNode;}
			set {
				topNode = value;
				RefreshTree ();
			}
		}

		public IElementCollection ElementCollection {
			get {return elementCollection;}
			set {
				elementCollection = value;
				RefreshCollectionTree ();
			}
		}


		public IAttributeCollection AttributeCollection {
			get {return attributeCollection;}
			set {
				attributeCollection = value;
				RefreshCollectionTree2 ();
			}
		}

		public IStylesheetList StylesheetList {
			get {return stylesheetList;}
			set {
				stylesheetList = value;
				RefreshCollectionTree3 ();
			}
		}

		public IWindowCollection Windows {
			get {return windows;}
			set {
				windows = value;
				RefreshCollectionTree4 ();
			}
		}

		public DomInspector (Page p, MainForm m)
		{
			helper = p;
			main = m;

			nodeList = new ArrayList ();
			domTree = new TreeView ();
			popupmenu = new ContextMenu (new MenuItem[] { 
				new MenuItem ("Select this node", delegate (object sender, EventArgs e) {
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
				}),

				new MenuItem ("Children", delegate (object sender, EventArgs e) {
					helper.NewRootNode = nodeList[int.Parse (domTree.SelectedNode.Name)] as IElement;
				}),
				new MenuItem ("InnerText", delegate (object sender, EventArgs e) {
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as IElement;
					helper.getInnerText (); 	
				}),
				new MenuItem ("InnerHTML",	delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as IElement;
					helper.getInnerHTML (); 
				}),
				new MenuItem ("OuterText", delegate (object sender, EventArgs e) {
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as IElement;
					helper.getOuterText (); 	
				}),
				new MenuItem ("OuterHTML",	delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as IElement;
					helper.getOuterHTML (); 
				}),
				new MenuItem ("LocalName",	delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.getLocalName (); 
				}),
				new MenuItem ("Style",	delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.getStyle (); 
				}),
				new MenuItem ("TabIndex",	delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.getTabIndex (); 
				}),
				new MenuItem ("Value",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.getValue (); 
				}),
				new MenuItem ("Type",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.getType (); 
				}),
				new MenuItem ("Attach Click Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.Click += new NodeEventHandler (helper.Click);
				}),
				new MenuItem ("Detach Click Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.Click -= new NodeEventHandler (helper.Click);
				}),
				new MenuItem ("Attach KeyDown Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.KeyDown += new NodeEventHandler (helper.KeyDown);
				}),
				new MenuItem ("Detach KeyDown Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.KeyDown -= new NodeEventHandler (helper.KeyDown);
				}),
				new MenuItem ("Attach KeyPress Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.KeyPress += new NodeEventHandler (helper.KeyPress);
				}),
				new MenuItem ("Detach KeyPress Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.KeyPress -= new NodeEventHandler (helper.KeyPress);
				}),
				new MenuItem ("Attach KeyUp Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.KeyUp += new NodeEventHandler (helper.KeyUp);
				}),
				new MenuItem ("Detach KeyUp Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.KeyUp -= new NodeEventHandler (helper.KeyUp);
				}),
				new MenuItem ("Attach DoubleClick Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.DoubleClick += new NodeEventHandler (helper.DoubleClick);
				}),
				new MenuItem ("Detach DoubleClick Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.DoubleClick -= new NodeEventHandler (helper.DoubleClick);
				}),
				new MenuItem ("Attach MouseDown Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseDown += new NodeEventHandler (helper.MouseDown);
				}),
				new MenuItem ("Detach MouseDown Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseDown -= new NodeEventHandler (helper.MouseDown);
				}),
				new MenuItem ("Attach MouseEnter Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseEnter += new NodeEventHandler (helper.MouseEnter);
				}),
				new MenuItem ("Detach MouseEnter Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseEnter -= new NodeEventHandler (helper.MouseEnter);
				}),
				new MenuItem ("Attach MouseLeave Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseLeave += new NodeEventHandler (helper.MouseLeave);
				}),
				new MenuItem ("Detach MouseLeave Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseLeave -= new NodeEventHandler (helper.MouseLeave);
				}),
				new MenuItem ("Attach MouseMove Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseMove += new NodeEventHandler (helper.MouseMove);
				}),
				new MenuItem ("Detach MouseMove Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseMove -= new NodeEventHandler (helper.MouseMove);
				}),
				new MenuItem ("Attach MouseOver Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseOver += new NodeEventHandler (helper.MouseOver);
				}),
				new MenuItem ("Detach MouseOver Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseOver -= new NodeEventHandler (helper.MouseOver);
				}),
				new MenuItem ("Attach MouseUp Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseUp += new NodeEventHandler (helper.MouseUp);
				}),
				new MenuItem ("Detach MouseUp Event",delegate (object sender, EventArgs e) { 
					helper.lastNodeFetched = nodeList[int.Parse (domTree.SelectedNode.Name)] as INode;
					helper.lastNodeFetched.MouseUp -= new NodeEventHandler (helper.MouseUp);
				})
			});

			domTree.Dock = DockStyle.Fill;
			this.Controls.Add (domTree);

		}
		
		public void RefreshTree ()
		{
			nodeList.Clear ();
			domTree.Nodes.Clear ();
			if (topNode is IElement)
				LoadAll (domTree.Nodes, topNode as IElement);
			else
				LoadChildren (domTree.Nodes, topNode);
		}
		
		private void LoadChildren (TreeNodeCollection where, INode node)
		{
			TreeNode t;
			INodeList nodes = node.ChildNodes;
			foreach (INode child in nodes) {
				string s = Enum.GetName (typeof (NodeType), child.Type);
				switch (child.Type) {
					case NodeType.Attribute:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.LocalName + "\t" + child.Value + "\t" + child.GetHashCode ());
						nodeList.Add (child);
						break;
					case NodeType.Element:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.LocalName + "\t" + child.GetHashCode ());
						nodeList.Add (child as IElement);
						LoadChildren (t.Nodes, child);
						break;
					case NodeType.Text:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.Value + "\t" + child.GetHashCode ());
						nodeList.Add (child);
						break;
					default:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + "\t" + child.GetHashCode ());
						nodeList.Add (child);
						break;
				}
				t.ContextMenu = popupmenu;
			}
		}
				

		private void LoadAll (TreeNodeCollection where, IElement node)
		{
			TreeNode t;
			IElementCollection nodes = node.All;
			foreach (IElement child in nodes) {
				string s = Enum.GetName (typeof (NodeType), child.Type);
				switch (child.Type) {
					case NodeType.Attribute:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.LocalName + "\t" + child.Value);
						nodeList.Add (child);
						break;
					case NodeType.Element:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.LocalName);
						nodeList.Add (child as IElement);
						LoadAll (t.Nodes, child);
						break;
					case NodeType.Text:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.Value);
						nodeList.Add (child);
						break;
					default:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s);
						nodeList.Add (child);
						break;
				}
				t.ContextMenu = popupmenu;
			}
		}


		public void RefreshCollectionTree ()
		{
			nodeList.Clear ();
			domTree.Nodes.Clear ();
			TreeNodeCollection where = domTree.Nodes;
			TreeNode t;
			foreach (IElement child in elementCollection) {
				string s = Enum.GetName (typeof (NodeType), child.Type);
				switch (child.Type) {
					case NodeType.Attribute:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.LocalName + "\t" + child.Value);
						nodeList.Add (child);
						break;
					case NodeType.Element:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.LocalName);
						nodeList.Add (child as IElement);
						LoadChildren (t.Nodes, child);
						break;
					case NodeType.Text:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s + ":" + child.Value);
						nodeList.Add (child);
						break;
					default:
						t = where.Add (nodeList.Count.ToString (), nodeList.Count.ToString () + "\t" + s);
						nodeList.Add (child);
						break;
				}
				t.ContextMenu = popupmenu;
			}
		}

		public void RefreshCollectionTree2 ()
		{
			nodeList.Clear ();
			domTree.Nodes.Clear ();
			TreeNodeCollection where = domTree.Nodes;
			TreeNode t;
			Console.Error.WriteLine (attributeCollection.Count);
			foreach (IAttribute child in attributeCollection) {
				t = where.Add (nodeList.Count.ToString (), child.Name + "=" + child.Value);
				nodeList.Add (child);
				t.ContextMenu = popupmenu;
			}
		}			
		public void RefreshCollectionTree3 ()
		{
			nodeList.Clear ();
			domTree.Nodes.Clear ();
			TreeNodeCollection where = domTree.Nodes;
			TreeNode t;
			Console.Error.WriteLine (stylesheetList.Count);
			foreach (IStylesheet child in stylesheetList) {
				t = where.Add (nodeList.Count.ToString (), child.Href);
				nodeList.Add (child);
				t.ContextMenu = popupmenu;
			}
		}			

		public void RefreshCollectionTree4 ()
		{
			nodeList.Clear ();
			domTree.Nodes.Clear ();
			TreeNodeCollection where = domTree.Nodes;
			TreeNode t;
			Console.Error.WriteLine (windows.Count);
			foreach (IWindow child in windows) {
				t = where.Add (nodeList.Count.ToString (), child.Name);
				nodeList.Add (child);
				t.ContextMenu = popupmenu;
			}
		}			

	}
}
