/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderServoInitialize.cs
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
    [AddComponentMenu("MGS/OrderServo/OrderServoInitialize")]
    public class OrderServoInitialize : MonoBehaviour
    {
        #region Field and Property
        public MonoOrderIO orderIO;

        public List<MonoOrderUnit> orderUnits;
        #endregion

        #region Private Method
        private void Start()
        {
            var orderMr = new OrderManager
            {
                OrderIO = orderIO,
                OrderParser = new OrderParser()
            };
            var orderUnitMr = new OrderUnitManager();
            OrderServoProcessor.Instance.Initialize(orderMr, orderUnitMr);

            foreach (var unit in orderUnits)
            {
                OrderServoProcessor.Instance.OrderUnitManager.AddUnit(unit);
            }
            OrderServoProcessor.Instance.TurnOn();
        }
        #endregion
    }
}