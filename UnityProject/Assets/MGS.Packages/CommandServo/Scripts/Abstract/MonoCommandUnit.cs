/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCommandIO.cs
 *  Description  :  Mono command unit.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/15/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Threading;
using System;
using UnityEngine;

namespace MGS.CommandServo
{
    /// <summary>
    /// Mono command unit.
    /// </summary>
    public abstract class MonoCommandUnit : MonoBehaviour, ICommandUnit
    {
        #region Field and Property
        /// <summary>
        /// Code of Command unit.
        /// </summary>
        [SerializeField]
        protected string code;

        /// <summary>
        /// Code of Command unit.
        /// </summary>
        public string Code
        {
            set { code = value; }
            get { return code; }
        }

        /// <summary>
        /// On Command unit respond event.
        /// </summary>
        public event Action<string, object[]> OnRespondEvent;
        #endregion

        #region Public Method
        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="args">Command args.</param>
        public void Execute(params object[] args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                //Execute on main thread.
                ExecuteCommand(args);
            });
        }
        #endregion

        #region
        /// <summary>
        /// Execute Command.
        /// </summary>
        /// <param name="args">Command args.</param>
        protected abstract void ExecuteCommand(params object[] args);

        /// <summary>
        /// Invoke on respond event.
        /// </summary>
        /// <param name="args">Command args.</param>
        protected void InvokeOnRespondEvent(object[] args)
        {
            if (OnRespondEvent == null)
            {
                return;
            }
            OnRespondEvent.Invoke(Code, args);
        }
        #endregion
    }
}