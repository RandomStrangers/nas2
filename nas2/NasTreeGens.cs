﻿using System;
using MCGalaxy;
using MCGalaxy.Generator.Foliage;

namespace NotAwesomeSurvival
{
    public sealed class SpruceTree : Tree
    {

        public override long EstimateBlocksAffected() { return height + size * size * size; }

        public override int DefaultSize(Random rnd) { return rnd.Next(5, 8); }

        public override void SetData(Random rnd, int value)
        {
            height = value;
            size = height - rnd.Next(2, 4);
            this.rnd = rnd;
        }

        public override void Generate(ushort x, ushort y, ushort z, TreeOutput output)
        {
            for (ushort dy = 0; dy < height + size - 1; dy++)
                output(x, (ushort)(y + dy), z, /*LOG ID HERE*/ 250);

            for (int dy = -size; dy <= size; ++dy)
                for (int dz = -size; dz <= size; ++dz)
                    for (int dx = -size; dx <= size; ++dx)
                    {
                        int dist = (int)(Math.Sqrt(dx * dx + dy * dy + dz * dz));
                        if ((dist < size + 1) && rnd.Next(dist) < 2)
                        {
                            ushort xx = (ushort)(x + dx), yy = (ushort)(y + dy + height), zz = (ushort)(z + dz);

                            if (xx != x || zz != z || dy >= size - 1)
                                output(xx, yy, zz, /*LEAVES ID HERE*/ 146);
                        }
                    }
        }
    }

    public sealed class ClassicTree : Tree
    {

        public override long EstimateBlocksAffected() { return height + 65; }

        public override int DefaultSize(Random rnd) { return rnd.Next(3, 7); }

        public override void SetData(Random rnd, int value)
        {
            height = value;
            size = 2;
            this.rnd = rnd;
        }

        public override void Generate(ushort x, ushort y, ushort z, TreeOutput output)
        {
            for (int dy = 0; dy <= height; dy++)
                output(x, (ushort)(y + dy), z, Block.Log);

            for (int dy = height - 2; dy <= height + 1; dy++)
            {
                int extent = dy > height - 1 ? 1 : 2;
                for (int dz = -extent; dz <= extent; dz++)
                    for (int dx = -extent; dx <= extent; dx++)
                    {
                        ushort xx = (ushort)(x + dx), yy = (ushort)(y + dy), zz = (ushort)(z + dz);
                        if (xx == x && zz == z && dy <= height) continue;

                        if (Math.Abs(dx) == extent && Math.Abs(dz) == extent)
                        {
                            if (dy > height) continue;
                            if (rnd.Next(2) == 0) output(xx, yy, zz, Block.Leaves);
                        }
                        else
                        {
                            output(xx, yy, zz, Block.Leaves);
                        }
                    }
            }
        }
    }

    public sealed class SwampTree : Tree
    {

        public override long EstimateBlocksAffected() { return height + 145; }

        public override int DefaultSize(Random rnd) { return rnd.Next(4, 8); }

        public override void SetData(Random rnd, int value)
        {
            height = value;
            size = 3;
            this.rnd = rnd;
        }

        public override void Generate(ushort x, ushort y, ushort z, TreeOutput output)
        {
            for (int dy = 0; dy <= height; dy++)
                output(x, (ushort)(y + dy), z, Block.Log);

            for (int dy = height - 2; dy <= height + 1; dy++)
            {
                int extent = dy > height - 1 ? 2 : 3;
                for (int dz = -extent; dz <= extent; dz++)
                    for (int dx = -extent; dx <= extent; dx++)
                    {
                        ushort xx = (ushort)(x + dx), yy = (ushort)(y + dy), zz = (ushort)(z + dz);
                        if (xx == x && zz == z && dy <= height) continue;

                        if (Math.Abs(dx) == extent && Math.Abs(dz) == extent)
                        {
                            if (dy > height) continue;
                            if (rnd.Next(2) == 0) output(xx, yy, zz, Block.Leaves);
                        }
                        else
                        {
                            output(xx, yy, zz, Block.Leaves);
                        }
                    }
            }
        }
    }
}