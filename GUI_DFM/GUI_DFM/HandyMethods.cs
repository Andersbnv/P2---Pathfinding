﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public static class HandyMethods
    {
        public static List<string> ReadFile(this string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
        public static List<Vertex> FileToVertexList(this string filePath)
        {
            List<string> fileLines = filePath.ReadFile();
            List<Vertex> vertexList = new List<Vertex>();
            foreach (string line in fileLines)
            {
                string[] lineElements = line.Split(',');
                vertexList.Add(new Vertex((lineElements)[0], double.Parse(lineElements[1]), double.Parse(lineElements[2])));
            }
            return vertexList;
        }
    }
}
