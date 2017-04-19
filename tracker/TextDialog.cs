using System;
namespace tracker
{
	public partial class TextDialog : Gtk.Dialog
	{
		public String returnVal = "";

		public TextDialog()
		{
			this.Build();
		}

		protected void OnButtonOkPressed(object sender, EventArgs e)
		{
			returnVal = textInput.Text;
		}
	}
}
