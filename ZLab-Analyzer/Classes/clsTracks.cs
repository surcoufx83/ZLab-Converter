using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZLab_Analyzer.XLS
{
    class clsTrack
    {

        string sLocation, sFishname, sDatatype, sUser, sStartReason, sEndReason;
        decimal dStart, dEnd, dInadur, dInadist, dSmldur, dSmldist, dLardur, dLardist, dEmptydur;
        decimal dSumDurationTotal, dSumDurationEntries, dDiffDurations, dSumDistance;
        decimal dRelInadur, dRelSmldur, dRelLardur, dRelEmpdur;
        decimal dRelInadist, dRelSmldist, dRelLardist;
        int iEntct, iInact, iSmlct, iLarct, iEmptyct, iSn, iAn;
        DateTime dtTrack;

        public clsTrack(string[] TrackData)
        {
            sLocation = TrackData[0].Trim();
            sUser = TrackData[2].Trim();
            sFishname = TrackData[1].Trim();
            iSn = int.Parse(TrackData[3].Trim()); // Unknown?
            iAn = int.Parse(TrackData[4].Trim()); // Areal Number
            sDatatype = TrackData[5].Trim();
            dStart = decimal.Parse(TrackData[6].Trim(), ciprovider.en_US);
            dEnd = decimal.Parse(TrackData[7].Trim(), ciprovider.en_US);
            sStartReason = TrackData[8].Trim();
            sEndReason = TrackData[9].Trim();
            iEntct = int.Parse(TrackData[10].Trim());
            iInact = int.Parse(TrackData[11].Trim());
            dInadur = decimal.Parse(TrackData[12].Trim(), ciprovider.en_US);
            dInadist = decimal.Parse(TrackData[13].Trim(), ciprovider.en_US);
            iSmlct = int.Parse(TrackData[14].Trim());
            dSmldur = decimal.Parse(TrackData[15].Trim(), ciprovider.en_US);
            dSmldist = decimal.Parse(TrackData[16].Trim(), ciprovider.en_US);
            iLarct = int.Parse(TrackData[17].Trim());
            dLardur = decimal.Parse(TrackData[18].Trim(), ciprovider.en_US);
            dLardist = decimal.Parse(TrackData[19].Trim(), ciprovider.en_US);
            iEmptyct = int.Parse(TrackData[20].Trim());
            dEmptydur = decimal.Parse(TrackData[21].Trim(), ciprovider.en_US);
            dtTrack = DateTime.ParseExact(TrackData[22].Trim() + " " + TrackData[23].Trim(),@"dd/MM/yyyy HH:mm:ss" , ciprovider.fr_CA);
            dSumDurationTotal = dEnd - dStart;
            dSumDurationEntries = dInadur + dSmldur + dLardur + dEmptydur;
            dDiffDurations = Math.Abs(dSumDurationEntries - dSumDurationTotal);
            if (dSumDurationEntries != (decimal)0.0)
            {
                dRelInadur = dInadur / dSumDurationEntries * (decimal)100.0;
                dRelSmldur = dSmldur / dSumDurationEntries * (decimal)100.0;
                dRelLardur = dLardur / dSumDurationEntries * (decimal)100.0;
                dRelEmpdur = dEmptydur / dSumDurationEntries * (decimal)100.0;
            }
            dSumDistance = dInadist + dSmldist + dLardist;
            if (dSumDistance != (decimal)0.0)
            {
                dRelInadist = dInadist / dSumDistance * 100;
                dRelSmldist = dSmldist / dSumDistance * 100;
                dRelLardist = dLardist / dSumDistance * 100;
            }
        }

        public string Datatype { get { return sDatatype; } }
        public string Fish { get { return sFishname; } }
        public string Location { get { return sLocation; } }
        public string User { get { return sUser; } }
        public string StartReason { get { return sStartReason; } }
        public string EndReason { get { return sEndReason; } }

        public decimal Start { get { return dStart; } }
        public decimal End { get { return dEnd; } }
        public decimal StartEndDiff { get { return dSumDurationTotal; } }
        public decimal RelInactiveDuration { get { return dRelInadur; } }
        public decimal InactiveDuration { get { return dInadur; } }
        public decimal InactiveDistance { get { return dInadist; } }
        public decimal RelInactiveDistance { get { return dRelInadist; } }
        public decimal RelSmallDuration { get { return dRelSmldur; } }
        public decimal SmallDuration { get { return dSmldur; } }
        public decimal RelSmallDistance { get { return dRelSmldist; } }
        public decimal SmallDistance { get { return dSmldist; } }
        public decimal RelLargeDuration { get { return dRelLardur; } }
        public decimal LargeDuration { get { return dLardur; } }
        public decimal RelLargeDistance { get { return dRelLardist; } }
        public decimal LargeDistance { get { return dLardist; } }
        public decimal RelEmptyDuration { get { return dRelEmpdur; } } // not recognized by system
        public decimal EmptyDuration { get { return dEmptydur; } } // not recognized by system
        public decimal DistanceSum { get { return dSumDistance; } }
        public decimal DurationSum { get { return dSumDurationEntries; } }
        public decimal DurationDifferences { get { return dDiffDurations; } }

        public int An { get { return iAn; } }
        public int Sn { get { return iSn; } }
        public int Entct { get { return iEntct; } }
        public int InactiveCount { get { return iInact; } }
        public int SmallCount { get { return iSmlct; } }
        public int LargeCount { get { return iLarct; } }
        public int EmptyCount { get { return iEmptyct; } }

        public DateTime TrackDate { get { return dtTrack; } }

    }
}
