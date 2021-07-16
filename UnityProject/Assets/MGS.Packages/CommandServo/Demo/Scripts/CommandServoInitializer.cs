/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandServoInitializer.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.CommandServo.Demo
{
    public class CommandServoInitializer : MonoBehaviour
    {
        #region Field and Property
        public MonoCommandIO commandIO;

        public CommandUnitInventory unitInventory;
        #endregion

        #region Private Method
        private void Start()
        {
            var commandMr = new CommandManager(commandIO, new KeyCommandParser());
            var commandUnitMr = new CommandUnitManager();

            var units = unitInventory.GetCommandUnits();
            if (units != null)
            {
                foreach (var unit in units)
                {
                    commandUnitMr.RegisterUnit(unit);
                }
            }

            CommandServoProcessor.Instance.Initialize(commandMr, commandUnitMr);
        }

        private void OnDestroy()
        {
            CommandServoProcessor.Instance.Enabled = false;
        }
        #endregion
    }
}