/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandUnitInventory.cs
 *  Description  :  Inventory of Command Unit.
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
    [AddComponentMenu("MGS/CommandServo/CommandUnitInventory")]
    public class CommandUnitInventory : MonoBehaviour
    {
        #region Public Method
        public IEnumerable<MonoCommandUnit> GetCommandUnits()
        {
            return GetComponentsInChildren<MonoCommandUnit>();
        }
        #endregion
    }
}