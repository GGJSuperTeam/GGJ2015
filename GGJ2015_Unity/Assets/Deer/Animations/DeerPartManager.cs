using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DeerPart
{
    Head,
    Torso,
    Mid,
    Rump,
}

public enum SpriteFacing
{
    Up,
    Down,
    Left,
    Right,
};

public static class DeerInfoManager
{
    static Dictionary<DeerPart, DeerPartInfo> info = new Dictionary<DeerPart, DeerPartInfo>()
    {
        {
            DeerPart.Head,
            new DeerPartInfo(
                new DeerPartFacingInfo(new Vector2(0,1), 0),
                new DeerPartFacingInfo(new Vector2(0,1), 3),
                new DeerPartFacingInfo(new Vector2(-0.11f,1.03f), 3),
                new DeerPartFacingInfo(new Vector2(0.11f,1.03f), 3))
        },
        {
            DeerPart.Torso,
            new DeerPartInfo(
                new DeerPartFacingInfo(new Vector2(0,0.45f), 1),
                new DeerPartFacingInfo(new Vector2(0,0.45f), 1),
                new DeerPartFacingInfo(new Vector2(0,0.45f), 1),
                new DeerPartFacingInfo(new Vector2(0,0.45f), 1))
        },
        {
            DeerPart.Mid,
            new DeerPartInfo(
                new DeerPartFacingInfo(new Vector2(0,0.46f), 2),
                new DeerPartFacingInfo(new Vector2(0,0.64f), 2),
                new DeerPartFacingInfo(new Vector2(0.15f,0.48f), 0),
                new DeerPartFacingInfo(new Vector2(-0.15f,0.48f), 0))
        },
        {
            DeerPart.Rump,
            new DeerPartInfo(
                new DeerPartFacingInfo(new Vector2(0,0.19f), 3),
                new DeerPartFacingInfo(new Vector2(0.11f,0.58f), 0),
                new DeerPartFacingInfo(new Vector2(0.44f,0.41f), 2),
                new DeerPartFacingInfo(new Vector2(-0.44f,0.41f), 2))
        },
    };

    public static Vector2 GetOffset(DeerPart part, SpriteFacing facing)
    {
        return info[part].GetFacingInfo(facing).Offset;
    }

    public static int GetOrder(DeerPart part, SpriteFacing facing)
    {
        return info[part].GetFacingInfo(facing).Order;
    }

    class DeerPartInfo
    {
        Dictionary<SpriteFacing, DeerPartFacingInfo> info = new Dictionary<SpriteFacing, DeerPartFacingInfo>();
        public DeerPartInfo(DeerPartFacingInfo upInfo, DeerPartFacingInfo downInfo, DeerPartFacingInfo leftInfo, DeerPartFacingInfo rightInfo)
        {
            info.Add(SpriteFacing.Up, upInfo);
            info.Add(SpriteFacing.Down, downInfo);
            info.Add(SpriteFacing.Left, leftInfo);
            info.Add(SpriteFacing.Right, rightInfo);
        }
        public DeerPartFacingInfo GetFacingInfo(SpriteFacing facing) { return info[facing]; }
    }

    class DeerPartFacingInfo
    {
        public Vector2 Offset;
        public int Order;
        public DeerPartFacingInfo(Vector2 Offset, int Order)
        {
            this.Offset = Offset;
            this.Order = Order;
        }
    }
}