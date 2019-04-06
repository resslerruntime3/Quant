﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Reactive.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using quant.common;
using quant.rx;

namespace quant.rx.test
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class CMO_Test
    {
        /// <summary>
        /// Data File (etfhq.com-chande-momentum-oscillator.xls)
        /// http://www.etfhq.com/download.php?fileID=5
        /// </summary>
        static IList<BarData> INPUT
        {
            get
            {
                return new BarData[] {
                    new BarData("10/02/1989", 2688.00, 2724.16, 2677.05, 2713.72),
                    new BarData("10/03/1989", 2713.72, 2765.96, 2708.97, 2754.56),
                    new BarData("10/04/1989", 2754.56, 2785.52, 2738.79, 2771.09),
                    new BarData("10/05/1989", 2771.09, 2797.11, 2747.15, 2773.56),
                    new BarData("10/06/1989", 2773.56, 2808.13, 2765.58, 2785.52),
                    new BarData("10/09/1989", 2785.52, 2804.52, 2766.32, 2791.41),
                    new BarData("10/10/1989", 2791.41, 2809.08, 2766.53, 2785.33),
                    new BarData("10/11/1989", 2785.33, 2790.98, 2750.82, 2773.36),
                    new BarData("10/12/1989", 2773.36, 2785.25, 2744.06, 2759.84),
                    new BarData("10/13/1989", 2759.84, 2773.36, 2545.49, 2569.26),
                    new BarData("10/16/1989", 2569.26, 2667.42, 2496.93, 2657.38),
                    new BarData("10/17/1989", 2657.38, 2665.37, 2588.73, 2638.73),
                    new BarData("10/18/1989", 2638.73, 2664.34, 2610.66, 2643.65),
                    new BarData("10/19/1989", 2643.65, 2707.58, 2650.61, 2683.20),
                    new BarData("10/20/1989", 2683.20, 2703.07, 2660.25, 2689.14),
                    new BarData("10/23/1989", 2689.14, 2704.71, 2648.77, 2662.91),
                    new BarData("10/24/1989", 2662.91, 2680.74, 2570.28, 2659.22),
                    new BarData("10/25/1989", 2659.22, 2684.84, 2627.66, 2653.28),
                    new BarData("10/26/1989", 2653.28, 2657.99, 2597.74, 2613.73),
                    new BarData("10/27/1989", 2613.73, 2621.11, 2573.56, 2596.72),
                    new BarData("10/30/1989", 2596.72, 2627.05, 2588.11, 2603.48),
                    new BarData("10/31/1989", 2603.48, 2662.09, 2606.97, 2645.08),
                    new BarData("11/01/1989", 2645.08, 2665.78, 2622.95, 2645.90),
                    new BarData("11/02/1989", 2645.90, 2653.69, 2607.58, 2631.56),
                    new BarData("11/03/1989", 2631.56, 2650.82, 2612.91, 2629.51),
                    new BarData("11/06/1989", 2629.51, 2621.72, 2574.59, 2582.17),
                    new BarData("11/07/1989", 2582.17, 2608.81, 2563.11, 2597.13),
                    new BarData("11/08/1989", 2597.13, 2644.26, 2594.67, 2623.36),
                    new BarData("11/09/1989", 2623.36, 2634.84, 2595.90, 2603.69),
                    new BarData("11/10/1989", 2603.69, 2635.86, 2603.07, 2625.61),
                    new BarData("11/13/1989", 2625.61, 2648.36, 2602.05, 2626.43),
                    new BarData("11/14/1989", 2626.43, 2640.57, 2597.13, 2610.25),
                    new BarData("11/15/1989", 2610.25, 2641.60, 2600.00, 2632.58),
                    new BarData("11/16/1989", 2632.58, 2650.61, 2613.52, 2635.66),
                    new BarData("11/17/1989", 2635.66, 2665.37, 2623.15, 2652.66),
                    new BarData("11/20/1989", 2652.66, 2659.56, 2615.40, 2632.04),
                    new BarData("11/21/1989", 2632.04, 2654.22, 2614.97, 2639.29),
                    new BarData("11/22/1989", 2639.29, 2668.30, 2629.91, 2656.78),
                    new BarData("11/24/1989", 2656.78, 2686.01, 2657.00, 2675.55),
                    new BarData("11/27/1989", 2675.55, 2713.95, 2663.40, 2694.97),
                    new BarData("11/28/1989", 2694.97, 2715.02, 2677.26, 2702.01),
                    new BarData("11/29/1989", 2702.01, 2713.10, 2677.47, 2688.78),
                    new BarData("11/30/1989", 2688.78, 2718.22, 2681.95, 2706.27),
                    new BarData("12/01/1989", 2706.27, 2763.87, 2705.42, 2747.65),
                    new BarData("12/04/1989", 2747.65, 2772.18, 2731.02, 2753.63),
                    new BarData("12/05/1989", 2753.63, 2773.89, 2731.23, 2741.68),
                    new BarData("12/06/1989", 2741.68, 2754.91, 2722.70, 2736.77),
                    new BarData("12/07/1989", 2736.77, 2756.83, 2702.00, 2720.78),
                    new BarData("12/08/1989", 2720.78, 2750.85, 2716.51, 2731.44),
                    new BarData("12/11/1989", 2731.44, 2742.75, 2705.63, 2728.24),
                    new BarData("12/12/1989", 2728.24, 2764.51, 2716.51, 2752.13),
                    new BarData("12/13/1989", 2752.13, 2784.77, 2737.20, 2761.09),
                    new BarData("12/14/1989", 2761.09, 2771.33, 2732.08, 2753.63),
                    new BarData("12/15/1989", 2753.63, 2763.65, 2703.92, 2739.55),
                    new BarData("12/18/1989", 2739.55, 2755.55, 2679.82, 2697.53),
                    new BarData("12/19/1989", 2697.53, 2720.14, 2658.70, 2695.61),
                    new BarData("12/20/1989", 2695.61, 2719.07, 2667.02, 2687.93),
                    new BarData("12/21/1989", 2687.93, 2714.16, 2671.72, 2691.13),
                    new BarData("12/22/1989", 2691.13, 2721.20, 2682.59, 2711.39),
                    new BarData("12/26/1989", 2711.39, 2728.88, 2694.75, 2709.26),
                    new BarData("12/27/1989", 2709.26, 2739.12, 2700.30, 2724.40),
                    new BarData("12/28/1989", 2724.40, 2742.53, 2709.04, 2732.30),
                    new BarData("12/29/1989", 2732.30, 2763.01, 2726.96, 2753.20)
                };
            }
        }
        static IObservable<OHLC> OHLC
        {
            get {
                return INPUT.ToObservable().Select(bd => {
                    var sec = Security.Lookup("DMK3");
                    var oh = new OHLC(new Tick(sec, 1, (uint)(bd.Open * 100), bd.Date));
                    oh.Add(new Tick(sec, 1, (uint)(bd.High * 100), bd.Date));
                    oh.Add(new Tick(sec, 1, (uint)(bd.Low * 100), bd.Date));
                    oh.Add(new Tick(sec, 1, (uint)(bd.Close * 100), bd.Date));
                    return oh;
                });
            }
        }
        [TestMethod]
        public void CMO_TEST()
        {
            OHLC.Publish(sc => {
//                return sc.WithLatestFrom(sc.Delta(), (x, d) => (x, d));
                return sc.WithLatestFrom(sc.CMO(50), (x,d) => (x,d));
            }).Subscribe(x => Trace.WriteLine($"{x}"));
        }
    }
}
