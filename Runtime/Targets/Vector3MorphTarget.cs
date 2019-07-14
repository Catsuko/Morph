using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Morphs
{
    [Serializable]
    public class Vector3MorphTarget : MorphTarget
    {
        [SerializeField]
        private Vector3 _start, _end;
        [SerializeField]
        private Transform _transform;

        public override void UpdateTo(float time)
        {
            _transform.position = Vector3.Lerp(_start, _end, time);
        }
    }
}
