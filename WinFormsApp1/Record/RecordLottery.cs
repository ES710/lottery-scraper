using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Record
{
    public record RecordLottery
    {
        /// <summary>抽選回</summary>
        public int LotteryNo { get; set; }
        /// <summary>抽選日</summary>
        public DateOnly LotteryDate { get; set; }
        /// <summary>本数字</summary>
        public IReadOnlyList<string> LotteryNumbers { get; set; } = [];
        /// <summary>抽選回</summary>
        public string LotteryBonus { get; set; } = "";
    }
}
