/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandRotateUnit.cs
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
    [AddComponentMenu("MGS/CommandServo/CommandRotateUnit")]
    public class CommandRotateUnit : MonoCommandUnit
    {
        #region Private
        private IEnumerator KeepRotate(float speed, float time)
        {
            var timer = 0f;
            while (timer < time)
            {
                timer += Time.deltaTime;
                transform.Rotate(Vector3.forward * speed);
                yield return new WaitForEndOfFrame();
            }
            OnRespond.Invoke(code, new object[] { (byte)0 });
        }
        #endregion

        #region Public Method
        public override void Execute(params object[] args)
        {
            var speed = float.Parse(args[0].ToString());

            StopAllCoroutines();
            StartCoroutine(KeepRotate(speed, 5));
        }
        #endregion
    }
}