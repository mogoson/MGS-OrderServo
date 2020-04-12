/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderRotateUnit.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.OrderServo
{
    [AddComponentMenu("MGS/OrderServo/OrderRotateUnit")]
    public class OrderRotateUnit : MonoOrderUnit
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
            OnRespond.Invoke(code, (byte)0);
        }
        #endregion

        #region Public Method
        public override void Execute(object args)
        {
            var speed = float.Parse(args.ToString());

            StopAllCoroutines();
            StartCoroutine(KeepRotate(speed, 5));
        }
        #endregion
    }
}