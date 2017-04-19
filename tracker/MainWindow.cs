using System;
using System.Timers;
using System.Collections.Generic;
using Gtk;
using tracker;

public partial class MainWindow: Gtk.Window
{
	private Image pauseBtnImage;
	TreeStore taskListStore;
	TreeIter currTaskIter;
	TreeIter trackedTaskIter;
	private int selTaskId = -1;
	private bool reloading = false;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		TreeViewColumn taskIdCol = new TreeViewColumn();
		taskIdCol.Title = "";

		TreeViewColumn taskNameCol = new TreeViewColumn();
		taskNameCol.Title = "Task";

		TreeViewColumn taskTimeCol = new TreeViewColumn();
		taskTimeCol.Title = "Time";

		CellRendererText taskIdCell = new CellRendererText();
		CellRendererText taskNameCell = new CellRendererText();
		CellRendererText taskTimeCell = new CellRendererText();

		//taskIdCol.PackStart(taskIdCell, true); //to HIDE column
		taskNameCol.PackStart(taskNameCell, true);
		taskTimeCol.PackStart(taskTimeCell, true);

		taskList.AppendColumn(taskIdCol);
		taskList.AppendColumn(taskNameCol);
		taskList.AppendColumn(taskTimeCol);

		taskIdCol.AddAttribute(taskIdCell, "text", 0);
		taskNameCol.AddAttribute(taskNameCell, "text", 1);
		taskTimeCol.AddAttribute(taskTimeCell, "text", 2);

		reloadTasks();

		taskList.Selection.Changed += (sender, e) =>
		 {
			 try
			 {
				 if (!reloading)
				 {
					 taskList.Selection.GetSelected(out currTaskIter);
					 selTaskId = Int32.Parse(((String)taskList.Model.GetValue(currTaskIter, 0)));
				 }
			 }
			 catch (Exception ex)
			 {
			 }
		 };

		pauseBtnImage = new Image(Stock.MediaPlay, IconSize.Button);
		VBox box = new VBox();
		box.PackStart(pauseBtnImage, true, true, 0);
		pauseBtn.Add(box);

		Timer timer = new Timer();
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		timer.Interval = 1000;
		timer.Enabled = true;
	}

	private void reloadTasks()
	{
		reloading = true;
		Task.currTaskId = -1;
		selTaskId = -1;
		Task.loadAll();
		taskListStore = new TreeStore(typeof(string), typeof(string), typeof(string));

		List<Task> topTasks = Task.getTasksByParent(-1);
		for (int i = 0; i < topTasks.Count; i++)
		{
			TreeIter iter = taskListStore.AppendValues(topTasks[i].id.ToString(), topTasks[i].name, topTasks[i].getNiceTime());

			List<Task> midTasks = Task.getTasksByParent(topTasks[i].id);
			for (int j = 0; j < midTasks.Count; j++)
			{
				TreeIter iter2 = taskListStore.AppendValues(iter, midTasks[j].id.ToString(), midTasks[j].name, midTasks[j].getNiceTime());

				List<Task> lowTasks = Task.getTasksByParent(midTasks[j].id);
				for (int k = 0; k < lowTasks.Count; k++)
				{
					taskListStore.AppendValues(iter2, lowTasks[k].id.ToString(), lowTasks[k].name, lowTasks[k].getNiceTime());
				}
			}
		}

		taskList.Model = taskListStore;
		reloading = false;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnPauseBtnClicked(object sender, EventArgs e)
	{
		if (selTaskId != -1)
		{
			Task.currTaskId = selTaskId;
			trackedTaskIter = currTaskIter;

			if (!Task.tracking)
			{
				pauseBtnImage.Stock = Stock.MediaPause;
			}
			else
			{
				pauseBtnImage.Stock = Stock.MediaPlay;
			}

			Task.tracking = !Task.tracking;
		}
	}

	private void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		if (Task.currTaskId != -1 && Task.tracking)
		{
			Task.getTask(Task.currTaskId).increaseTime();
			taskList.Model.SetValue(trackedTaskIter, 2, Task.getTask(Task.currTaskId).getNiceTime());
			Task.saveAll();
		}
	}

	protected void OnTaskListRowActivated(object o, RowActivatedArgs args)
	{
		taskList.Model.GetIter(out currTaskIter, args.Path);
		taskList.Model.GetIter(out trackedTaskIter, args.Path);
		int lastCurrTaskId = Task.currTaskId;
		Task.currTaskId = Int32.Parse((String)taskList.Model.GetValue(currTaskIter, 0));
		selTaskId = Task.currTaskId;

		if(lastCurrTaskId != Task.currTaskId)
			Task.tracking = false;
		OnPauseBtnClicked(o, (EventArgs)args);
	}

	protected void OnAddTopTaskActionActivated(object sender, EventArgs e)
	{
		TextDialog textDialog = new TextDialog();
		textDialog.Response += delegate (object o, ResponseArgs resp) {
			if (resp.ResponseId == ResponseType.Ok)
			{
				new Task(textDialog.returnVal);
				Task.saveAll();
				reloadTasks();
			}
		};
		textDialog.Run();
		textDialog.Destroy();
	}

	protected void OnExitActionActivated(object sender, EventArgs e)
	{
		Application.Quit();
	}

	protected void OnDeleteTaskAndChildrenActionActivated(object sender, EventArgs e)
	{
	//TEMP disabled.
	/*	if (Task.currTaskId != -1)
		{
			Task.getTask(Task.currTaskId).delete();
			reloadTasks();
		}
		*/
	}

	protected void OnAddChildTaskActionActivated(object sender, EventArgs e)
	{
		TextDialog textDialog = new TextDialog();
		textDialog.Response += delegate (object o, ResponseArgs resp)
		{
			if (resp.ResponseId == ResponseType.Ok)
			{
				new Task(textDialog.returnVal, selTaskId);
				Task.saveAll();
				reloadTasks();
			}
		};
		textDialog.Run();
		textDialog.Destroy();
	}

	protected void OnResetTimeActionActivated(object sender, EventArgs e)
	{
		try
		{
			Task.getTask(selTaskId).resetTime();
			Task.saveAll();
			reloadTasks();
		}
		catch (Exception ex)
		{
		}
	}

	protected void OnAboutActionActivated(object sender, EventArgs e)
	{
		AboutDialog about = new AboutDialog();
		about.ProgramName = "timeTracker";
		about.Version = "0.1";
		about.Copyright = "(c) Paweł Wolak 'dRaiser'";
		about.Comments = @"Simple time tracker for tasks.";
		about.Website = "http://draiser.net";
		//about.Logo = new Gdk.Pixbuf("stock_alarm.png");
		about.Run();
		about.Destroy();
		
	}
}
