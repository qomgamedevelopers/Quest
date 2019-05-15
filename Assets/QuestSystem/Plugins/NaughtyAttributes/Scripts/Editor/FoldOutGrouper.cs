using System;

namespace NaughtyAttributes.Editor
{
    public abstract class FoldOutGrouper
    {
        public abstract void BeginGroup(string label);

        public abstract void EndGroup();
    }
}
