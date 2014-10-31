﻿using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTwain
{
    /// <summary>
    /// Contains event data after whatever data from the source has been transferred.
    /// </summary>
    public class DataTransferredEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferredEventArgs" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="nativeData">The native data.</param>
        /// <param name="imageInfo">The image information.</param>
        public DataTransferredEventArgs(DataSource source, IntPtr nativeData, TWImageInfo imageInfo)
        {
            DataSource = source;
            NativeData = nativeData;
            ImageInfo = imageInfo;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferredEventArgs" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="fileDataPath">The file data path.</param>
        /// <param name="imageInfo">The image information.</param>
        public DataTransferredEventArgs(DataSource source, string fileDataPath, TWImageInfo imageInfo)
        {
            DataSource = source;
            FileDataPath = fileDataPath;
            ImageInfo = imageInfo;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferredEventArgs" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="memoryData">The memory data.</param>
        /// <param name="imageInfo">The image information.</param>
        public DataTransferredEventArgs(DataSource source, byte[] memoryData, TWImageInfo imageInfo)
        {
            DataSource = source;
            MemoryData = memoryData;
            ImageInfo = imageInfo;
        }

        /// <summary>
        /// Gets pointer to the complete data if the transfer was native.
        /// The data will be freed once the event handler ends
        /// so consumers must complete whatever processing before then.
        /// For image type this data is DIB (Windows) or TIFF (Linux).
        /// This pointer is already locked for the duration of this event.
        /// </summary>
        /// <value>The data pointer.</value>
        public IntPtr NativeData { get; private set; }

        /// <summary>
        /// Gets the file path to the complete data if the transfer was file or memory-file.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public string FileDataPath { get; private set; }

        /// <summary>
        /// Gets the raw memory data if the transfer was memory.
        /// Consumer application will need to do the parsing based on the values
        /// from <see cref="ImageInfo"/>.
        /// </summary>
        /// <value>
        /// The memory data.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public byte[] MemoryData { get; private set; }

        /// <summary>
        /// Gets the final image information if applicable.
        /// </summary>
        /// <value>
        /// The final image information.
        /// </value>
        public TWImageInfo ImageInfo { get; private set; }

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <value>
        /// The data source.
        /// </value>
        public DataSource DataSource { get; private set; }

        /// <summary>
        /// Gets the extended image information if applicable.
        /// </summary>
        /// <param name="infoIds">The information ids.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public IEnumerable<TWInfo> GetExtImageInfo(params ExtendedImageInfo[] infoIds)
        {
            if (infoIds != null && infoIds.Length > 0 && DataSource.SupportedCaps.Contains(CapabilityId.ICapExtImageInfo))
            {
                var request = new TWExtImageInfo { NumInfos = (uint)infoIds.Length };
                if (infoIds.Length > request.Info.Length)
                {
                    throw new InvalidOperationException(string.Format("Info ID array excdd maximum length of {0}.", request.Info.Length));
                }

                for (int i = 0; i < infoIds.Length; i++)
                {
                    request.Info[i].InfoID = infoIds[i];
                }

                if (DataSource.DGImage.ExtImageInfo.Get(request) == ReturnCode.Success)
                {
                    return request.Info.Where(it => it.InfoID != ExtendedImageInfo.Invalid);
                }
            }
            return Enumerable.Empty<TWInfo>();
        }
    }
}