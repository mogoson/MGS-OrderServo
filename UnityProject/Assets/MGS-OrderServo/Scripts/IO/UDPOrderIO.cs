/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UDPOrderIO.cs
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

namespace MGS.OrderServo
{
    [AddComponentMenu("MGS/OrderServo/UDPOrderIO")]
    public class UDPOrderIO : MonoOrderIO, IOrderIO
    {
        #region Field and Property
        #endregion

        #region Private Method
        #endregion

        #region Public Method
        public override byte[] ReadBuffer()
        {
            throw new NotImplementedException();
        }

        public override void WriteBuffer(byte[] buffer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}