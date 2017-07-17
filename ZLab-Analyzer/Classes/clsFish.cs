using System;
using System.Collections.Generic;
using System.Linq;

namespace ZLab_Analyzer.XLS
{
    class clsFish
    {

        string sName;
        string sNumber;
        public bool FilteredManually { get; set; }
        SortedList<int, clsTrack> lTracks = new SortedList<int, clsTrack>();

        int iColumn;
        int iRow;

        public int CustomGroup = 0;

        public clsFish(string[] sTrack)
        {
            FilteredManually = false;
            sName = sTrack[1];
            iRow = Convert.ToChar(sName.Substring(0, 1).ToUpper()) - 64;
            int iCol = 0;
            int.TryParse(sName.Substring(1).TrimStart('0'), out iCol);
            iColumn = iCol;
            sNumber = sTrack[0].Substring(3).TrimStart('0');
            AddTrack(sTrack);
        }

        public void AddTrack(string[] sTrack)
        {
            lTracks.Add(lTracks.Count, new clsTrack(sTrack));
        }

        public int GetCleanedTracksCount(bool RemoveDuplicates, bool RemoveInvalideDuration)
        {
            int ctr = 0;
            foreach (int iKey in lTracks.Keys)
            {
                if (RemoveDuplicates && lTracks[iKey].An == 1) continue;
                if (RemoveInvalideDuration && lTracks[iKey].DurationDifferences > (decimal)0.1) continue;
                ctr++;
            }
            return ctr;
        }

