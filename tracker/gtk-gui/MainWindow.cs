
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action TaskAction;

	private global::Gtk.Action HelpAction;

	private global::Gtk.Action AddTopTaskAction;

	private global::Gtk.Action AddChildTaskAction;

	private global::Gtk.Action Action;

	private global::Gtk.Action EditTimeAction;

	private global::Gtk.Action Action1;

	private global::Gtk.Action ExitAction;

	private global::Gtk.Action AboutAction;

	private global::Gtk.Action DeleteTaskAndItSChildrenAction;

	private global::Gtk.Action DeleteTaskAndChildrenAction;

	private global::Gtk.Action ResetTimeAction;

	private global::Gtk.VBox vbox1;

	private global::Gtk.MenuBar menuBar;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView taskList;

	private global::Gtk.Button pauseBtn;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.TaskAction = new global::Gtk.Action("TaskAction", global::Mono.Unix.Catalog.GetString("Task"), null, null);
		this.TaskAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Task");
		w1.Add(this.TaskAction, null);
		this.HelpAction = new global::Gtk.Action("HelpAction", global::Mono.Unix.Catalog.GetString("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Help");
		w1.Add(this.HelpAction, null);
		this.AddTopTaskAction = new global::Gtk.Action("AddTopTaskAction", global::Mono.Unix.Catalog.GetString("Add top task"), null, null);
		this.AddTopTaskAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Add top task");
		w1.Add(this.AddTopTaskAction, null);
		this.AddChildTaskAction = new global::Gtk.Action("AddChildTaskAction", global::Mono.Unix.Catalog.GetString("Add child task"), null, null);
		this.AddChildTaskAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Add child task");
		w1.Add(this.AddChildTaskAction, null);
		this.Action = new global::Gtk.Action("Action", global::Mono.Unix.Catalog.GetString("-"), null, null);
		this.Action.ShortLabel = global::Mono.Unix.Catalog.GetString("-");
		w1.Add(this.Action, null);
		this.EditTimeAction = new global::Gtk.Action("EditTimeAction", global::Mono.Unix.Catalog.GetString("Edit time"), null, null);
		this.EditTimeAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Edit time");
		w1.Add(this.EditTimeAction, null);
		this.Action1 = new global::Gtk.Action("Action1", global::Mono.Unix.Catalog.GetString("-"), null, null);
		this.Action1.ShortLabel = global::Mono.Unix.Catalog.GetString("-");
		w1.Add(this.Action1, null);
		this.ExitAction = new global::Gtk.Action("ExitAction", global::Mono.Unix.Catalog.GetString("Exit"), null, null);
		this.ExitAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Exit");
		w1.Add(this.ExitAction, null);
		this.AboutAction = new global::Gtk.Action("AboutAction", global::Mono.Unix.Catalog.GetString("About"), null, null);
		this.AboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString("About");
		w1.Add(this.AboutAction, null);
		this.DeleteTaskAndItSChildrenAction = new global::Gtk.Action("DeleteTaskAndItSChildrenAction", global::Mono.Unix.Catalog.GetString("Delete task and it's children"), null, null);
		this.DeleteTaskAndItSChildrenAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Delete task and it's children");
		w1.Add(this.DeleteTaskAndItSChildrenAction, null);
		this.DeleteTaskAndChildrenAction = new global::Gtk.Action("DeleteTaskAndChildrenAction", global::Mono.Unix.Catalog.GetString("Delete task and children"), null, null);
		this.DeleteTaskAndChildrenAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Delete task and children");
		w1.Add(this.DeleteTaskAndChildrenAction, null);
		this.ResetTimeAction = new global::Gtk.Action("ResetTimeAction", global::Mono.Unix.Catalog.GetString("Reset time"), null, null);
		this.ResetTimeAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Reset time");
		w1.Add(this.ResetTimeAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("tracker");
		this.Icon = global::Stetic.IconLoader.LoadIcon(this, "stock_alarm", global::Gtk.IconSize.Dialog);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString("<ui><menubar name='menuBar'><menu name='TaskAction' action='TaskAction'><menuitem name='AddTopTaskAction' action='AddTopTaskAction'/><menuitem name='AddChildTaskAction' action='AddChildTaskAction'/><separator/><menuitem name='ResetTimeAction' action='ResetTimeAction'/><separator/><menuitem name='ExitAction' action='ExitAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='AboutAction' action='AboutAction'/></menu></menubar></ui>");
		this.menuBar = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menuBar")));
		this.menuBar.Name = "menuBar";
		this.vbox1.Add(this.menuBar);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menuBar]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.taskList = new global::Gtk.TreeView();
		this.taskList.CanFocus = true;
		this.taskList.Name = "taskList";
		this.GtkScrolledWindow.Add(this.taskList);
		this.vbox1.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
		w4.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.pauseBtn = new global::Gtk.Button();
		this.pauseBtn.CanFocus = true;
		this.pauseBtn.Name = "pauseBtn";
		this.vbox1.Add(this.pauseBtn);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.pauseBtn]));
		w5.Position = 2;
		w5.Expand = false;
		w5.Fill = false;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 225;
		this.DefaultHeight = 368;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.AddTopTaskAction.Activated += new global::System.EventHandler(this.OnAddTopTaskActionActivated);
		this.AddChildTaskAction.Activated += new global::System.EventHandler(this.OnAddChildTaskActionActivated);
		this.ExitAction.Activated += new global::System.EventHandler(this.OnExitActionActivated);
		this.AboutAction.Activated += new global::System.EventHandler(this.OnAboutActionActivated);
		this.DeleteTaskAndChildrenAction.Activated += new global::System.EventHandler(this.OnDeleteTaskAndChildrenActionActivated);
		this.ResetTimeAction.Activated += new global::System.EventHandler(this.OnResetTimeActionActivated);
		this.taskList.RowActivated += new global::Gtk.RowActivatedHandler(this.OnTaskListRowActivated);
		this.pauseBtn.Clicked += new global::System.EventHandler(this.OnPauseBtnClicked);
	}
}
