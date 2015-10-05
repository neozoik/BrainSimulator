﻿using GoodAI.BasicNodes.Transforms;
using GoodAI.Core.Memory;
using GoodAI.Core.Nodes;
using GoodAI.Core.Task;
using GoodAI.Core.Utils;
using GoodAI.Modules.Matrix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAXLib;

namespace GoodAI.Modules.Transforms
{
    /// <author>GoodAI</author>
    /// <meta>mv</meta>
    /// <status> WIP </status>
    /// <summary></summary>
    /// <description>
    /// </description>
    public class MyVectorOpsNode : MyWorkingNode
    {
        [MyInputBlock]
        public MyMemoryBlock<float> InputA
        {
            get { return GetInput(0); }
        }

        [MyInputBlock]
        public MyMemoryBlock<float> InputB
        {
            get { return GetInput(1); }
        }

        [MyOutputBlock]
        public MyMemoryBlock<float> Output
        {
            get { return GetOutput(0); }
            set { SetOutput(0, value); }
        }

        private MyMemoryBlock<float> Temp { get; set; }

        [MyTaskGroup("VectorOp")]
        public MyRotateTask RotateTask { get; private set; }
        [MyTaskGroup("VectorOp")]
        public MyAngleTask AngleTask { get; private set; }

        public override void UpdateMemoryBlocks()
        {
            Output.Count = InputA != null ? InputA.Count : 1;
            Output.ColumnHint = InputA != null ? InputA.ColumnHint : 1;

            Temp.ColumnHint = Output.Count;
            Temp.Count = Temp.ColumnHint * Temp.ColumnHint;
        }

        [Description("Rotates 2D vector")]
        public class MyRotateTask : MyTask<MyVectorOpsNode>
        {
            private VectorOps vecOps;

            public override void Init(int nGPU)
            {
                vecOps = new VectorOps(Owner, VectorOps.VectorOperation.Rotate, Owner.Temp);
            }

            public override void Execute()
            {
                vecOps.Run(VectorOps.VectorOperation.Rotate, Owner.InputA, Owner.InputB, Owner.Output);
            }
        }

        [Description("Angle between 2 vectors")]
        public class MyAngleTask : MyTask<MyVectorOpsNode>
        {
            [MyBrowsable, Category("Params")]
            [YAXSerializableField(DefaultValue = false)]
            public bool Directed { get; set; }

            private VectorOps vec_ops;

            public override void Init(int nGPU)
            {
                vec_ops = new VectorOps(Owner, VectorOps.VectorOperation.Angle | VectorOps.VectorOperation.DirectedAngle, Owner.Temp);
            }

            public override void Execute()
            {
                if (Directed)
                {
                    vec_ops.Run(VectorOps.VectorOperation.DirectedAngle, Owner.InputA, Owner.InputB, Owner.Output);
                }
                else
                {
                    vec_ops.Run(VectorOps.VectorOperation.Angle, Owner.InputA, Owner.InputB, Owner.Output);
                }
            }
        }
    }
}
