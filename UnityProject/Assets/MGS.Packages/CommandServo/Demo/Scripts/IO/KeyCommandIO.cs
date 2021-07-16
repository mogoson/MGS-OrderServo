/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KeyCommandIO.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.CommandServo.Demo
{
    public class KeyCommandIO : MonoCommandIO, ICommandIO
    {
        #region Field and Property
        private byte[] buffer = new byte[3];
        private bool isDirty = false;
        #endregion

        #region Private Method
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                SetBuffer(0, 1);
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                SetBuffer(0, 2);
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                SetBuffer(0, 3);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetBuffer(1, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetBuffer(1, 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetBuffer(1, 3);
            }

            else if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                SetBuffer(2, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                SetBuffer(2, 2);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                SetBuffer(2, 3);
            }
        }

        private void SetBuffer(int index, byte value)
        {
            buffer[index] = value;
            isDirty = true;
        }
        #endregion

        #region Public Method
        public override byte[] ReadBuffer()
        {
            if (isDirty)
            {
                isDirty = false;

                var tempBuffer = new List<byte>(buffer).ToArray();
                Array.Clear(buffer, 0, buffer.Length);
                return tempBuffer;
            }
            return null;
        }

        public override void WriteBuffer(byte[] buffer)
        {
            var bufferStr = string.Empty;
            if (buffer != null)
            {
                foreach (var code in buffer)
                {
                    bufferStr += code + " ";
                }
            }
            Debug.LogFormat("Output buffer: {0}", bufferStr);
        }
        #endregion
    }
}