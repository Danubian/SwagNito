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

// **************************************************************
// * Raw implementation of the MD5 hash algorithm
// * from RFC 1321.
// *
// * Written By: Reid Borsuk and Jenny Zheng
// * Copyright (c) Microsoft Corporation.  All rights reserved.
// **************************************************************

namespace ThirdParty.MD5
{

    public class MD5Managed : System.Security.Cryptography.HashAlgorithm
    {
        private byte[] _data;
        private ABCDStruct _abcd;
        private Int64 _totalLength;
        private int _dataSize;

        public MD5Managed()
        {
            base.HashSizeValue = 0x80;
            this.Initialize();
        }

        public override void Initialize()
        {
            _data = new byte[64];
            _dataSize = 0;
            _totalLength = 0;
            _abcd = new ABCDStruct();
            //Intitial values as defined in RFC 1321
            _abcd.A = 0x67452301;
            _abcd.B = 0xefcdab89;
            _abcd.C = 0x98badcfe;
            _abcd.D = 0x10325476;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            int startIndex = ibStart;
            int totalArrayLength = _dataSize + cbSize;
            if (totalArrayLength >= 64)
            {
                Array.Copy(array, startIndex, _data, _dataSize, 64 - _dataSize);
                // Process message of 64 bytes (512 bits)
                MD5Core.GetHashBlock(_data, ref _abcd, 0);
                startIndex += 64 - _dataSize;
                totalArrayLength -= 64;
                while (totalArrayLength >= 64)
                {
                    Array.Copy(array, startIndex, _data, 0, 64);
                    MD5Core.GetHashBlock(array, ref _abcd, startIndex);
                    totalArrayLength -= 64;
                    startIndex += 64;
                }
                _dataSize = totalArrayLength;
                Array.Copy(array, startIndex, _data, 0, totalArrayLength);
            }
            else
            {
                Array.Copy(array, startIndex, _data, _dataSize, cbSize);
                _dataSize = totalArrayLength;
            }
            _totalLength += cbSize;
        }

        protected override byte[] HashFinal()
        {
            base.HashValue = MD5Core.GetHashFinalBlock(_data, 0, _dataSize, _abcd, _totalLength * 8);
            return base.HashValue;
        }
    }
}