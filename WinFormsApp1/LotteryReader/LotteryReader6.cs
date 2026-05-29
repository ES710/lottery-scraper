using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using WinFormsApp1.Record;
using HtmlAgilityPack;

namespace WinFormsApp1.LotteryReader
{
    internal class LotteryReader6
    {
        public void ReadLottery6(string filePath)
        {
            var flgTableStart = false;
            var flgTr = false;
            var listLoto6 = new List<ModelLottery6>();
            var loto6 = new ModelLottery6();


            foreach (string line in File.ReadLines(filePath))
            {
                if (flgTableStart && line == "</tbody>") break;

                if (flgTableStart == false && line == "<tbody class=\"section__table-body\">")
                {
                    flgTableStart = true;
                    continue;
                }

                if (flgTableStart == false) continue;

                if (line == "</tr>")
                {
                    if (flgTr)
                    {
                        listLoto6.Add(loto6);
                        loto6 = new ModelLottery6();
                    }
                    else
                    {
                        flgTr = true;
                        continue;
                    }
                }

                if (!flgTr) continue;

                var matchNo = Regex.Match(line, @"第(\d+)回");
                if (matchNo.Success)
                {
                    loto6.LotteryNo = int.Parse(matchNo.Groups[1].Value);
                }

                var matchDate = Regex.Match(line, @"(\d{4})年(\d{1,2})月(\d{1,2})日");
                if (matchDate.Success)
                {
                    loto6.LotteryDate = new DateTime(int.Parse(matchDate.Groups[1].Value), int.Parse(matchDate.Groups[2].Value), int.Parse(matchDate.Groups[3].Value));
                }

                var matchNumber = Regex.Match(line, @"section__text--small""[^>]*>(\d+)<");
                if (matchNumber.Success)
                {
                    loto6.LotteryNumbers.Add(matchNumber.Groups[1].Value);
                }

                var matchBonus = Regex.Match(line, @"section__text--important""[^>]*>(\d+)<");
                if (matchBonus.Success)
                {
                    loto6.LotteryBonus = matchBonus.Groups[1].Value;
                }
            }
        }
    }
}
