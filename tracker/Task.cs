using System;
using System.Collections.Generic;
using System.IO;

namespace tracker
{
	[Serializable]
	public class Task
	{
		public static List<Task> tasks = new List<Task>();
		public static int currTaskId = -1;
		public static bool tracking = false;

		public static int lastId = 0;
		public int id;
		public int parentId;
		public string name;
		public int seconds=0;
		public int minutes=0;
		public int hours=0;

		public Task(string name, int parentId=-1)
		{
			this.id = lastId++;
			this.parentId = parentId;
			this.name = name;

			tasks.Add(this);
		}

		public string getNiceTime()
		{
			if (hours == 0 && minutes == 0 && seconds == 0)
				return "";
			String hours_str = hours.ToString().Length == 1 ? "0" + hours.ToString() : hours.ToString();
			String minutes_str = minutes.ToString().Length == 1 ? "0" + minutes.ToString() : minutes.ToString();
			String seconds_str = seconds.ToString().Length == 1 ? "0" + seconds.ToString() : seconds.ToString();
			return hours_str + ":" + minutes_str + ":" + seconds_str;
		}

		public void increaseTime()
		{
			this.seconds++;
			if (this.seconds == 60)
			{
				this.seconds = 0;
				this.minutes++;
				if (this.minutes == 60)
				{
					this.minutes = 0;
					this.hours++;
				}
			}
		}

		public void resetTime()
		{
			this.seconds = 0;
			this.minutes = 0;
			this.hours = 0;
		}

		//not working properly yet
		public void delete()
		{
			List<Task> children = getTasksByParent(this.id);
			for (int i = 0; i < children.Count; i++)
			{
				Task child = getTask(children[i].id);
				child = null;
			}
			Task task = getTask(this.id);
			task = null;
			Task.saveAll();
		}

		public static Task getTask(int id)
		{
			for (int i = 0; i < tasks.Count; i++)
				if (tasks[i].id == id)
					return tasks[i];
			return null;
		}

		public static List<Task> getTasksByParent(int parentId)
		{
			List<Task> resTasks = new List<Task>();
			for (int i = 0; i < tasks.Count; i++)
				if (tasks[i].parentId == parentId)
					resTasks.Add(tasks[i]);
			return resTasks;
		}

		public static void saveAll()
		{
			string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
				   Environment.OSVersion.Platform == PlatformID.MacOSX)
					? Environment.GetEnvironmentVariable("HOME")
					: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
			
			string saveFile = Path.Combine(homePath, ".local/tracker.sav");
			using (Stream stream = File.Open(saveFile, FileMode.Create))
			{
				var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				bFormatter.Serialize(stream, tasks);
			}
		}

		public static void loadAll()
		{
			string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
				   Environment.OSVersion.Platform == PlatformID.MacOSX)
					? Environment.GetEnvironmentVariable("HOME")
					: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

			string saveFile = Path.Combine(homePath, ".local/tracker.sav");

			using (Stream stream = File.Open(saveFile, FileMode.Open))
			{
				var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				tasks = (List<Task>)bFormatter.Deserialize(stream);
			}

			lastId = tasks.Count;
		}
	}
}