﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SodukuBase
{
    /// <summary>
    /// 静态工具类
    /// </summary>
    public static class StaticTools
    {
        public static readonly List<int> allLocations=new List<int>
        {
         0,1,2,3,4,5,6,7,8,
         9,10,11,12,13,14,15,16,17,
        18,19,20,21,22,23,24,25,26,
        27,28,29,30,31,32,33,34,35,
        36,37,38,39,40,41,42,43,44,
        45,46,47,48,49,50,51,52,53,
        54,55,56,57,58,59,60,61,62,
        63,64,65,66,67,68,69,70,71,
        72,73,74,75,76,77,78,79,80

        };

        public static readonly List<int> baseFillList=new List<int> {1,2,3,4,5,6,7,8,9};

        public static bool ValidNoticeList(List<int> noticeValue)
        {
            List<bool> row = new List<bool> { false, false, false, false, false, false, false, false, false, };
            List<bool> column = new List<bool> { false, false, false, false, false, false, false, false, false, };
            foreach (var value in noticeValue)
            {
                row[value / 9] = true;
                column[value % 9] = true;
            }

            return (row[0] ? 1 : 0) + (row[1] ? 1 : 0) + (row[2] ? 1 : 0) >= 2
                   && (row[3] ? 1 : 0) + (row[4] ? 1 : 0) + (row[5] ? 1 : 0) >= 2
                   && (row[6] ? 1 : 0) + (row[7] ? 1 : 0) + (row[8] ? 1 : 0) >= 2
                   && (column[0] ? 1 : 0) + (column[1] ? 1 : 0) + (column[2] ? 1 : 0) >= 2
                   && (column[3] ? 1 : 0) + (column[4] ? 1 : 0) + (column[5] ? 1 : 0) >= 2
                   && (column[6] ? 1 : 0) + (column[7] ? 1 : 0) + (column[8] ? 1 : 0) >= 2
                ;
        }

        public static string ListToString(List<List<int>> tempquestion)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var list in tempquestion)
            {
                foreach (var value in list)
                {
                    sb.Append(value);

                }

            }

            return sb.ToString();
        }

        public static bool IsVaildSoduku(List<List<int>> question)
        {
            return !string.IsNullOrEmpty(new DanceLink().do_solve(StaticTools.ListToString(question)));
        }

        public static void InitQuestion(List<int> list1, List<List<int>> tempquestion)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!list1.Contains(i * 9 + j))
                    {
                        tempquestion[i][j] = 0;
                    }
                }
            }
        }


        public static List<List<int>> StringToList(string str)
        {
            var arr = str.ToCharArray();
            List<List<int>> result = new List<List<int>>()
            {
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0},
                new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0}
            };
            for(int i=0;i<9;i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    result[i][j] = Convert.ToInt32("" + arr[i * 9 + j]);
                }
            }


            return result;

        }

        public static List<List<int>> Choose2from9 = new List<List<int>>
        {
            new List<int> {8, 9},
            new List<int> {7, 9},
            new List<int> {6, 9},
            new List<int> {5, 9},
            new List<int> {4, 9},
            new List<int> {3, 9},
            new List<int> {2, 9},
            new List<int> {1, 9},
            new List<int> {7, 8},
            new List<int> {6, 8},
            new List<int> {5, 8},
            new List<int> {4, 8},
            new List<int> {3, 8},
            new List<int> {2, 8},
            new List<int> {1, 8},
            new List<int> {6, 7},
            new List<int> {5, 7},
            new List<int> {4, 7},
            new List<int> {3, 7},
            new List<int> {2, 7},
            new List<int> {1, 7},
            new List<int> {5, 6},
            new List<int> {4, 6},
            new List<int> {3, 6},
            new List<int> {2, 6},
            new List<int> {1, 6},
            new List<int> {4, 5},
            new List<int> {3, 5},
            new List<int> {2, 5},
            new List<int> {1, 5},
            new List<int> {3, 4},
            new List<int> {2, 4},
            new List<int> {1, 4},
            new List<int> {2, 3},
            new List<int> {1, 3},
            new List<int> {1, 2}

        };


        public static List<List<int>> symmetry = new List<List<int>>
        {
            new List<int> {0, 80},
            new List<int> {1, 79},
            new List<int> {2, 78},
            new List<int> {3, 77},
            new List<int> {4, 76},
            new List<int> {5, 75},
            new List<int> {6, 74},
            new List<int> {7, 73},
            new List<int> {8, 72},
            new List<int> {9, 71},
            new List<int> {10, 70},
            new List<int> {11, 69},
            new List<int> {12, 68},
            new List<int> {13, 67},
            new List<int> {14, 66},
            new List<int> {15, 65},
            new List<int> {16, 64},
            new List<int> {17, 63},
            new List<int> {18, 62},
            new List<int> {19, 61},
            new List<int> {20, 60},
            new List<int> {21, 59},
            new List<int> {22, 58},
            new List<int> {23, 57},
            new List<int> {24, 56},
            new List<int> {25, 55},
            new List<int> {26, 54},
            new List<int> {27, 53},
            new List<int> {28, 52},
            new List<int> {29, 51},
            new List<int> {30, 50},
            new List<int> {31, 49},
            new List<int> {32, 48},
            new List<int> {33, 47},
            new List<int> {34, 46},
            new List<int> {35, 45},
            new List<int> {36, 44},
            new List<int> {37, 43},
            new List<int> {38, 42},
            new List<int> {39, 41},

        };


    }
}
