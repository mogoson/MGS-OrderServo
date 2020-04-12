/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderParser.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.OrderServo
{
    public class OrderParser : IOrderParser
    {
        #region Field and Property
        private readonly List<string> codes = new List<string>
        {
            "OU_Move", "OU_Rotate", "OU_Color"
        };

        private byte[] tempBuffer = new byte[3];
        #endregion

        #region Public Method
        public byte[] ToBuffer(Order order)
        {
            var codeIndex = codes.IndexOf(order.code);
            if (codeIndex >= 0)
            {
                tempBuffer[codeIndex] = (byte)order.args;
            }
            return tempBuffer;
        }

        public IEnumerable<Order> ToOrders(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                return null;
            }

            var orders = new List<Order>();
            var parseCount = Mathf.Min(buffer.Length, codes.Count);
            for (int i = 0; i < parseCount; i++)
            {
                if (buffer[i] == 0 || tempBuffer[i] != 0)
                {
                    continue;
                }

                tempBuffer[i] = buffer[i];
                orders.Add(new Order(codes[i], buffer[i]));
            }
            return orders;
        }
        #endregion
    }
}