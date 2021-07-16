/*************************************************************************
 *  Copyright © 2020 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandColorUnit.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/12/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.CommandServo
{
    [AddComponentMenu("MGS/CommandServo/CommandColorUnit")]
    [RequireComponent(typeof(MeshRenderer))]
    public class CommandColorUnit : MonoCommandUnit
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
        public override void Execute(params object[] args)
        {
            var index = int.Parse(args[0].ToString()) - 1;
            if (index < 0 || index >= colors.Length)
            {
                return;
            }

            meshRenderer.material.color = colors[index];
            OnRespond.Invoke(code, new object[] { (byte)0 });
        }
        #endregion
    }
}