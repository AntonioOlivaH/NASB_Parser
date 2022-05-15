using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public static Vector3 newVector() {
            Vector3 ret = new Vector3();
            ret.x = 0;
            ret.y = 0;
            ret.z = 0;
            return ret;
        }

        public override string ToString() {
            return x.ToString() + " " + y.ToString() + " " + z.ToString();
        }
    }
}