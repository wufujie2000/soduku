﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku
{
    /// <summary>
    /// 数独生成类
    /// </summary>
   public class SodukuBuilder
    {
        /// <summary>
        /// 制作完整的数独
        /// </summary>
        /// <returns></returns>
        public List<List<int>> MakeSoduku()
        {
            Random rm = new Random();
            var list1 = GetRandom(1, true, 9, true, 9, rm, false);
            var list2 = moveToTail(list1, 3);
            var list3 = moveToTail(list1, 6);
            var list4 = moveToTail(list1, 1);
            var list5 = moveToTail(list1, 4);
            var list6 = moveToTail(list1, 7);
            var list7 = moveToTail(list1, 2);
            var list8 = moveToTail(list1, 5);
            var list9 = moveToTail(list1, 8);
            return new List<List<int>> { list1, list2, list3, list4, list5, list6, list7, list8, list9 };
        }

        /// <summary>
        /// 交换两行
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private List<List<int>> switchTwoRows(List<List<int>> lists, int row1, int row2)
        {
            return new List<List<int>>();
        }

        /// <summary>
        /// 交换两列
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private List<List<int>> switchTwoColumn(List<List<int>> lists, int column1, int column2)
        {
            return new List<List<int>>();
        }

        /// <summary>
        /// 交换两列块
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private List<List<int>> switchTwoColumnBlocks(List<List<int>> lists, int block1, int block2)
        {
            return new List<List<int>>();
        }


        /// <summary>
        /// 交换两行块
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private List<List<int>> switchTwoRowsBlocks(List<List<int>> lists, int block1, int block2)
        {
            return new List<List<int>>();
        }

        /// <summary>
        /// 交换两个值
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns>
        private List<List<int>> switchTwoValue(List<List<int>> lists, int value1, int value2)
        {
            return new List<List<int>>();
        }

        /// <summary>
        /// 根据随机数范围获取一定数量的随机数
        /// </summary>
        /// <param name="minNum">随机数最小值</param>
        /// <param name="minNum">是否包含最小值</param>
        /// <param name="maxNum">随机数最大值</param>
        /// <param name="minNum">是否包含最大值</param>
        /// <param name="ResultCount">随机结果数量</param>
        /// <param name="rm">随机数对象</param>
        /// <param name="isSame">结果是否重复</param>
        /// <returns></returns>
        public static List<int> GetRandom(int minNum, bool isIncludeMinNum, int maxNum, bool isIncludeMaxNum,
            int ResultCount, Random rm, bool isSame)
        {
            List<int> randomList = new List<int>();
            int nValue = 0;

            #region 是否包含最大最小值，默认包含最小值，不包含最大值

            if (!isIncludeMinNum)
            {
                minNum = minNum + 1;
            }

            if (isIncludeMaxNum)
            {
                maxNum = maxNum + 1;
            }

            #endregion

            if (isSame)
            {
                for (int i = 0; randomList.Count < ResultCount; i++)
                {
                    nValue = rm.Next(minNum, maxNum);
                    randomList.Add(nValue);
                }
            }
            else
            {
                for (int i = 0; randomList.Count < ResultCount; i++)
                {
                    nValue = rm.Next(minNum, maxNum);
                    //重复判断
                    if (!randomList.Contains(nValue))
                    {
                        randomList.Add(nValue);
                    }
                }
            }

            return randomList;
        }


        private List<int> moveToTail(List<int> list, int size)
        {
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i < size)
                {
                    a.Add(list[i]);
                }
                else
                {
                    b.Add(list[i]);
                }
            }

            b.AddRange(a);
            return b;
        }
    }
}