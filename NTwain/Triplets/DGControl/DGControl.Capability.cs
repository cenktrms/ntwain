﻿using NTwain.Data;
using NTwain.Values;
using System;

namespace NTwain.Triplets
{
	public sealed class Capability : OpBase
	{
		internal Capability(TwainSession session) : base(session) { }
		/// <summary>
		/// Returns the Source’s Current, Default and Available Values for a specified capability.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode Get(TWCapability capability)
		{
			Session.VerifyState(4, 7, DataGroups.Control, DataArgumentType.Capability, Message.Get);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.Get, capability);
		}

		/// <summary>
		/// Returns the Source’s Current Value for the specified capability.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode GetCurrent(TWCapability capability)
		{
			Session.VerifyState(4, 7, DataGroups.Control, DataArgumentType.Capability, Message.GetCurrent);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.GetCurrent, capability);
		}

		/// <summary>
		/// Returns the Source’s Default Value. This is the Source’s preferred default value.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode GetDefault(TWCapability capability)
		{
			Session.VerifyState(4, 7, DataGroups.Control, DataArgumentType.Capability, Message.GetDefault);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.GetDefault, capability);
		}

		/// <summary>
		/// Returns help text suitable for use in a GUI; for instance: "Specify the amount of detail in an
		/// image. Higher values result in more detail." for ICapXRESOLUTION.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode GetHelp(TWCapability capability)
		{
			Session.VerifyState(4, 4, DataGroups.Control, DataArgumentType.Capability, Message.GetHelp);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.GetHelp, capability);
		}

		/// <summary>
		/// Returns a label suitable for use in a GUI, for instance "Resolution:"
		/// for ICapXRESOLUTION.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode GetLabel(TWCapability capability)
		{
			Session.VerifyState(4, 4, DataGroups.Control, DataArgumentType.Capability, Message.GetLabel);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.GetLabel, capability);
		}

		/// <summary>
		/// Return all of the labels for a capability of type <see cref="TWArray"/> or <see cref="TWEnumeration"/>, for example
		/// "US Letter" for ICapSupportedSizes’ TWSS_USLETTER.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode GetLabelEnum(TWCapability capability)
		{
			Session.VerifyState(4, 4, DataGroups.Control, DataArgumentType.Capability, Message.GetLabelEnum);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.GetLabelEnum, capability);
		}

		/// <summary>
		/// Returns the Source’s support status of this capability.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode QuerySupport(TWCapability capability)
		{
			Session.VerifyState(4, 7, DataGroups.Control, DataArgumentType.Capability, Message.QuerySupport);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.QuerySupport, capability);
		}

		/// <summary>
		/// Change the Current Value of the specified capability back to its power-on value and return the
		/// new Current Value.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode Reset(TWCapability capability)
		{
			Session.VerifyState(4, 4, DataGroups.Control, DataArgumentType.Capability, Message.Reset);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.Reset, capability);
		}

		/// <summary>
		/// This command resets all of the current values and constraints to their defaults for all of the
		/// negotiable capabilities supported by the driver.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode ResetAll(TWCapability capability)
		{
			Session.VerifyState(4, 4, DataGroups.Control, DataArgumentType.Capability, Message.ResetAll);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.ResetAll, capability);
		}

		/// <summary>
		/// Changes the Current Value(s) and Available Values of the specified capability to those specified
		/// by the application.
		/// Current Values are set when the container is a <see cref="TWOneValue"/> or <see cref="TWArray"/>. Available and
		/// Current Values are set when the container is a <see cref="TWEnumeration"/> or <see cref="TWRange"/>.
		/// </summary>
		/// <param name="capability">The capability.</param>
		/// <returns></returns>
		public ReturnCode Set(TWCapability capability)
		{
			Session.VerifyState(4, 6, DataGroups.Control, DataArgumentType.Capability, Message.Set);
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.Set, capability);
		}
	}
}