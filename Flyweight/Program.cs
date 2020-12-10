using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree[] trees = new Tree[10];
            var random = new Random();
            for (int i = 0; i < trees.Length; i++)
            {
                TreeType treeType = (TreeType) Enum.GetValues(typeof(TreeType)).GetValue(random.Next(Enum.GetValues(typeof(TreeType)).Length));
                trees[i] = new Tree(TreeSpriteFactory.GetTreeSprite(treeType), random.Next() % 100, random.Next() % 100, random.Next() % 20 + 2);
                trees[i].Draw();
            }
        }
    }

    enum TreeType
    {
        Oak,
        Pine,
        Birch
    }

    class TreeSprite
    {
        private string imagePath;
        private TreeType treeType;

        public TreeSprite(string imagePath, TreeType treeType)
        {
            this.imagePath = imagePath;
            this.treeType = treeType;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing tree of type {treeType} in ({x}, {y}) with image path \"{imagePath}\".");
        }
    }

    class TreeSpriteFactory
    {
        private static Dictionary<TreeType, TreeSprite> dictionary = new Dictionary<TreeType, TreeSprite>();

        public static TreeSprite GetTreeSprite(TreeType treeType)
        {
            if (!dictionary.Keys.Contains(treeType))
            {
                switch (treeType)
                {
                    case TreeType.Oak:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Creating sprite of Oak...");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        dictionary.Add(treeType, new TreeSprite("Oak.png", treeType));
                        break;
                    case TreeType.Pine:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Creating sprite of Pine...");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        dictionary.Add(treeType, new TreeSprite("Pine.png", treeType));
                        break;
                    case TreeType.Birch:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Creating sprite of Birch...");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        dictionary.Add(treeType, new TreeSprite("Birch.png", treeType));
                        break;
                }
            }

            TreeSprite treeSprite = dictionary[treeType];

            return treeSprite;
        }
    }

    class Tree
    {
        private int x;
        private int y;
        private int height;
        private TreeSprite sprite;

        public Tree(TreeSprite sprite, int x, int y, int height)
        {
            this.sprite = sprite;
            this.x = x;
            this.y = y;
            this.height = height;
        }

        public void Draw()
        {
            sprite.Draw(x, y);
            Console.WriteLine($"Height: {height}");
        }
    }
}
