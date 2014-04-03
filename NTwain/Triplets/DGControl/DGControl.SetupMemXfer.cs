﻿using NTwain.Data;
using NTwain.Values;
using System;

namespace NTwain.Triplets
{
	public sealed class SetupMemXfer : OpBase
	{
		internal SetupMemXfer(TwainSession session) : base(session) { }
		/// <summary>
		/// Returns the Source’s preferred, minimum, and maximum allocation sizes for transfer memory
		/// buffers.
		/// </summary>
		/// <param name="setupMemXfer">The setup mem xfer.</param>
		/// <returns></returns>
		public ReturnCode Get(out TWSetupMemXfer setupMemXfer)
		{
			Session.VerifyState(4, 6, DataGroups.Control, DataArgumentType.SetupMemXfer, Message.Get);
			setupMemXfer = new TWSetupMemXfer();
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, Message.Get, setupMemXfer);
		}
	}
}