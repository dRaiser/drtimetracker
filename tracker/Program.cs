using System;
using Gtk;
using System.Collections.Generic;
using System.Timers;

namespace tracker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();

			try
			{
				Task.loadAll();
			}
			catch (Exception E)
			{
				//Error loading file, create
				new Task("2017");
				Task.saveAll();
			}

			MainWindow win = new MainWindow ();
			win.ShowAll ();
			Application.Run ();
		}
	}
}
