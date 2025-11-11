using GLSLhelper;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace DMS.GLSL.Errors
{
	public sealed class ErrorList : IServiceProvider
	{
		private static readonly ErrorList _instance = new ErrorList();
		private readonly ErrorListProvider _provider;

		private ErrorList()
		{
			_provider = new ErrorListProvider(this);
		}

		public static ErrorList GetInstance()
		{
			return _instance;
		}

		public object GetService(Type serviceType)
		{
			return Package.GetGlobalService(serviceType);
		}

		public void Clear()
		{
			_provider.Tasks.Clear();
		}

		internal void Write(string message, int lineNumber, string filePath, MessageType type)
		{
			ErrorTask task = CreateTask(message, lineNumber, filePath, Convert(type));
			task.Navigate += Task_Navigate;
			try
			{
				_provider.Tasks.Add(task);
				// provider.BringToFront();
			}
			catch (OperationCanceledException)
			{
			}
		}

		private static ErrorTask CreateTask(string text, int line, string document, TaskErrorCategory errorCategory)
		{
			return new ErrorTask
			{
				Category      = TaskCategory.BuildCompile,
				Text          = text,
				Line          = line,
				Column        = 1,
				Document      = document,
				ErrorCategory = errorCategory,
			};
		}

		private void Task_Navigate(object sender, EventArgs e)
		{
			if (sender is ErrorTask task)
			{
				var temp = CreateTask(task.Text, task.Line + 1, task.Document, task.ErrorCategory);
				_provider.Navigate(temp, new Guid(LogicalViewID.Code));
			}
		}

		private static TaskErrorCategory Convert(MessageType type)
		{
			switch (type)
			{
			case MessageType.Error:   return TaskErrorCategory.Error;
			case MessageType.Warning: return TaskErrorCategory.Warning;
			default:                  return TaskErrorCategory.Message;
			}
		}
	}
}
