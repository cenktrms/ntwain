﻿using System;
using NTwain.Data;
using NTwain.Values;

namespace NTwain.Triplets
{
	sealed class ImageFileXfer : OpBase
	{
		internal ImageFileXfer(TwainSession session) : base(session) { }

		/// <summary>
		/// This operation is used to initiate the transfer of an image from the Source to the application via
		/// the disk-file transfer mechanism. It causes the transfer to begin.
		/// </summary>
		/// <returns></returns>
		public ReturnCode Get()
		{
			Session.VerifyState(6, 6, DataGroups.Image, DataArgumentType.ImageFileXfer, Message.Get);
			IntPtr z = IntPtr.Zero;
			return PInvoke.DsmEntry(Session.AppId, Session.SourceId, DataGroups.Image, DataArgumentType.ImageFileXfer, Message.Get, ref z);
		}
	}
}