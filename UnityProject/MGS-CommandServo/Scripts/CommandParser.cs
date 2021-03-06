/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandParser.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.CommandServo
{
    public class CommandParser : ICommandParser
    {
        #region Field and Property
        private readonly List<string> codes = new List<string>
        {
            "CSC_Move", "CSC_Rotate", "CSC_Color"
        };

        private byte[] tempBuffer = new byte[3];
        #endregion

        #region Public Method
        public byte[] ToBuffer(Command command)
        {
            var codeIndex = codes.IndexOf(command.code);
            if (codeIndex >= 0)
            {
                tempBuffer[codeIndex] = (byte)command.args[0];
            }
            return tempBuffer;
        }

        public IEnumerable<Command> ToCommands(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                return null;
            }

            var commands = new List<Command>();
            var parseCount = Mathf.Min(buffer.Length, codes.Count);
            for (int i = 0; i < parseCount; i++)
            {
                if (buffer[i] == 0 || tempBuffer[i] != 0)
                {
                    continue;
                }

                tempBuffer[i] = buffer[i];
                commands.Add(new Command(codes[i], buffer[i]));
            }
            return commands;
        }
        #endregion
    }
}