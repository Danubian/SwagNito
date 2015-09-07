//
// Copyright 2014-2015 Amazon.com, 
// Inc. or its affiliates. All Rights Reserved.
// 
// Licensed under the Amazon Software License (the "License"). 
// You may not use this file except in compliance with the 
// License. A copy of the License is located at
// 
//     http://aws.amazon.com/asl/
// 
// or in the "license" file accompanying this file. This file is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, express or implied. See the License 
// for the specific language governing permissions and 
// limitations under the License.
//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Amazon.Runtime;

namespace Amazon.Runtime.Internal.Util
{
    /// <summary>
    /// A stream which caches the contents of the underlying stream as it reads it.
    /// </summary>
    public class CachingWrapperStream : WrapperStream
    {
        private int _cacheLimit;

        private int _cachedBytes = 0;

        /// <summary>
        /// All the bytes read by the stream.
        /// </summary>
        public List<Byte> AllReadBytes { get; private set; }

        /// <summary>
        /// Initializes the CachingWrapperStream with a base stream.
        /// </summary>
        /// <param name="baseStream">The stream to be wrapped.</param>
        /// <param name="cacheLimit">Maximum number of bytes to be cached.</param>
        public CachingWrapperStream(Stream baseStream, int cacheLimit) : base(baseStream)
        {
            _cacheLimit = cacheLimit;
            this.AllReadBytes = new List<byte>(cacheLimit);
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position
        /// within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">
        /// An array of bytes. When this method returns, the buffer contains the specified
        /// byte array with the values between offset and (offset + count - 1) replaced
        /// by the bytes read from the current source.
        /// </param>
        /// <param name="offset">
        /// The zero-based byte offset in buffer at which to begin storing the data read
        /// from the current stream.
        /// </param>
        /// <param name="count">
        /// The maximum number of bytes to be read from the current stream.
        /// </param>
        /// <returns>
        /// The total number of bytes read into the buffer. This can be less than the
        /// number of bytes requested if that many bytes are not currently available,
        /// or zero (0) if the end of the stream has been reached.
        /// </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            var numberOfBytesRead = base.Read(buffer, offset, count);

            // Limit the cached bytes to _cacheLimit
            if (_cachedBytes < _cacheLimit)
            {
                int remainingBytes = _cacheLimit - _cachedBytes;
                int bytesToCache = Math.Min(numberOfBytesRead, remainingBytes);

                var readBytes = new byte[bytesToCache];
                System.Array.Copy(buffer, offset, readBytes, 0, bytesToCache);
                AllReadBytes.AddRange(readBytes);
                _cachedBytes += bytesToCache;
            }

            return numberOfBytesRead;
        }


        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// CachingWrapperStream does not support seeking, this will always be false.
        /// </summary>
        public override bool CanSeek
        {
            get
            {
                // Restrict random access.
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// CachingWrapperStream does not support seeking, attempting to set Position
        /// will throw NotSupportedException.
        /// </summary>
        public override long Position
        {
            get
            {
                throw new NotSupportedException("CachingWrapperStream does not support seeking");
            }
            set
            {
                // Restrict random access, as this will break hashing.
                throw new NotSupportedException("CachingWrapperStream does not support seeking");
            }
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// CachingWrapperStream does not support seeking, attempting to call Seek
        /// will throw NotSupportedException.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">
        /// A value of type System.IO.SeekOrigin indicating the reference point used
        /// to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            // Restrict random access.
            throw new NotSupportedException("CachingWrapperStream does not support seeking");
        }
    }
}
