using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication12
{
    class DataAnalysis
    {
        public static void tri(string[] data)
        {
            int n = data.Length - 1;
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
                d[i] = Int32.Parse(data[i]);
            int min, aux;
            for (int j = 0; j < n - 1; j++)
            {
                min = d[j];
                for (int i = j + 1; i < n; i++)
                    if (d[i] < min)
                    {
                        aux = min;
                        min = d[i];
                        d[i] = aux;
                    }
                d[j] = min;
            }
            for (int i = 0; i < n; i++)
                data[i] = d[i].ToString();
        }
        public static void ObservationByModality(ref int[] obm, string[] modalite, string[] observation)
        {
            int n = modalite.Length - 1;
            obm = new int[n];
            for (int i = 0; i < modalite.Length - 1; i++)
            {
                obm[i] = 0;
                for (int j = 0; j < observation.Length - 1; j++)
                    if (Int32.Parse(modalite[i]) == Int32.Parse(observation[j]))
                        obm[i] += 1;
            }
            
        }
        public static void FrequenceDistribution(ref float[] fd, string[] modalite, string[] observation)
        {
            int[] obm = new int[modalite.Length - 1];
            fd = new float[modalite.Length - 1];
            ObservationByModality(ref obm, modalite, observation);
            float s = 0;
            for (int i = 0; i < modalite.Length - 1; i++)
            {
                s = s + (float)obm[i];
            }
            for (int i = 0; i < modalite.Length - 1; i++)
            {
                fd[i] = (float)obm[i] / s;
            }
        }
        public static void CumFrepDistribution(ref float[] cfd, string[] modalite, string[] observation)
        {
            float[] fd = new float[modalite.Length - 1];
            cfd = new float[modalite.Length - 1];
            FrequenceDistribution(ref fd, modalite, observation);
            cfd[0] = fd[0];
            for (int i = 1; i < modalite.Length - 1; i++)
            {
                cfd[i] = cfd[i - 1] + fd[i];
            }
        }
        public static void Mediane1(ref float mediane, string[] modalite, string[] observation)
        {
            float[] fd = new float[modalite.Length - 1];
            FrequenceDistribution(ref fd, modalite, observation);
            float s = 0, val = 0;
            int k = 0, pos = 0;
            while (k < modalite.Length - 1 & s < 0.5)
            {
                s = s + fd[k];
                if (s >= 0.5)
                    val = s;
                k++;
            }
            k = 0;
            s = 0;
            while (k < modalite.Length - 1 & val != s)
            {
                s = s + fd[k];
                if (val == s)
                    pos = k;
                k++;
            }
            mediane = float.Parse(modalite[pos]);
        }
        public static void Mediane2(ref float mediane, string[] modalite, string[] observation)
        {
            int[] obm = new int[modalite.Length];
            ObservationByModality(ref obm, modalite, observation);
            int s = 0, val = 0, k = 0, pos = -1;
            for (int i = 0; i < modalite.Length - 1; i++)
            {
                s += obm[i];
            }
            if (s % 2 == 0)
            {
                val = (s / 2) + 1;
            }
            else
            {
                val = (s + 1) / 2;
            }
            s = 0;
            while (k < modalite.Length - 1 & pos < k)
            {
                s += obm[k];
                if (val <= s)
                {
                    pos = k;
                    break;
                }
                k++;
            }
            mediane = float.Parse(modalite[pos]);
        }
        public static void Mean(ref float moy, string[] observation)
        {
            float s = 0;
            for (int i = 0; i < observation.Length - 1; i++)
            {
                s += float.Parse(observation[i]);
            }
            moy = (float)s / (observation.Length - 1);
        }
        public static void Var(ref float var, string[] modalite, string[] observation)
        {
            float moy = 0;
            var = 0;
            Mean(ref moy, observation);
            for (int i = 0; i < observation.Length - 1; i++)
            {
                var = var + (float.Parse(observation[i]) - moy) * (float.Parse(observation[i]) - moy) / (observation.Length - 1);
            }
        }
        public static void std(ref float std, string[] modalite, string[] observation)
        {
            float var = 0;
            Var(ref var, modalite, observation);
            std = (float)Math.Sqrt(var);
        }
    }
}
