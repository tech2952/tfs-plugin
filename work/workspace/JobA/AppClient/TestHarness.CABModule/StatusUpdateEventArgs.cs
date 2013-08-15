using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Runtime.Serialization;
using TaxBuilder.GraphicObjects;

namespace TestHarness.CABModule
{
	/// <summary>
	/// Summary description for StatusUpdateEventArgs.
	/// </summary>
	public class SelectionChangedEventArgs : EventArgs
	{
		private GraphicObjectCollection mySelectedObjects = new GraphicObjectCollection();

		public SelectionChangedEventArgs(GraphicObjectCollection selectedObjects)
		{
			mySelectedObjects = selectedObjects;
		}
		public GraphicObjectCollection SelectedObjects
		{
			get
			{
				return mySelectedObjects;
			}
		}
	}
	
	//not sure of the status updates yet - just making some predictions
	public enum StatusUpdateType
	{
		FieldSetToLocked,
		FieldSetToOverride,
		FieldUpdated
	}
	public class StatusUpdateEventArgs : EventArgs
	{
		private StatusUpdateType myUpdateType;
		private GraphicObjectCollection mySelectedObjects;
		private String myMessage;

		public StatusUpdateEventArgs(StatusUpdateType UpdateType , GraphicObjectCollection Selections, String StatusMessage)
		{
			myUpdateType = UpdateType;
			mySelectedObjects = Selections;
			myMessage = StatusMessage;
		}
		public StatusUpdateType Type
		{
			get
			{
				return myUpdateType;
			}
		}
		public GraphicObjectCollection SelectedObjects
		{
			get
			{
				return mySelectedObjects;
			}
		}
		public String Message
		{
			get
			{
				return myMessage;
			}
		}
	}
}
   