        public string GetCleanedTracks(clsFilter oFilter)
        {
            string sOut = "";

            double dTMin_Slow = (double)oFilter.Track_Slow_Min, dTMax_Slow = (double)oFilter.Track_Slow_Max, dTValue_Slow;
            double dTMin_Fast = (double)oFilter.Track_Fast_Min, dTMax_Fast = (double)oFilter.Track_Fast_Max, dTValue_Fast;
            double dTMin_Inactive = (double)oFilter.Track_Inactive_Min, dTMax_Inactive = (double)oFilter.Track_Inactive_Max, dTValue_Inactive;
            double dTMin_Empty = 0.0, dTMax_Empty = (double)oFilter.Track_Empty_Max, dTValue_Empty;

            foreach (int iKey in lTracks.Keys)
            {
                if (oFilter.RemoveDuplicates && lTracks[iKey].An == 1) continue;
                if (oFilter.RemoveLinesWithInvalidSum && lTracks[iKey].DurationDifferences > (decimal)0.1) continue;

                dTValue_Slow = (double)lTracks[iKey].RelSmallDuration;
                dTValue_Fast = (double)lTracks[iKey].RelLargeDuration;
                dTValue_Inactive = (double)lTracks[iKey].RelInactiveDuration;
                dTValue_Empty = (double)lTracks[iKey].RelEmptyDuration;

                if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow) continue;
                if (dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast) continue;
                if (dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive) continue;
                if (dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty) continue;

                sOut += lTracks[iKey].Location + "\t" + lTracks[iKey].Fish + "\t" + CustomGroup.ToString() + "\t" + lTracks[iKey].User + "\t" + lTracks[iKey].Sn.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].An.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].Datatype + "\t" + lTracks[iKey].Start.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].End.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].StartReason + "\t" + lTracks[iKey].EndReason + "\t" + lTracks[iKey].Entct.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].InactiveCount.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].InactiveDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].InactiveDistance.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].SmallCount.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].SmallDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].SmallDistance.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].LargeCount.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].LargeDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].LargeDistance.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].EmptyCount.ToString("N0", ciprovider.Default).Replace(",", "") + "\t" + lTracks[iKey].EmptyDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].TrackDate.ToString("d", ciprovider.Default) + "\t" + lTracks[iKey].TrackDate.ToString("T", ciprovider.Default);

                if (oFilter.AdditionalDataColumns)
                    sOut += "\t" + lTracks[iKey].DurationSum.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelInactiveDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelSmallDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelLargeDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelEmptyDuration.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].DistanceSum.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelInactiveDistance.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelSmallDistance.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8) + "\t" + lTracks[iKey].RelLargeDistance.ToString("N1", ciprovider.Default).Replace(",", "").PadLeft(8);

                sOut += "\r\n";
            }
            return sOut;
        }

        public double[] GetTrackTimes(clsFilter oFilter)
        {
            // dOut = {slow, fast, inactive, empty)
            double[] dOut = { 0.0, 0.0, 0.0, 0.0 };
            double dSum = 0.0;

            foreach (int iKey in lTracks.Keys)
            {
                if (lTracks[iKey].An == 1)
                {
                    continue;
                }
                if (lTracks[iKey].DurationDifferences > (decimal)0.1 && oFilter.RemoveLinesWithInvalidSum)
                {
                    continue;
                }
                dOut[0] += (double)lTracks[iKey].SmallDuration;
                dOut[1] += (double)lTracks[iKey].LargeDuration;
                dOut[2] += (double)lTracks[iKey].InactiveDuration;
                dOut[3] += (double)lTracks[iKey].EmptyDuration;
                dSum += (double)lTracks[iKey].DurationSum;
            }
            for (int i = 0; i < 4; i++)
            {
                if (dSum != 0.0)
                    dOut[i] = dOut[i] / dSum * 100.0;
                else
                    dOut[i] = 0.0;
            }
            return dOut;
        }

        public double[] GetTrackTimes_PostProcessing(clsFilter oFilter)
        {

            // dOut = {slow, fast, inactive, empty)
            double[] dOut = { 0.0, 0.0, 0.0, 0.0 };
            double dSumTotal = 0.0;

            double a = (double)LinesLeft(oFilter);
            double b = (double)lTracks.Count - (double)GetTrackCount_Duplicates();
            double c = (double)a / (double)b * 100.0d;
            if (c < (double)oFilter.Animal_LinesThreshold) return dOut;

            if (FilteredManually)
                return dOut;

            double dTMin_Slow = (double)oFilter.Track_Slow_Min, dTMax_Slow = (double)oFilter.Track_Slow_Max, dTValue_Slow;
            double dTMin_Fast = (double)oFilter.Track_Fast_Min, dTMax_Fast = (double)oFilter.Track_Fast_Max, dTValue_Fast;
            double dTMin_Inactive = (double)oFilter.Track_Inactive_Min, dTMax_Inactive = (double)oFilter.Track_Inactive_Max, dTValue_Inactive;
            double dTMin_Empty = 0.0, dTMax_Empty = (double)oFilter.Track_Empty_Max, dTValue_Empty;

            foreach (int iKey in lTracks.Keys)
            {
                if (lTracks[iKey].An == 1)
                {
                    continue;
                }

                if (!oFilter.Chart_UpscaleResultchart)
                    dSumTotal += (double)lTracks[iKey].DurationSum;

                if (lTracks[iKey].DurationDifferences > (decimal)0.1 && oFilter.RemoveLinesWithInvalidSum)
                    continue;

                dTValue_Slow = (double)lTracks[iKey].RelSmallDuration;
                dTValue_Fast = (double)lTracks[iKey].RelLargeDuration;
                dTValue_Inactive = (double)lTracks[iKey].RelInactiveDuration;
                dTValue_Empty = (double)lTracks[iKey].RelEmptyDuration;

                if (dTValue_Slow >= dTMin_Slow && dTValue_Slow <= dTMax_Slow &&
                    dTValue_Fast >= dTMin_Fast && dTValue_Fast <= dTMax_Fast &&
                    dTValue_Inactive >= dTMin_Inactive && dTValue_Inactive <= dTMax_Inactive &&
                    dTValue_Empty >= dTMin_Empty && dTValue_Empty <= dTMax_Empty)
                {
                    dOut[0] += (double)lTracks[iKey].SmallDuration;
                    dOut[1] += (double)lTracks[iKey].LargeDuration;
                    dOut[2] += (double)lTracks[iKey].InactiveDuration;
                    dOut[3] += (double)lTracks[iKey].EmptyDuration;
                    if (oFilter.Chart_UpscaleResultchart)
                        dSumTotal += (double)lTracks[iKey].DurationSum;
                }
                else
                    continue;

            }
            for (int i = 0; i < 4; i++)
            {
                if (dSumTotal != 0.0)
                    dOut[i] = dOut[i] / dSumTotal * 100.0;
                else
                    dOut[i] = 0.0;
            }
            return dOut;
        }

        public double[] GetFilteredTrackCount (clsFilter oFilter)
        {
            double[] dOut = { 0.0, 0.0, 0.0, 0.0, 0.0 };
            int[] iCtr = { 0, 0, 0, 0, 0, 0 };

            double dTMin_Slow = (double)oFilter.Track_Slow_Min, dTMax_Slow = (double)oFilter.Track_Slow_Max, dTValue_Slow;
            double dTMin_Fast = (double)oFilter.Track_Fast_Min, dTMax_Fast = (double)oFilter.Track_Fast_Max, dTValue_Fast;
            double dTMin_Inactive = (double)oFilter.Track_Inactive_Min, dTMax_Inactive = (double)oFilter.Track_Inactive_Max, dTValue_Inactive;
            double dTMin_Empty = 0.0, dTMax_Empty = (double)oFilter.Track_Empty_Max, dTValue_Empty;

            foreach (int iKey in lTracks.Keys)
            {
                if (oFilter.RemoveDuplicates && lTracks[iKey].An == 1)
                {
                    iCtr[5]++;
                    continue;
                }
                if (oFilter.RemoveLinesWithInvalidSum && lTracks[iKey].DurationDifferences > (decimal)0.1)
                {
                    iCtr[5]++;
                    continue;
                }

                dTValue_Slow = (double)lTracks[iKey].RelSmallDuration;
                dTValue_Fast = (double)lTracks[iKey].RelLargeDuration;
                dTValue_Inactive = (double)lTracks[iKey].RelInactiveDuration;
                dTValue_Empty = (double)lTracks[iKey].RelEmptyDuration;

                if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow)
                {
                    iCtr[0]++;
                    continue;
                }
                if (dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast)
                {
                    iCtr[1]++;
                    continue;
                }
                if (dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive)
                {
                    iCtr[2]++;
                    continue;
                }
                if (dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty)
                {
                    iCtr[3]++;
                    continue;
                }
                iCtr[4]++;
            }
            for (int i=0; i<5; i++)
            {
                dOut[i] = ((double)iCtr[i] / (double)(lTracks.Keys.Count() - iCtr[5])) * 100.0;
            }
            return dOut;
        }

        public double[] GetFilteredTrackCount_Simple(clsFilter oFilter)
        {
            double[] dOut = { 0.0, 0.0 };
            int[] iCtr = { 0, 0, 0, 0 };

            double dTMin_Slow = (double)oFilter.Track_Slow_Min, dTMax_Slow = (double)oFilter.Track_Slow_Max, dTValue_Slow;
            double dTMin_Fast = (double)oFilter.Track_Fast_Min, dTMax_Fast = (double)oFilter.Track_Fast_Max, dTValue_Fast;
            double dTMin_Inactive = (double)oFilter.Track_Inactive_Min, dTMax_Inactive = (double)oFilter.Track_Inactive_Max, dTValue_Inactive;
            double dTMin_Empty = 0.0, dTMax_Empty = (double)oFilter.Track_Empty_Max, dTValue_Empty;

            foreach (int iKey in lTracks.Keys)
            {
                iCtr[2]++;
                if (oFilter.RemoveDuplicates && lTracks[iKey].An == 1)
                {
                    iCtr[0]++;
                    iCtr[3]++;
                    continue;
                }
                if (oFilter.RemoveLinesWithInvalidSum && lTracks[iKey].DurationDifferences > (decimal)0.1)
                {
                    iCtr[0]++;
                    continue;
                }

                dTValue_Slow = (double)lTracks[iKey].RelSmallDuration;
                dTValue_Fast = (double)lTracks[iKey].RelLargeDuration;
                dTValue_Inactive = (double)lTracks[iKey].RelInactiveDuration;
                dTValue_Empty = (double)lTracks[iKey].RelEmptyDuration;

                if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow || 
                        dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast || 
                        dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive ||
                        dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty)
                {
                    iCtr[0]++;
                    continue;
                }
                iCtr[1]++;
            }
            for (int i = 0; i < 2; i++)
            {
                dOut[i] = ((double)iCtr[i] / (double)(lTracks.Keys.Count() - iCtr[3])) * 100.0;
            }
            return dOut;
        }

        public int LinesLeft(clsFilter oFilter)
        {
            int iCtr = 0;

            double dTMin_Slow = (double)oFilter.Track_Slow_Min, dTMax_Slow = (double)oFilter.Track_Slow_Max, dTValue_Slow;
            double dTMin_Fast = (double)oFilter.Track_Fast_Min, dTMax_Fast = (double)oFilter.Track_Fast_Max, dTValue_Fast;
            double dTMin_Inactive = (double)oFilter.Track_Inactive_Min, dTMax_Inactive = (double)oFilter.Track_Inactive_Max, dTValue_Inactive;
            double dTMin_Empty = 0.0, dTMax_Empty = (double)oFilter.Track_Empty_Max, dTValue_Empty;

            foreach (int iKey in lTracks.Keys)
            {
                if (oFilter.RemoveDuplicates && lTracks[iKey].An == 1) continue;
                if (oFilter.RemoveLinesWithInvalidSum && lTracks[iKey].DurationDifferences > (decimal)0.1)  continue;

                dTValue_Slow = (double)lTracks[iKey].RelSmallDuration;
                dTValue_Fast = (double)lTracks[iKey].RelLargeDuration;
                dTValue_Inactive = (double)lTracks[iKey].RelInactiveDuration;
                dTValue_Empty = (double)lTracks[iKey].RelEmptyDuration;

                if (dTValue_Slow < dTMin_Slow || dTValue_Slow > dTMax_Slow ||
                        dTValue_Fast < dTMin_Fast || dTValue_Fast > dTMax_Fast ||
                        dTValue_Inactive < dTMin_Inactive || dTValue_Inactive > dTMax_Inactive ||
                        dTValue_Empty < dTMin_Empty || dTValue_Empty > dTMax_Empty)
                    continue;
                iCtr++;
            }
            return iCtr;
        }

        public int GetTrackCount_Duplicates()
        {
            int ctr = 0;
            foreach (int iKey in lTracks.Keys)
            {
                if (lTracks[iKey].An == 1) ctr++;
            }
            return ctr;
        }

        public int GetTrackCount_InvalidDuration(clsFilter oFilter = null)
        {
            int ctr = 0;
            bool bCheckAn = false;
            if (oFilter != null)
                bCheckAn = oFilter.RemoveDuplicates;
            foreach (int iKey in lTracks.Keys)
            {
                if (lTracks[iKey].DurationDifferences > (decimal)0.1 && ((lTracks[iKey].An != 1 && bCheckAn == true) || bCheckAn == false)) ctr++;
            }
            return ctr;
        }

        public double GetFishRel_Inadur(bool WithoutDuplicates, bool WithoutInvalidSum)
        {
            double dSum = 0.0;
            double dTotal = 0.0;
            foreach (int iKey in lTracks.Keys)
            {
                if ((!WithoutDuplicates || lTracks[iKey].An == 0) && (!WithoutInvalidSum || lTracks[iKey].DurationDifferences <= (decimal)0.1))
                {
                    dSum += (double)lTracks[iKey].InactiveDuration;
                    dTotal += (double)lTracks[iKey].DurationSum;
                }
            }
            return (dTotal != 0.0 ? dSum / dTotal * 100.0 : 0.0);
        }

        public double GetFishRel_Smldur(bool WithoutDuplicates, bool WithoutInvalidSum)
        {
            double dSum = 0.0;
            double dTotal = 0.0;
            foreach (int iKey in lTracks.Keys)
            {
                if ((!WithoutDuplicates || lTracks[iKey].An == 0) && (!WithoutInvalidSum || lTracks[iKey].DurationDifferences <= (decimal)0.1))
                {
                    dSum += (double)lTracks[iKey].SmallDuration;
                    dTotal += (double)lTracks[iKey].DurationSum;
                }
            }
            return (dTotal != 0.0 ? dSum / dTotal * 100.0 : 0.0);
        }

        public double GetFishRel_Lardur(bool WithoutDuplicates, bool WithoutInvalidSum)
        {
            double dSum = 0.0;
            double dTotal = 0.0;
            foreach (int iKey in lTracks.Keys)
            {
                if ((!WithoutDuplicates || lTracks[iKey].An == 0) && (!WithoutInvalidSum || lTracks[iKey].DurationDifferences <= (decimal)0.1))
                {
                    dSum += (double)lTracks[iKey].LargeDuration;
                    dTotal += (double)lTracks[iKey].DurationSum;
                }
            }
            return (dTotal != 0.0 ? dSum / dTotal * 100.0 : 0.0);
        }

        public double GetFishRel_Empdur(bool WithoutDuplicates, bool WithoutInvalidSum)
        {
            double dSum = 0.0;
            double dTotal = 0.0;
            foreach (int iKey in lTracks.Keys)
            {
                if ((!WithoutDuplicates || lTracks[iKey].An == 0) && (!WithoutInvalidSum || lTracks[iKey].DurationDifferences <= (decimal)0.1))
                {
                    dSum += (double)lTracks[iKey].EmptyDuration;
                    dTotal += (double)lTracks[iKey].DurationSum;
                }
            }
            return (dTotal != 0.0 ? dSum / dTotal * 100.0 : 0.0);
        }

        public string Name
        {
            get { return sName; }
        }

        public string Number
        {
            get { return sNumber; }
        }

        public SortedList<int, clsTrack> Tracks
        {
            get { return lTracks;  }
        }

        public int Column { get { return iColumn; } }
        public int Row { get { return iRow; } }

        public string GridViewText(ZLabConfiguration Conf)
        {
            string s = sName + Environment.NewLine;
            if (Conf.CurrentFilter.GroupName(CustomGroup) == "")
                s += Properties.strings.grouping_celltitle_group + " " + CustomGroup.ToString();
            else
                s += Conf.CurrentFilter.GroupName(CustomGroup);
            return s;
        }

    }
    
}
