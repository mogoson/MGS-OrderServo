/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OrderColorUnit.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.OrderServo
{
    [AddComponentMenu("MGS/OrderServo/OrderColorUnit")]
    [RequireComponent(typeof(MeshRenderer))]
    public class OrderColorUnit : MonoOrderUnit
    {
        #region Field and Property
        public Color[] colors = new Color[]
        {
            Color.blue, Color.green, Color.red
        };

        private MeshRenderer meshRenderer;
        #endregion

        #region Private
        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        #endregion

        #region Public Method
        public override void Execute(object args)
        {
            var index = int.Parse(args.ToString()) - 1;
            if (index < 0 || index >= colors.Length)
            {
                return;
            }

            meshRenderer.material.color = colors[index];
            OnRespond.Invoke(code, (byte)0);
        }
        #endregion
    }
}