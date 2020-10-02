﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class YearMonth
    {
        //4.1.1
        public int Year { get; set; }
        public int Month { get; set; }
        //コンストラクタ
        public YearMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }

        //4.1.2
        //Is21Centuryプロパティ
        public bool Is21Centurty
        {
            get
            {
                return 2001 <= Year && Year <= 2100;
            }
        }

        //4.1.3
        //AddOneMonth()メソッドを追加
        public YearMonth AddOneMonth()
        {
            if (Month == 12)
            {
                return new YearMonth(this.Year + 1, 1);
            }
            else
            {
                return new YearMonth(this.Year, this.Month + 1);
            }
        }

        //4.1.4
        //ToString()メソッドのオーバーライド
        public override string ToString()
        {
            return $"2017年8月";
        }

        // 4.2.1
        var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
        };       
    }
}
