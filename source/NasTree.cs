﻿using System;
using System.Drawing;
using LibNoise;
using MCGalaxy;
using BlockID = System.UInt16;
using MCGalaxy.Tasks;
using MCGalaxy.Generator;
using MCGalaxy.Generator.Foliage;

namespace NotAwesomeSurvival {

    public static class NasTree {
        public static void Setup() {
            
        }
        public static void GenOakTree(NasLevel nl, Random r, int x, int y, int z, bool broadcastChange = false)
        {
            Level lvl = nl.lvl;

            Tree oak;
            oak = new OakTree();

            oak.SetData(r, r.Next(0, 8));
            PlaceBlocks(lvl, oak, x, y, z, broadcastChange);
        }

        public static void GenSpruceTree(NasLevel nl, Random r, int x, int y, int z, bool broadcastChange = false)
        {
            Level lvl = nl.lvl;

            Tree spruce;
            spruce = new SpruceTree();

            spruce.SetData(r, r.Next(0, 8));
            PlaceBlocks(lvl, spruce, x, y, z, broadcastChange);
        }

        public static void GenPeachTree(NasLevel nl, Random r, int x, int y, int z, bool broadcastChange = false)
        {
            Level lvl = nl.lvl;

            Tree peach;
            peach = new PeachTree();

            peach.SetData(r, r.Next(0, 8));
            PlaceBlocks(lvl, peach, x, y, z, broadcastChange);
        }

        private static void PlaceBlocks(Level lvl, Tree tree, int x, int y, int z, bool broadcastChange) {
            tree.Generate((ushort)x, (ushort)(y), (ushort)z, (X, Y, Z, block) =>
            {
                BlockID here = lvl.GetBlock(X, Y, Z);
                if (NasBlock.CanPhysicsKillThis(here) || NasBlock.IsPartOfSet(NasBlock.leafSet, here) != -1)
                {
                    lvl.SetBlock(X, Y, Z, block); // Thanks Unk!
                    if (broadcastChange)
                    {
                        lvl.BroadcastChange(X, Y, Z, block);
                    }
                }
            });
        }
    }

}
