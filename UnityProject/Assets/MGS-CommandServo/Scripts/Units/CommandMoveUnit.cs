/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderMoveUnit.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.CommandServo
{
    [AddComponentMenu("MGS/CommandServo/CommandMoveUnit")]
    public class CommandMoveUnit : MonoCommandUnit
    {
        #region Private
        private IEnumerator DelayRevert(float displacement, float time)
        {
            yield return new WaitForSeconds(time);
            transform.Translate(Vector3.up * displacement);
            OnRespond.Invoke(code, new object[] { (byte)0 });
        }
        #endregion

        #region Public Method
        public override void Execute(params object[] args)
        {
            var displacement = float.Parse(args[0].ToString());
            transform.Translate(Vector3.up * displacement);

            StopAllCoroutines();
            StartCoroutine(DelayRevert(-displacement, 1.0f));
        }
        #endregion
    }
}